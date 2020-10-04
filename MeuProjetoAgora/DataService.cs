
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.Repository;
using MeuProjetoAgora.Data;

namespace MeuProjetoAgora
{
    public class DataService : IDataService
    {
        public async Task InicializaDBAsync(IServiceProvider provider)
        {
            var contexto = provider.GetService<ApplicationDbContext>();

            await contexto.Database.MigrateAsync();

            if (await contexto.Set<Imagem>().AnyAsync())
            {
                return;
            }

          var lista = ListaImagens();

            var imagemRepositorty = provider.GetService<IRepositoryImagem>();
            await imagemRepositorty.SaveImagemsAsync(lista);
            
        }

        private List<Imagem>  ListaImagens()
        {
            var listaImagens = new List<Imagem>()
            {
                new Imagem
                {
                     Arquivo = "/ImagensGaleria/1.jpg"
                },
                new Imagem
                {
                     Arquivo = "/ImagensGaleria/2.jpg"
                },
                new Imagem
                {
                     Arquivo = "/ImagensGaleria/3.jpg"
                }
            };

            return listaImagens;
        }
    }
}
