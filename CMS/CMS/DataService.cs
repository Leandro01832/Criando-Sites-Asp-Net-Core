using business.Back;
using business.business;
using business.business.Elementos;
using business.business.Elementos.imagem;
using business.div;
using CMS.Data;
using CMS.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS
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

          var lista = await ListaImagens(provider);

            var imagemRepositorty = provider.GetService<IRepositoryImagem>();
            await imagemRepositorty.SaveImagems(lista);
            
        }

        private async Task<List<Imagem>> ListaImagens(IServiceProvider provider)
        {
            var contexto = provider.GetService<ApplicationDbContext>();

            var pedido = new Pedido
            {
                ClienteId = "Default",
                Datapedido = DateTime.Now,
                DominioTemporario = "Default",
                Nome = "Default",
                Status = "Default",
                Venda = false
            };

            await contexto.Pedido.AddAsync(pedido);
            await contexto.SaveChangesAsync();

            var pagina = new Pagina
            {
                Facebook = "",
                ArquivoMusic = "",
                Html = "",
                Instagram = "",
                Margem = false,
                Music = false,
                Rotas = "",
                Titulo = "Default",
                Twiter = "",
                PedidoId = pedido.Id
                
            };

            await contexto.Pagina.AddAsync(pagina);
            await contexto.SaveChangesAsync();

            var Background = new BackgroundCor
            {
                backgroundTransparente = true,
                Cor = "",
                Nome = "Default",
                PaginaId = pagina.Id        

            };

            await contexto.Background.AddAsync(Background);
            await contexto.SaveChangesAsync();

            var Div = new DivComum
            {
                BackgroundId = Background.Id,
                BorderRadius = 0,
                Colunas = "auto",
                Desenhado = 1,
                Divisao = "",
                Height = 200,
                Nome = "Default",
                Ordem = 0,
                Padding = 5   
           };

            await contexto.Div.AddAsync(Div);
            await contexto.SaveChangesAsync();

            var listaImagens = new List<Imagem>()
            {
                new Imagem
                {
                     ArquivoImagem = "/ImagensGaleria/1.jpg",
                       Nome = "Default",
                        Width = 100
                },
                new Imagem
                {
                     ArquivoImagem = "/ImagensGaleria/2.jpg",
                       Nome = "Default",
                        Width = 100
                },
                new Imagem
                {
                     ArquivoImagem = "/ImagensGaleria/3.jpg",
                       Nome = "Default",
                        Width = 100
                }
            };

            return listaImagens;
        }
    }
}
