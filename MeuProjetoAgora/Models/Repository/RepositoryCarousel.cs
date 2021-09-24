
using MeuProjetoAgora.business.Elementos;
using MeuProjetoAgora.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryCarousel
    {
        Task<string> TestarCarousel(int id);
        Carousel RetornaCarousel(ViewModelElemento elemento);
    }



    public class RepositoryCarousel : BaseRepository<Carousel>, IRepositoryCarousel
    {

        public RepositoryCarousel(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Carousel RetornaCarousel(ViewModelElemento elemento)
        {
            var carousel = new Carousel
            {
                Pagina_ = elemento.Pagina_,
                IdElemento = elemento.IdElemento,
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                ElementosDependentes = elemento.elementosDependentes,
                Despendentes = elemento.Dependentes

            };
            return carousel;
        }

        public Task<string> TestarCarousel(int id)
        {
            throw new NotImplementedException();
        }
    }
}