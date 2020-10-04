using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryPedido
    {
        Task criarPedido(List<Imagem> imagens);
        void SalvarDominioExistente(string v);
    }

    public class RepositoryPedido : BaseRepository<Pedido>, IRepositoryPedido
    {
        public RepositoryPedido(IConfiguration configuration, ApplicationDbContext contexto,
            IRepositoryBackground repositoryBackground, IRepositoryDiv repositoryDiv,
            IHttpHelper httpHelper, IHostingEnvironment hostingEnvironment) : base(configuration, contexto)
        {
            RepositoryBackground = repositoryBackground;
            RepositoryDiv = repositoryDiv;
            HttpHelper = httpHelper;
            HostingEnvironment = hostingEnvironment;
        }

        public IRepositoryBackground RepositoryBackground { get; }
        public IRepositoryDiv RepositoryDiv { get; }
        public IHttpHelper HttpHelper { get; }
        public IHostingEnvironment HostingEnvironment { get; }
        string path = Directory.GetCurrentDirectory();
        public string Caminho { get { return Path.Combine(path + "/wwwroot/Caminho/"); } }

        public async Task criarPedido(List<Imagem> imagens)
        {
            var pedido = contexto.Pedido.FirstOrDefault(p => p.IdPedido == HttpHelper.GetPedidoId());
            if(pedido != null)
            {
                pedido.Paginas = new List<Pagina>();
                pedido.Paginas.Add(new Pagina
                {
                    Titulo = "Lixeira",
                    pedido_ = pedido.IdPedido,
                    Pastas = new List<PastaImagem>(),
                    Facebook = "vazio",
                    Instagram = "vazio",
                    Twiter = "vazio",
                    Pedido = pedido,
                    Margem = true
                });

              await  contexto.SaveChangesAsync();

              await  RepositoryBackground.CriarBackground(pedido.Paginas[0], imagens);
                RepositoryDiv.CriarBlocoLixeira(pedido);
            }
            
        }

        public void SalvarDominioExistente(string v)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(
                Caminho + "dominios.txt", true))
            {
                sw.WriteLine(v);
                sw.Close();
            }
        }
    }
}
