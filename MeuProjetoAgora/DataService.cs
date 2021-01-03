
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
using MeuProjetoAgora.Models.business.Elemento;

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
                pedido_ = pedido.IdPedido
                
            };

            await contexto.Pagina.AddAsync(pagina);
            await contexto.SaveChangesAsync();

            var Background = new Background
            {
                backgroundImage = false,
                backgroundTransparente = true,
                Background_Position = "",
                Background_Repeat = "",
                Cor = "",
                Gradiente = false,
                Nome = "Default",
                PaginaId = pagina.IdPagina        

            };

            await contexto.Background.AddAsync(Background);
            await contexto.SaveChangesAsync();

            var Div = new Div
            {
                background_ = Background.IdBackground,
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
