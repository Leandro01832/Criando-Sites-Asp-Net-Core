using business.business.carousel;
using business.business.Elementos.element;
using business.Join;
using CMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public interface IRepositoryCarouselPaginaCarousel
    {
        Task<PaginaCarouselPagina> TestarCarouselPaginaCarousel(PaginaCarouselPagina dependente);
        IIncludableQueryable<CarouselPagina, Elemento> includes();
        CarouselPagina RetornaCarouselPagina(Elemento elemento);
        Task<Elemento> IncluiPaginas(int idElemento);
    }



    public class RepositoryPaginaCarouselPagina : BaseRepository<CarouselPagina>, IRepositoryCarouselPaginaCarousel
    {

        public RepositoryPaginaCarouselPagina(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public IIncludableQueryable<CarouselPagina, Elemento> includes()
        {
            var l3 = contexto.CarouselPagina
                .Include(e => e.Paginas)
                .ThenInclude(cp => cp.Pagina)
                .ThenInclude(cp => cp.Div)
                .ThenInclude(cp => cp.Div)
                .ThenInclude(cp => cp.Elemento)
                .Include(e => e.div)
                .ThenInclude(e => e.Div)
                .ThenInclude(e => e.Pagina)
                .ThenInclude(e => e.Pagina)
                .ThenInclude(e => e.Pedido)
                .Include(e => e.div)
                .ThenInclude(e => e.Elemento)
                .Include(e => e.Dependentes)
                .ThenInclude(e => e.ElementoDependente)
                .Include(cp => cp.div)
                .ThenInclude(cp => cp.Div)
                .ThenInclude(cp => cp.Elemento)
                .Include(cp => cp.Dependentes)
                .ThenInclude(cp => cp.ElementoDependente);

            return l3;
        }

        public async Task<Elemento> IncluiPaginas(int idElemento)
        {
            var CarouselPagina = await dbSet
                .Include(c => c.Paginas)
                .ThenInclude(p => p.Pagina)
                .ThenInclude(p => p.Div)
            .ThenInclude(b => b.Div)
            .ThenInclude(b => b.Elemento)
                .FirstAsync(c => c.Id == idElemento);
            return CarouselPagina;
        }

        public CarouselPagina RetornaCarouselPagina(Elemento elemento)
        {
            var c = (CarouselPagina)elemento;
            var carousel = new CarouselPagina
            {
                Pagina_ = elemento.Pagina_,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                ElementosDependentes = c.ElementosDependentes,
                Dependentes = c.Dependentes

            };
            return carousel;
        }

        public async Task<PaginaCarouselPagina> TestarCarouselPaginaCarousel(PaginaCarouselPagina dependente)
        {
            PaginaCarouselPagina depe;
            try
            {
                depe = await contexto.PaginaCarouselPagina
                    .Include(e => e.Pagina)
                    .Include(e => e.CarouselPagina)
                .FirstAsync(e => e.Pagina.Id
                == dependente.Pagina.Id &&
                e.CarouselPagina.Id
                == dependente.CarouselPagina.Id);
            }
            catch (Exception)
            {
                depe = null;
            }
            return depe;
        }
    }
}