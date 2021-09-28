using CMS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models.Repository
{
    public interface IUserHelper
    {
        Task<bool> DeleteUserAsync(string username);
        Task<bool> UpdateUserAsync(string currentusername, string newUserName);
        Task CheckRoleAsync(string roleName);
         Task CheckSuperUserAsync();
        Task CreateUserASPAsync(string email, string roleName);
        Task CreateUserASPAsync(string email, string roleName, string password);
        Task<bool> VerificarPermissao(int? site, string roles, string elemento);
        Task<bool> VerificarPermissao2(int? site, string email, string condicao, string elemento);
        Task<bool> VerificarPermissaoSite(int id);
        Task<bool> VerificarPermissaoDiv(int? id);
    }

    public class UserHelper : IUserHelper
    {

        public ApplicationDbContext userContext { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }
        public IConfiguration Configuration { get; }

        public UserHelper(ApplicationDbContext contexto, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            userContext = contexto;
            UserManager = userManager;
            RoleManager = roleManager;
            Configuration = configuration;
        }

        public async Task<bool> DeleteUserAsync(string username)
        {            
            var userASP = await UserManager.FindByEmailAsync(username);
            if (userASP != null)
            {
                var response = await UserManager.DeleteAsync(userASP);
                return response.Succeeded;
            }

            return false;
        }

        public async Task<bool> UpdateUserAsync(string currentusername, string newUserName)
        {
            var userASP = await UserManager.FindByEmailAsync(currentusername);
            if (userASP != null)
            {
                userASP.UserName = newUserName;
                userASP.Email = newUserName;
                var response = await UserManager.UpdateAsync(userASP);
                return response.Succeeded;
            }
            return false;
        }


        public async Task CheckRoleAsync(string roleName)
        {
            if (! await RoleManager.RoleExistsAsync(roleName))
            {
               await RoleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        public async Task CheckSuperUserAsync()
        {            
            var email = "leandroleanleo@gmail.com";
            var password = "M@nequim1991";
            var userASP = await UserManager.FindByNameAsync(email);
            if (userASP == null)
            {
               await UserManager.CreateAsync(new IdentityUser { UserName = email }, password);
                return;
            }

         await UserManager.AddToRoleAsync(userASP, "SuperAdmin");
        }

        public async Task CreateUserASPAsync(string email, string roleName)
        {            
            var users = UserManager.Users.ToList();
            var user = users.Find(u => u.UserName == email);            
          await  UserManager.AddToRoleAsync(user, roleName);
        }

        public async Task CreateUserASPAsync(string email, string roleName, string password)
        {
            var userASP = new IdentityUser
            {
                Email = email,
                UserName = email,
            };

           await UserManager.CreateAsync(userASP);
          await  UserManager.AddToRoleAsync(userASP, roleName);
        }

        public async Task<bool> VerificarPermissao(int? site, string roles, string elemento)
        {
            var pedido = await userContext.Pedido.FirstAsync(p => p.Id == site);

            if (!roles.Contains("Video") && elemento == "Video"
                || DateTime.Now > pedido.Datapedido.AddDays(pedido.DiasLiberados)) return false;
            if (!roles.Contains("Carousel") && elemento == "Carousel"
                || DateTime.Now > pedido.Datapedido.AddDays(pedido.DiasLiberados)) return false;
            if (!roles.Contains("Carousel") && elemento == "CarouselPagina"
                || DateTime.Now > pedido.Datapedido.AddDays(pedido.DiasLiberados)) return false;
            if (!roles.Contains("Imagem") && elemento == "Imagem"
                || DateTime.Now > pedido.Datapedido.AddDays(pedido.DiasLiberados)) return false;
            if (!roles.Contains("Texto") && elemento == "Texto"
                || DateTime.Now > pedido.Datapedido.AddDays(pedido.DiasLiberados)) return false;
            if (!roles.Contains("Ecommerce") && elemento == "Table" 
                || DateTime.Now > pedido.Datapedido.AddDays(pedido.DiasLiberados)) return false;
            if (!roles.Contains("Ecommerce") && elemento == "Produto" 
                || DateTime.Now > pedido.Datapedido.AddDays(pedido.DiasLiberados)) return false;
            if (!roles.Contains("Link") && elemento == "Link"
                || DateTime.Now > pedido.Datapedido.AddDays(pedido.DiasLiberados)) return false;
            if (!roles.Contains("Music") && elemento == "musica"
                || DateTime.Now > pedido.Datapedido.AddDays(pedido.DiasLiberados)) return false;
            if (!roles.Contains("Video") && elemento == "Video"
                || DateTime.Now > pedido.Datapedido.AddDays(pedido.DiasLiberados)) return false;
            if (!roles.Contains("Formulario") && elemento == "Formulario" 
                || DateTime.Now > pedido.Datapedido.AddDays(pedido.DiasLiberados)) return false;
            if (!roles.Contains("Formulario") && elemento == "Campo" 
                || DateTime.Now > pedido.Datapedido.AddDays(pedido.DiasLiberados)) return false;

            return true;
        }

        public async Task<bool> VerificarPermissao2(int? site, string email, string condicao, string elemento)
        {
            if (elemento == "Table" || elemento == "Produto")            
                condicao = "Ecommerce";            
            else if (elemento == "Campo")
                condicao = "Formulario";            
            else if (elemento == "CarouselPagina")            
                condicao = "Carousel";            
            else if (elemento == "Dropdown")            
                condicao = "Link";            
            else            
                condicao = elemento;            

            if (await userContext.Permissao.FirstOrDefaultAsync(p => p.Site == site
            && p.UserName == email && p.NomePermissao == condicao) == null)
            return false;
            return true;
        }

        public async Task<bool> VerificarPermissaoSite(int id)
        {
            var pagina = await userContext.Pagina
            .Include(p => p.Pedido)
            .FirstAsync(p => p.Id == id);

            if (DateTime.Now > pagina.Pedido.Datapedido.AddDays(pagina.Pedido.DiasLiberados)) return false;

            return true;
        }

        public async Task<bool> VerificarPermissaoDiv(int? id)
        {
            var div = await userContext.Div
                .FirstAsync(d => d.Id== id);

            var pagina = await userContext.Pagina
                .Include(p => p.Pedido)
                .FirstAsync(d => d.Id == div.Pagina_);

            if (DateTime.Now > pagina.Pedido.Datapedido.AddDays(pagina.Pedido.DiasLiberados)) return false;

            return true;
        }
    }

}
