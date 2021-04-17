
using MeuProjetoAgora.Data;
using MeuProjetoAgora.business;
using MeuProjetoAgora.business.Elementos;
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
        Task<string> TestarCarousel(int id);
        Carousel RetornaCarousel(Elemento elemento);
    }



    public class RepositoryCarousel : BaseRepository<Carousel>, IRepositoryCarousel
    {

        public RepositoryCarousel(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {

        }

        public Carousel RetornaCarousel(Elemento elemento)
        {
            var carousel = new Carousel
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

        public Task<string> TestarCarousel(int id)
        {
            throw new NotImplementedException();
        }
    }
}
