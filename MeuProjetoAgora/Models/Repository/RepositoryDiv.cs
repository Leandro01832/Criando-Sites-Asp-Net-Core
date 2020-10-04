using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.Join;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryDiv
    {
        void CriarBlocoLixeira(Pedido ped);
        Task<string> SalvarBloco(Div div);
        void EditarBloco(Div div);
    }

    public class RepositoryDiv : BaseRepository<Div>, IRepositoryDiv
    {
        public RepositoryDiv(IConfiguration configuration, ApplicationDbContext contexto) : base(configuration, contexto)
        {
        }

        public void CriarBlocoLixeira(Pedido ped)
        {
            ped.Paginas[0].Div = new List<Div>
                     {
                         new Div
                         {
                            Nome = "Lixeira",
                            Pagina = ped.Paginas[0],
                            PaginaId = ped.Paginas[0].IdPagina,
                            Video = new List<Video>(),
                            Textos = new List<Texto>(),
                            Carousel = new List<Carousel>(),
                            Imagem = new List<DivImagem>(),
                            Elemento = new List<Elemento>(),
                            background_ = ped.Paginas[0].Background.ToList()[2].IdBackground,
                            Background = ped.Paginas[0].Background.ToList()[2],
                            BorderRadius = 10,
                            Colunas = "auto auto auto auto auto auto auto auto auto auto auto auto",
                            Desenhado = 0,
                            Divisao = "col-md-12",
                            Padding = 5,
                            Height = 400
                         }
                     };
        }

        public void EditarBloco(Div div)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SalvarBloco(Div div)
        {
            Div Div = new Div();
                Div.Nome         = div.Nome;
                Div.PaginaId     = div.PaginaId;
                Div.background_  = div.background_;
                Div.Colunas      = "auto";
                Div.Height       = 200;
                Div.Divisao      = "col-md-12";
                Div.BorderRadius = 0;
                Div.Padding      = 5;
                Div.Desenhado    = 0;

            try
            {
                await dbSet.AddAsync(div);
                await contexto.SaveChangesAsync();
            }
            catch (Exception)
            {
                return "";
            }

            return $"Chave do Bloco: {div.IdDiv}";
        }
    }
}
