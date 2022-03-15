using business.business.carousel;
using business.business.Elementos.element;
using business.Join;
using CMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public class RepositoryElemento : BaseRepository<Elemento>, IRepositoryElemento
    {
        public IRepositoryPagina RepositoryPagina { get; }

        public RepositoryElemento(IConfiguration configuration, ApplicationDbContext contexto,
            IRepositoryPagina repositoryPagina)
            : base(configuration, contexto)
        {
            RepositoryPagina = repositoryPagina;
        }

        public async Task<string> Editar(Elemento elemento)
        {
            contexto.Entry(elemento).State = EntityState.Modified;
            await contexto.SaveChangesAsync();

            if (elemento.ElementosDependentes != "")
            {

                var arr = elemento.ElementosDependentes.Replace(" ", "").Split(',');

              //  depe = dbSet.OfType<ElementoDependente>().Include(e => e.Dependentes).First(e => e.Id == elemento.Id);

                foreach (var item in arr)
                    if (elemento.Dependentes.FirstOrDefault(d => d.ElementoId == elemento.Id &&
                     d.ElementoDependenteId == int.Parse(item)) == null)
                        elemento.IncluiElemento(dbSet.First(e => e.Id == int.Parse(item)));

                await contexto.SaveChangesAsync();

                foreach (var item in elemento.Dependentes)
                    if (!arr.Contains(item.ElementoDependenteId.ToString()))
                    {
                        contexto.ElementoDependenteElemento.Remove(item);
                        await contexto.SaveChangesAsync();
                    }
            }

            return "";
        }

        public async Task<string> salvar(Elemento elemento)
        {
            await dbSet.AddAsync(elemento);
            await contexto.SaveChangesAsync();

            if (elemento is CarouselPagina)
            {
                elemento.Paginas = new List<PaginaCarouselPagina>();

                var arr = elemento.ElementosDependentes.Replace(" ", "").Split(',');

                foreach (var item in arr)
                {
                    var ele = await contexto.Pagina.FirstAsync(el => el.Id == int.Parse(item));
                    PaginaCarouselPagina depe = new PaginaCarouselPagina
                    {
                        ElementoId = elemento.Id,
                        PaginaId = ele.Id
                    };
                    contexto.Add(depe);
                }

                try
                {
                    await contexto.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }

            if (!(elemento is CarouselPagina) && elemento.ElementosDependentes != "")
            {
                elemento.Dependentes = new List<ElementoDependenteElemento>();

                var arr = elemento.ElementosDependentes.Replace(" ", "").Split(',');

                foreach (var item in arr)
                {
                    var ele = await dbSet.FirstAsync(el => el.Id == int.Parse(item));
                    ElementoDependenteElemento depe = new ElementoDependenteElemento
                    {
                        ElementoId = elemento.Id,
                        ElementoDependenteId = ele.Id
                    };
                    contexto.Add(depe);
                }

                await contexto.SaveChangesAsync();

            }

            return $"Chave do elemento {elemento.Id}";
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
                .ThenInclude(e => e.Elemento);
            return l;
        }
    }
}