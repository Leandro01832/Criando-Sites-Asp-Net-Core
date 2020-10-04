
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryCarousel
    {
        Task<string> salvarCarousel(ViewModelElemento elemento, IList<IFormFile> files);
        Task editarCarousel(ViewModelElemento elemento);
        Task apagarCarousel(ViewModelElemento elemento);
    }



    public class RepositoryCarousel : BaseRepository<Carousel>, IRepositoryCarousel
    {

        public RepositoryCarousel(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Task apagarCarousel(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public Task editarCarousel(ViewModelElemento elemento)
        {
            throw new NotImplementedException();
        }

        public async Task<string> salvarCarousel(ViewModelElemento elemento, IList<IFormFile> files)
        {
            Carousel carousel = new Carousel
            {
                div_2 = elemento.div,
                Nome = elemento.Nome
            };

            try
            {
                await dbSet.AddAsync(carousel);
                await contexto.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                var erro = "Preencha o formulario corretamente" + ex;
                return "";
            }

            var Carousel = dbSet.Include(e => e.Div).First(el => el.IdCarousel == carousel.IdCarousel);
            var element = new Elemento();
            element.carousel_ = Carousel.IdCarousel;
            await contexto.Elemento.AddAsync(element);
            await contexto.SaveChangesAsync();

            if (elemento.Renderizar)
            {
                element.div_2 = Carousel.Div.IdDiv;
                contexto.Entry(element).State = EntityState.Modified;
                await contexto.SaveChangesAsync();
            }

            return $"Chave do elemento: {element.IdElemento}";
        }
    }
}
