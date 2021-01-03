using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.business.Elemento;
using MeuProjetoAgora.Models.Join;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
    public class RepositoryElemento : BaseRepository<Elemento>, IRepositoryElemento
    {
        public IRepositoryImagem RepositoryImagem { get; }
        public IRepositoryPagina RepositoryPagina { get; }
        public IRepositoryCampo RepositoryCampo { get; }
        public IRepositoryProduto RepositoryProduto { get; }
        public IRepositoryForm RepositoryForm { get; }
        public IRepositoryTable RepositoryTable { get; }
        public IRepositoryTexto RepositoryTexto { get; }
        public IRepositoryElementoDependente RepositoryElementoDependente { get; }
        public IRepositoryCarouselPaginaCarousel RepositoryCarouselPaginaCarousel { get; }
        public IRepositoryLink RepositoryLink { get; }
        public IRepositoryCarousel RepositoryCarousel { get; }
        public IRepositoryDropdown RepositoryDropdown { get; }

        public RepositoryElemento(IConfiguration configuration, ApplicationDbContext contexto,
            IRepositoryImagem repositoryImagem, IRepositoryPagina repositoryPagina, IRepositoryCampo repositoryCampo,
            IRepositoryProduto repositoryProduto, IRepositoryForm repositoryForm, IRepositoryTable repositoryTable,
            IRepositoryTexto repositoryTexto, IRepositoryElementoDependente repositoryElementoDependente,
             IRepositoryCarouselPaginaCarousel repositoryCarouselPaginaCarousel, IRepositoryLink repositoryLink,
             IRepositoryCarousel repositoryCarousel, IRepositoryDropdown repositoryDropdown)
            : base(configuration, contexto)
        {
            RepositoryImagem = repositoryImagem;
            RepositoryPagina = repositoryPagina;
            RepositoryCampo = repositoryCampo;
            RepositoryProduto = repositoryProduto;
            RepositoryForm = repositoryForm;
            RepositoryTable = repositoryTable;
            RepositoryTexto = repositoryTexto;
            RepositoryElementoDependente = repositoryElementoDependente;
            RepositoryCarouselPaginaCarousel = repositoryCarouselPaginaCarousel;
            RepositoryLink = repositoryLink;
            RepositoryCarousel = repositoryCarousel;
            RepositoryDropdown = repositoryDropdown;
        }

        public async Task Editar(Elemento elemento)
        {
            contexto.Entry(elemento).State = EntityState.Modified;
            await contexto.SaveChangesAsync();

            var ele = await contexto.Elemento.Include(e => e.Despendentes)
           .ThenInclude(e => e.ElementoDependente)
           .ThenInclude(e => e.Dependente)
           .Include(e => e.Despendentes)
           .ThenInclude(e => e.Elemento)
           .FirstAsync(e => e.IdElemento == elemento.IdElemento);
            elemento.Despendentes = ele.Despendentes;

            if(elemento.GetType().Name == "CarouselPagina")
            {
                elemento = await contexto.CarouselPagina
                    .Include(e => e.Paginas)
                    .Include(e => e.Despendentes)
                    .ThenInclude(e => e.ElementoDependente)
                    .ThenInclude(e => e.Dependente)
                    .Include(e => e.Despendentes)
                    .ThenInclude(e => e.Elemento)
                    .FirstAsync(e => e.IdElemento == elemento.IdElemento);
                    elemento.Despendentes = ele.Despendentes;
            }

            await elementosDependentes(elemento.ElementosDependentes, elemento);
        }

        public async Task<List<Elemento>> TodosElementos()
        {
            var lista = await contexto.Elemento
                .Include(e => e.div)
                .ThenInclude(e => e.Div)
                .ThenInclude(e => e.Pagina)
                .ThenInclude(e => e.Pagina)
                .ThenInclude(e => e.Pedido)
                .Include(e => e.div)
                .ThenInclude(e => e.Elemento)
                .Include(e => e.Despendentes)
                .ThenInclude(e => e.ElementoDependente)
                .ThenInclude(e => e.Dependente).ToListAsync();

            return lista;
        }

        public async Task<string> salvar(Elemento elemento)
        {
            elemento.IdElemento = 0;
            await dbSet.AddAsync(elemento);            
            await contexto.SaveChangesAsync();

            await elementosDependentes(elemento.ElementosDependentes, elemento);

            return $"Chave do elemento {elemento.IdElemento}";
        }

        public Elemento Elemento(ViewModelElemento elemento)
        {
            if (elemento.elemento == "Imagem")
            {
                return RepositoryImagem.RetornaImagem(elemento);
            }

            if (elemento.elemento == "Carousel")
            {
                return RepositoryCarousel.RetornaCarousel(elemento);                
            }

            if (elemento.elemento == "CarouselPagina")
            {
                return RepositoryCarouselPaginaCarousel.RetornaCarouselPagina(elemento);                
            }

            if (elemento.elemento == "Table")
            {
                return RepositoryTable.RetornaTable(elemento);                
            }

            if (elemento.elemento == "Link")
            {
                return RepositoryLink.RetornaLink(elemento);                
            }            

            if (elemento.elemento == "Texto")
            {
                return RepositoryTexto.RetornaTexto(elemento);                
            }

            if (elemento.elemento == "Dropdown")
            {
                return RepositoryDropdown.RetornaDropdown(elemento);                
            }

            if (elemento.elemento == "Formulario")
            {
                return RepositoryForm.RetornaFormulario(elemento);                
            }

            if (elemento.elemento == "Produto")
            {
                return RepositoryProduto.RetornaProduto(elemento);                
            }

            if (elemento.elemento == "Campo")
            {
                return RepositoryCampo.RetornaCampo(elemento);                
            }

            return new Elemento();
        }

        private async Task elementosDependentes(string elementosDependentes, Elemento elemento)
        {
            var pagina1 = await contexto.Pagina.FirstAsync(e => e.IdPagina == elemento.Pagina_);
            var site1 = await contexto.Pedido.FirstOrDefaultAsync(e => e.IdPedido == pagina1.pedido_);
            var cliente = site1.ClienteId;

            var listaString = new List<string>();            
            string elementosGravados = "";
            if(!string.IsNullOrEmpty(elementosDependentes))
                listaString = elementosDependentes.Replace(" ", "").Split(',').ToList();

            if (elemento.Despendentes != null)
            {
                foreach (var dependente in elemento.Despendentes)
                {
                    elementosGravados += dependente.ElementoDependente.Dependente.IdElemento + ", ";
                }
            }
            await ApagarElementosDependentes(elementosDependentes, elemento);

            foreach (var id in listaString)
            {
                Imagem imagem;
                Campo campo;
                Link link;
                Produto produto;
                Texto texto;
                Table table;
                Formulario formulario;
                Pagina pag;
                bool MesmoCliente = false;
                Elemento elementoDepe;

                try
                {
                     elementoDepe = await contexto.Elemento.FirstOrDefaultAsync(d => d.IdElemento == int.Parse(id));
                }
                catch (Exception)
                {
                    elementoDepe = null;
                }
                if (elementoDepe != null)
                {
                    var paginaElementoDepe = await contexto.Pagina.FirstOrDefaultAsync(p => p.IdPagina == elementoDepe.Pagina_);
                    if (paginaElementoDepe != null && paginaElementoDepe.pedido_ == site1.IdPedido)
                    {
                        var site = await contexto.Pedido.FirstOrDefaultAsync(p => p.IdPedido == paginaElementoDepe.pedido_);
                        if (site.ClienteId == cliente)
                        {
                            MesmoCliente = true;
                        }
                    }
                }

                if (elemento.GetType().Name == "Carousel")
                {
                    imagem = await RepositoryImagem.TestarImagem(id);

                    if (imagem != null && MesmoCliente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento, int.Parse(id));
                    }
                }

                if (elemento.GetType().Name == "CarouselPagina")
                {
                    await ApagarPaginasDependentes(elementosDependentes, elemento);
                    pag = await RepositoryPagina.TestarPagina(id);
                    bool MesmoClienteSite = false;

                    Pagina PaginaDepe;

                    try
                    {
                        PaginaDepe = await contexto.Pagina.FirstOrDefaultAsync(d => d.IdPagina == int.Parse(id));
                    }
                    catch (Exception)
                    {
                        PaginaDepe = null;
                    }
                    if (PaginaDepe != null)
                    {
                        var paginaDepePagina = contexto.Pagina.First(p => p.IdPagina == PaginaDepe.IdPagina);
                        var site = contexto.Pedido.First(p => p.IdPedido == paginaDepePagina.pedido_);
                        if (site.ClienteId == cliente)
                        {
                            MesmoClienteSite = true;
                        }
                    }

                    var paginasGravadas = "";
                    var carouselPagina = (CarouselPagina)elemento;
                    
                    if(carouselPagina.Paginas != null && MesmoClienteSite)
                    {
                        foreach (var item in carouselPagina.Paginas)
                        {
                            paginasGravadas += item.Pagina.IdPagina.ToString() +  ", ";
                        }
                    }
                    

                    if (pag != null  && !paginasGravadas.Contains(id))
                    {
                        await salvarPaginaDependente(elemento, int.Parse(id));
                    }
                }

                if (elemento.GetType().Name == "Formulario")
                {
                    campo = await RepositoryCampo.TestarCampo(id);

                    if (campo != null && MesmoCliente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento, int.Parse(id));
                    }
                }

                if (elemento.GetType().Name == "Dropdown")
                {
                    link = await RepositoryLink.TestarLink(id);

                    if (link != null && MesmoCliente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento, int.Parse(id));
                    }
                }

                if (elemento.GetType().Name == "Table")
                {
                    produto = await RepositoryProduto.TestarProduto(id);

                    bool verificaProdutoExistente = await RepositoryProduto
                            .VerificaExistenciaElementoDependente(id);

                    if (produto != null && MesmoCliente && !verificaProdutoExistente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento, int.Parse(id));
                    }
                }

                if (elemento.GetType().Name == "Campo")
                {
                    if (id == listaString[listaString.Count - 1])
                    {
                        formulario = await RepositoryForm.TestarForm(id);

                        if (formulario != null && MesmoCliente)
                        {
                            var ele = await contexto.Elemento.Include(e => e.Despendentes)
                            .FirstAsync(e => e.IdElemento == formulario.IdElemento);

                            ele.IncluiElemento(new ElementoDependente { Dependente = elemento });
                            await contexto.SaveChangesAsync();
                        }
                    }
                }

                if (elemento.GetType().Name == "Produto")
                {
                    if (id == listaString[listaString.Count - 1])
                    {
                        table = await RepositoryTable.TestarTable(listaString[0]);

                        bool verificaProdutoExistente = await RepositoryProduto
                            .VerificaExistenciaElementoDependente(elemento.IdElemento.ToString());

                        if (table != null && MesmoCliente && !verificaProdutoExistente)
                        {
                            var ele = await contexto.Elemento.Include(e => e.Despendentes)
                            .FirstAsync(e => e.IdElemento == table.IdElemento);

                            ele.IncluiElemento(new ElementoDependente { Dependente = elemento });
                            await contexto.SaveChangesAsync();
                        }
                    }

                    formulario = await RepositoryForm.TestarForm(id);
                    table = await RepositoryTable.TestarTable(id);
                    produto = await RepositoryProduto.TestarProduto(id);
                    campo = await RepositoryCampo.TestarCampo(id);

                    //elemento dependente e possui elementos dependentes
                    if (table == null && formulario == null && campo == null
                        && produto == null && MesmoCliente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento, int.Parse(id));
                    }
                }

                if (elemento.GetType().Name == "Link")
                {
                    Imagem imagemLink = new Imagem();
                    imagemLink = await RepositoryImagem.TestarImagem(listaString[1]);
                    texto = await RepositoryTexto.TestarTexto(listaString[0]);

                    if (texto != null && MesmoCliente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento, int.Parse(id));
                    }

                    if (imagemLink != null && MesmoCliente && !elementosGravados.Contains(id))
                    {
                        await salvarElementoDependente(elemento, int.Parse(id));
                    }

                    break;
                }

            }
        }        

        private async Task salvarPaginaDependente(Elemento elemento, int v)
        {
            var pagina = await contexto.Pagina.FirstAsync(p => p.IdPagina == v);
            var ele = await contexto.CarouselPagina.Include(e => e.Paginas)
            .FirstAsync(e => e.IdElemento == elemento.IdElemento);

            ele.IncluiPagina(pagina);
            await contexto.SaveChangesAsync();
        }

        private async Task salvarElementoDependente(Elemento elemento, int v)
        {
            var elementoDependente = new ElementoDependente { Elemento_ = v };
            await contexto.ElementoDependente.AddAsync(elementoDependente);
            await contexto.SaveChangesAsync();
            var ele = await contexto.Elemento.Include(e => e.Despendentes)
            .FirstAsync(e => e.IdElemento == elemento.IdElemento);
            ele.IncluiElemento(elementoDependente);
            await contexto.SaveChangesAsync();
        }

        private async Task ApagarElementosDependentes(string elementosDependentes, Elemento elemento)
        {
            if (elemento.Despendentes != null)
            {
                foreach (var dependente in elemento.Despendentes)
                {
                    if (!elementosDependentes.Contains(dependente.ElementoDependente.Dependente.IdElemento.ToString()))
                    {
                        ElementoDependenteElemento depe;
                        depe = await RepositoryElementoDependente.TestarElementoDependenteElemento(dependente);
                        if (depe != null)
                        {
                            contexto.ElementoDependenteElemento.Remove(depe);
                        }
                    }
                }
                await contexto.SaveChangesAsync();
            }
        }

        private async Task ApagarPaginasDependentes(string elementosDependentes, Elemento elemento)
        {
           var cp = (CarouselPagina) elemento;
            if (cp.Paginas != null)
            {
                foreach (var dependente in cp.Paginas)
                {
                    if (!elementosDependentes.Contains(dependente.Pagina.IdPagina.ToString()))
                    {
                        PaginaCarouselPagina depe;
                        depe = await RepositoryCarouselPaginaCarousel.TestarCarouselPaginaCarousel(dependente);
                        if (depe != null)
                        {
                            contexto.PaginaCarouselPagina.Remove(depe);
                        }
                    }
                }
                await contexto.SaveChangesAsync();
            }
        }

        public IIncludableQueryable<Elemento, Elemento> includes()
        {
            var l = contexto.Elemento
                .Include(e => e.div)
                .ThenInclude(e => e.Div)
                .ThenInclude(e => e.Pagina)
                .ThenInclude(e => e.Pagina)
                .ThenInclude(e => e.Pedido)
                .Include(e => e.div)
                .ThenInclude(e => e.Elemento)
                .Include(e => e.Despendentes)
                .ThenInclude(e => e.ElementoDependente)
                .ThenInclude(e => e.Dependente)
                .ThenInclude(e => e.Despendentes)
                .ThenInclude(e => e.ElementoDependente)
                .ThenInclude(e => e.Dependente);
            return l;
        }
    }
}
