using business.Back;
using business.business;
using business.business.Elementos;
using business.business.Elementos.imagem;
using CMS.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Models.Repository
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

            Background back1 = new BackgroundImagem
            {
                Background_Position = "",
                Background_Repeat = "",
                PaginaId = pag.Id,
                Nome = "plano de fundo da pagina",
                 ImagemId = 1
            };

                Background back2 = new BackgroundImagem
                {
                    Background_Position = "",
                    Background_Repeat = "",
                    PaginaId = pag.Id,
                    Nome = "topo",
                    ImagemId = 2
                };


                Background back3 = new BackgroundImagem
                {
                    Background_Position = "",
                    Background_Repeat = "",
                    PaginaId = pag.Id,
                    Nome = "menu",
                     ImagemId = 3
                };

                Background back4 = new BackgroundCor
                {
                    backgroundTransparente = true,
                    PaginaId = pag.Id,
                    Cor = "#000000",
                    Nome = "borda esquerda"
                     
                };

                Background back5 = new BackgroundCor
                {
                    backgroundTransparente = true,
                    PaginaId = pag.Id,
                    Cor = "#000000",
                    Nome = "borda direita"
                };

                Background back6 = new BackgroundCor
                {
                    backgroundTransparente = true,
                    PaginaId = pag.Id,
                    Cor = "#000000",
                    Nome = "blocos"
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
