using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.business.Elemento;
using MeuProjetoAgora.Models.Join;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryDiv
    {
        Task<string> SalvarBloco(Div div);
        Task<string> EditarBloco(Div div);
        Task ElementosBloco(Div div);
        IIncludableQueryable<Div, List<Cor>> includes();
        Task<bool> VerificarExistenciaTable(string id);
    }

    public class RepositoryDiv : BaseRepository<Div>, IRepositoryDiv
    {
        public RepositoryDiv(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {
        }

        

        public async Task<string> EditarBloco(Div div)
        {
            contexto.Update(div);
            await contexto.SaveChangesAsync();

            var Div = await contexto.Div
                .Include(d => d.Elemento)
                .ThenInclude(d => d.Div)
                .Include(d => d.Elemento)
                .ThenInclude(d => d.Elemento)
                .FirstAsync(d => d.IdDiv == div.IdDiv);
            Div.Elementos = div.Elementos;

            await ElementosBloco(Div);

            return "";

        }

        public async Task<string> SalvarBloco(Div div)
        {
            Div Div = new Div();
                Div.Nome         = div.Nome;
                Div.background_  = div.background_;
                Div.Colunas      = "auto";
                Div.Height       = 200;
                Div.Divisao      = "col-md-12";
                Div.BorderRadius = 0;
                Div.Padding      = 5;
                Div.Desenhado    = 0;

            try
            {
                div.IdDiv = 0;
                await dbSet.AddAsync(div);
                await contexto.SaveChangesAsync();
            }
            catch (Exception)
            {
                return "";
            }

            await ElementosBloco(div);

            return $"Chave do Bloco: {div.IdDiv}";
        }

        public async Task ElementosBloco(Div div)
        {
            var pagina1 = await contexto.Pagina.FirstAsync(p => p.IdPagina == div.Pagina_);
            var site1 = await contexto.Pedido.FirstAsync(p => p.IdPedido == pagina1.pedido_);
            var cliente = site1.ClienteId;

            string elementosGravados = "";
            var array = div.Elementos.Replace(" ", "").Split(',');

            if (div.Elemento != null)
            {

                foreach (var elemento in div.Elemento)
                {
                    elementosGravados += elemento.Elemento.IdElemento + ", ";
                    if (!div.Elementos.Contains(elemento.ElementoId.ToString()))
                    {
                        DivElemento ele;
                        try
                        {
                            ele = await contexto.DivElemento
                            .Include(de => de.Elemento)
                            .Include(de => de.Div)
                            .FirstOrDefaultAsync(e => e.Elemento.IdElemento == elemento.Elemento.IdElemento &&
                            e.Div.IdDiv == elemento.Div.IdDiv);
                        }
                        catch (Exception)
                        {
                            ele = null;
                        }
                        if (ele != null)
                        {
                            contexto.DivElemento.Remove(ele);
                        }
                    }
                }
                await contexto.SaveChangesAsync();
            }

            foreach (var id in array)
            {
                var Div = await contexto.Div.Include(d => d.Elemento).FirstAsync(d => d.IdDiv == div.IdDiv);
                Elemento ele;
                bool MesmoCliente = false;               

                try
                {
                    ele = await contexto.Elemento.FirstOrDefaultAsync(d => d.IdElemento == int.Parse(id));
                    if (ele != null)
                    {
                        var paginaElementoDepe = contexto.Pagina.First(p => p.IdPagina == ele.Pagina_);
                        var site = contexto.Pedido.First(p => p.IdPedido == paginaElementoDepe.pedido_);
                        if (site.ClienteId == cliente)
                        {
                            MesmoCliente = true;
                        }
                    }
                }
                catch (Exception)
                {
                    ele = null;
                }

                bool VerificaBloco = await VerificaVariosBlocoComTable(Div, ele);

                if (ele != null && MesmoCliente && !elementosGravados.Contains(id) && !VerificaBloco)
                {
                    Div.IncluiElemento(ele);
                    await contexto.SaveChangesAsync();
                }
                    
            }
        }

        private async Task<bool> VerificaVariosBlocoComTable(Div div, Elemento ele)
        {
            var blocos = await contexto.DivPagina.Include(d => d.Div).Where(d => d.DivId == div.IdDiv).ToListAsync();

            if (blocos.Count > 1 && ele.GetType().Name == "Table") return true;
            else
                return false;
        }

        public IIncludableQueryable<Div, List<Cor>> includes()
        {
            var divs =  contexto.Div
                .Include(p => p.Elemento)
                .ThenInclude(p => p.Elemento)
                .ThenInclude(e => e.Despendentes)
                .ThenInclude(e => e.ElementoDependente)
                .ThenInclude(e => e.Dependente)
                .Include(p => p.Background)
                .ThenInclude(b => b.imagem)
                .Include(p => p.Background)
                .ThenInclude(b => b.BackgroundGradiente)
                .ThenInclude(b => b.Cores);
            return divs;
        }

        public async Task<bool> VerificarExistenciaTable(string id)
        {
            Div div;
            bool condicao = false;
            try
            {
                div = await contexto.Div
                     .Include(d => d.Elemento)
                     .ThenInclude(d => d.Elemento)
                     .FirstOrDefaultAsync(d => d.IdDiv == int.Parse(id));

                if(div != null)
                {
                    foreach(var elemento in div.Elemento)
                    {
                        if(elemento.Elemento.GetType().Name == "Table")
                        {
                            condicao = true;
                        }
                    }
                }


            }
            catch(Exception)
            {
                return true;
            }

                return condicao;
        }
    }
}
