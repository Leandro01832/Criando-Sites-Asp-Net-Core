using business.business;
using business.business.element;
using business.Join;
using CMS.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public interface IRepositoryPedido
    {
        void SalvarDominioExistente(string v);
        Task PermissoesDoSite(Pedido pedido, IdentityUser usuario);
        IIncludableQueryable<Pedido, List<DivElemento>> includes();
    }

    public class RepositoryPedido : BaseRepository<Pedido>, IRepositoryPedido
    {
        public RepositoryPedido(IConfiguration configuration, ApplicationDbContext contexto,
            IRepositoryBackground repositoryBackground, IRepositoryDiv repositoryDiv,
            IHttpHelper httpHelper, IHostingEnvironment hostingEnvironment,
            IUserHelper userHelper) : base(configuration, contexto)
        {
            RepositoryBackground = repositoryBackground;
            RepositoryDiv = repositoryDiv;
            HttpHelper = httpHelper;
            HostingEnvironment = hostingEnvironment;
            UserHelper = userHelper;
        }

        public IRepositoryBackground RepositoryBackground { get; }
        public IRepositoryDiv RepositoryDiv { get; }
        public IHttpHelper HttpHelper { get; }
        public IHostingEnvironment HostingEnvironment { get; }
        public IUserHelper UserHelper { get; }

        string path = Directory.GetCurrentDirectory();
        public string Caminho { get { return Path.Combine(path + "/wwwroot/Caminho/"); } }

       

        public void SalvarDominioExistente(string v)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(
                Caminho + "dominios.txt", true))
            {
                sw.WriteLine(v);
                sw.Close();
            }
        }

        public async Task PermissoesDoSite(Pedido pedido, IdentityUser usuario)
        {
            await UserHelper.CreateUserASPAsync(usuario.UserName, "Video");
            await UserHelper.CreateUserASPAsync(usuario.UserName, "Texto");
            await UserHelper.CreateUserASPAsync(usuario.UserName, "Imagem");
            await UserHelper.CreateUserASPAsync(usuario.UserName, "Carousel");
            await UserHelper.CreateUserASPAsync(usuario.UserName, "Background");
            await UserHelper.CreateUserASPAsync(usuario.UserName, "Music");
            await UserHelper.CreateUserASPAsync(usuario.UserName, "Link");
            await UserHelper.CreateUserASPAsync(usuario.UserName, "Div");
            await UserHelper.CreateUserASPAsync(usuario.UserName, "Elemento");
            await UserHelper.CreateUserASPAsync(usuario.UserName, "Pagina");
            await UserHelper.CreateUserASPAsync(usuario.UserName, "Ecommerce");
            await UserHelper.CreateUserASPAsync(usuario.UserName, "Formulario");
            await UserHelper.CreateUserASPAsync(usuario.UserName, "Admin");
            await contexto.Permissao.AddAsync(new Permissao
            { NomePermissao = "Video", Site = pedido.Id, UserName = usuario.UserName });
            await contexto.Permissao.AddAsync(new Permissao
            { NomePermissao = "Texto", Site = pedido.Id, UserName = usuario.UserName });
            await contexto.Permissao.AddAsync(new Permissao
            { NomePermissao = "Imagem", Site = pedido.Id, UserName = usuario.UserName });
            await contexto.Permissao.AddAsync(new Permissao
            { NomePermissao = "Carousel", Site = pedido.Id, UserName = usuario.UserName });
            await contexto.Permissao.AddAsync(new Permissao
            { NomePermissao = "Background", Site = pedido.Id, UserName = usuario.UserName });
            await contexto.Permissao.AddAsync(new Permissao
            { NomePermissao = "Music", Site = pedido.Id, UserName = usuario.UserName });
            await contexto.Permissao.AddAsync(new Permissao
            { NomePermissao = "Link", Site = pedido.Id, UserName = usuario.UserName });
            await contexto.Permissao.AddAsync(new Permissao
            { NomePermissao = "Div", Site = pedido.Id, UserName = usuario.UserName });
            await contexto.Permissao.AddAsync(new Permissao
            { NomePermissao = "Elemento", Site = pedido.Id, UserName = usuario.UserName });
            await contexto.Permissao.AddAsync(new Permissao
            { NomePermissao = "Pagina", Site = pedido.Id, UserName = usuario.UserName });
            await contexto.Permissao.AddAsync(new Permissao
            { NomePermissao = "Ecommerce", Site = pedido.Id, UserName = usuario.UserName });
            await contexto.Permissao.AddAsync(new Permissao
            { NomePermissao = "Formulario", Site = pedido.Id, UserName = usuario.UserName });
            await contexto.Permissao.AddAsync(new Permissao
            { NomePermissao = "Admin", Site = pedido.Id, UserName = usuario.UserName });

            await contexto.SaveChangesAsync();
        }

        public IIncludableQueryable<Pedido, List<DivElemento>> includes()
        {
            var include = contexto.Pedido.Include(p => p.Paginas)
                .ThenInclude(p => p.Div)
                .ThenInclude(p => p.Div)
                .ThenInclude(p => p.Elemento)
                .Include(p => p.Paginas)
                .ThenInclude(p => p.Div)
                .ThenInclude(p => p.Pagina)
                .ThenInclude(p => p.Div)
                .ThenInclude(p => p.Div)
                .ThenInclude(p => p.Elemento);

            return include;
        }
    }
}
