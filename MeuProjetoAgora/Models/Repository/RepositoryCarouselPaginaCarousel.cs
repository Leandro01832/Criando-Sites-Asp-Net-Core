
using MeuProjetoAgora.Data;
using MeuProjetoAgora.business;
using MeuProjetoAgora.business.Elementos;
using MeuProjetoAgora.Join;
using MeuProjetoAgora.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
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
                .ThenInclude(cp => cp.Elemento)
                .ThenInclude(cp => cp.Despendentes)
                .ThenInclude(cp => cp.ElementoDependente)
                .ThenInclude(cp => cp.Dependente)
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
                .Include(cp => cp.div)
                .ThenInclude(cp => cp.Div)
                .ThenInclude(cp => cp.Elemento)
                .ThenInclude(cp => cp.Elemento)
                .ThenInclude(cp => cp.Despendentes)
                .ThenInclude(cp => cp.ElementoDependente)
                .ThenInclude(cp => cp.Dependente)
                .Include(cp => cp.Despendentes)
                .ThenInclude(cp => cp.ElementoDependente)
                .ThenInclude(cp => cp.Dependente);

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
            .ThenInclude(b => b.Elemento)
            .ThenInclude(b => b.Despendentes)
            .ThenInclude(b => b.ElementoDependente)
            .ThenInclude(b => b.Dependente)
            .ThenInclude(b => b.Despendentes)
            .ThenInclude(b => b.ElementoDependente)
            .ThenInclude(b => b.Dependente)
            .ThenInclude(b => b.Despendentes)
            .ThenInclude(b => b.ElementoDependente)
            .ThenInclude(b => b.Dependente)
                .FirstAsync(c => c.IdElemento == idElemento);
            return CarouselPagina;
        }

        public CarouselPagina RetornaCarouselPagina(Elemento elemento)
        {
            var carousel = new CarouselPagina
            {
                Pagina_ = elemento.Pagina_,
                IdElemento = elemento.IdElemento,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                ElementosDependentes = elemento.ElementosDependentes,
                Despendentes = elemento.Despendentes

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
                .FirstAsync(e => e.Pagina.IdPagina
                == dependente.Pagina.IdPagina &&
                e.CarouselPagina.IdElemento
                == dependente.CarouselPagina.IdElemento);
            }
            catch (Exception)
            {
                depe = null;
            }
            return depe;
        }
    }
}
