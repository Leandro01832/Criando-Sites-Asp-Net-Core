using business.business.carousel;
using business.business.element;
using business.business.Elementos.element;
using CMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public interface IRepositoryCarousel
    {
        Task<ElementoDependente> TestarCarousel(string id);
        Carousel RetornaCarouselImagem(Elemento elemento);
        Carousel RetornaCarouselPagina(Elemento elemento);
    }



    public class RepositoryCarousel : BaseRepository<Carousel>, IRepositoryCarousel
    {

        public RepositoryCarousel(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Carousel RetornaCarouselImagem(Elemento elemento)
        {
            CarouselImg c = (CarouselImg)elemento;
            var carousel = new CarouselImg
            {
                Pagina_ = elemento.Pagina_,
                Nome = c.Nome,
                Ordem = elemento.Ordem,
                ElementosDependentes = c.ElementosDependentes,
                Dependentes = c.Dependentes

            };
            return carousel;
        }

        public Carousel RetornaCarouselPagina(Elemento elemento)
        {
            CarouselPagina c = (CarouselPagina)elemento;
            var carousel = new CarouselPagina
            {
                Pagina_ = elemento.Pagina_,
                Nome = c.Nome,
                Ordem = elemento.Ordem,
                ElementosDependentes = c.ElementosDependentes,
                Dependentes = c.Dependentes

            };
            return carousel;
        }

        public async Task<ElementoDependente> TestarCarousel(string id)
        {
            CarouselImg carousel;
            try
            {
                carousel = await contexto.Elemento.
               OfType<CarouselImg>().FirstOrDefaultAsync(e => e.Id == int.Parse(id));
            }
            catch (Exception)
            {
                carousel = null;
            }
            return carousel;
        }
    }
}