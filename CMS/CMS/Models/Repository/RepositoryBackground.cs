using business.Back;
using business.business;
using business.business.Elementos;
using business.business.Elementos.imagem;
using CMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public interface IRepositoryBackground
    {
        Task CriarBackground(Pagina pagina, List<Imagem> imagem);
        Task<BackgroundImagem> GetBabckgroundImagem(int Id);
        
    }

    public class RepositoryBackground : BaseRepository<Background>, IRepositoryBackground
    {
        public RepositoryBackground(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {
        }

        

        public async Task CriarBackground(Pagina pag, List<Imagem> imagens)
        {
            Pedido ped = await contexto.Pedido.Include(p => p.Paginas).FirstAsync(p => p.Id == pag.PedidoId);
            bool condicao = ped.Paginas.Count > 1;            

            if (!condicao)
            {
                Background back1 = new BackgroundImagem
                {
                    Background_Position = "",
                    Background_Repeat = "repeat",
                    Imagem = imagens[0],
                    ImagemId = imagens[0].Id,
                    Nome = "plano de fundo da pagina"
                };

                Background back2 = new BackgroundImagem
                {
                    Background_Position = "",
                    Background_Repeat = "repeat",
                    Imagem = imagens[1],
                    ImagemId = imagens[1].Id,
                    Nome = "topo"
                };

                Background back3 = new BackgroundImagem
                {
                    Background_Position = "",
                    Background_Repeat = "repeat",
                    Imagem = imagens[2],
                    ImagemId = imagens[2].Id,
                    Nome = "menu"
                };

                Background back4 = new BackgroundCor
                {
                    backgroundTransparente = true,
                    Cor = "transparent",
                    Nome = "blocos"
                };

                Background back5 = new BackgroundCor
                {
                    backgroundTransparente = true,
                    Cor = "transparent",
                    Nome = "borda esquerda"
                };

                Background back6 = new BackgroundCor
                {
                    backgroundTransparente = true,
                    Cor = "transparent",
                    Nome = "borda direita"
                };

                await dbSet.AddAsync(back1);
                await dbSet.AddAsync(back2);
                await dbSet.AddAsync(back3);
                await dbSet.AddAsync(back4);
                await dbSet.AddAsync(back5);
                await dbSet.AddAsync(back6);

                await contexto.SaveChangesAsync();
            }

                           
        }

        public async Task<BackgroundImagem> GetBabckgroundImagem(int id)
        {
            return await dbSet.OfType<BackgroundImagem>().Include(b => b.Imagem).FirstAsync(b => b.Id == id);
        }
    }
}
