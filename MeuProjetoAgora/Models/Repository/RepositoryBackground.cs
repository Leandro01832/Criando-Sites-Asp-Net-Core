using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryBackground
    {
        Task CriarBackground(Pagina pagina, List<Imagem> imagem);
        
    }

    public class RepositoryBackground : BaseRepository<Background>, IRepositoryBackground
    {
        public RepositoryBackground(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {
        }

        

        public async Task CriarBackground(Pagina pag, List<Imagem> imagens)
        {

            Background back1 = new Background
            {
                backgroundImage = true,
                backgroundTransparente = false,
                Background_Position = "",
                Background_Repeat = "",
                PaginaId = pag.IdPagina,
                Cor = "#000000",
                imagem = imagens[0],
                imagem_ = imagens[0].IdImagem,
                Nome = "plano de fundo da pagina",
                BackgroundGradiente = new BackgroundGradiente()
                {
                     Grau = 0
                }
            };

                Background back2 = new Background
                {
                    backgroundImage = true,
                    backgroundTransparente = false,
                    Background_Position = "",
                    Background_Repeat = "",
                    PaginaId = pag.IdPagina,
                    Cor = "#000000",
                    imagem = imagens[1],
                    imagem_ = imagens[1].IdImagem,
                    Nome = "topo",
                    BackgroundGradiente = new BackgroundGradiente()
                    {
                        Grau = 0
                    }
                };


                Background back3 = new Background
                {
                    backgroundImage = true,
                    backgroundTransparente = false,
                    Background_Position = "",
                    Background_Repeat = "",
                    PaginaId = pag.IdPagina,
                    Cor = "#000000",
                    imagem = imagens[2],
                    imagem_ = imagens[2].IdImagem,
                    Nome = "menu",
                    BackgroundGradiente = new BackgroundGradiente()
                    {
                        Grau = 0
                    }
                };

                Background back4 = new Background
                {
                    backgroundImage = false,
                    backgroundTransparente = true,
                    Background_Position = "",
                    Background_Repeat = "",
                    PaginaId = pag.IdPagina,
                    Cor = "#000000",
                    imagem = imagens[0],
                    imagem_ = imagens[0].IdImagem,
                    Nome = "borda esquerda",
                    BackgroundGradiente = new BackgroundGradiente()
                    {
                        Grau = 0
                    }
                };

                Background back5 = new Background
                {
                    backgroundImage = false,
                    backgroundTransparente = true,
                    Background_Position = "",
                    Background_Repeat = "",
                    PaginaId = pag.IdPagina,
                    Cor = "#000000",
                    imagem = imagens[0],
                    imagem_ = imagens[0].IdImagem,
                    Nome = "borda direita",
                    BackgroundGradiente = new BackgroundGradiente()
                    {
                        Grau = 0
                    }
                };

                Background back6 = new Background
                {
                    backgroundImage = false,
                    backgroundTransparente = true,
                    Background_Position = "",
                    Background_Repeat = "",
                    PaginaId = pag.IdPagina,
                    Cor = "#000000",
                    imagem = imagens[0],
                    imagem_ = imagens[0].IdImagem,
                    Nome = "blocos",
                    BackgroundGradiente = new BackgroundGradiente()
                    {
                        Grau = 0
                    }
                };

            await dbSet.AddAsync(back1);
            await dbSet.AddAsync(back2);
            await dbSet.AddAsync(back3);
            await dbSet.AddAsync(back4);
            await dbSet.AddAsync(back5);
            await dbSet.AddAsync(back6);

              await  contexto.SaveChangesAsync();           
            
        }

        
    }
}
