using business.ecommerce;
using CMS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class InfoVendaController : Controller
    {
        public ApplicationDbContext db { get; }
        public UserManager<IdentityUser> UserManager { get; }

        public InfoVendaController(ApplicationDbContext Db, UserManager<IdentityUser> userManager)
        {
            db = Db;
            UserManager = userManager;
        }
        
        public ActionResult CadastrarCpf()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> CadastrarCpf([FromBody] InfoVenda info)
        {
            var usuario = await UserManager.GetUserAsync(this.User);
            var id = usuario.Id;
            info.ClienteId = id;

            await db.InfoVenda.AddAsync(info);
            await db.SaveChangesAsync(); 
            return "Cadastro realizado com sucesso!!!";
        }
        
        public ActionResult CadastrarInfoEntrega()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> CadastrarInfoEntrega([FromBody] InfoEntrega info)
        {
            var usuario = await UserManager.GetUserAsync(this.User);
            var id = usuario.Id;
            info.ClienteId = id;

            await db.InfoEntrega.AddAsync(info);
            await db.SaveChangesAsync();


            return "Cadastro realizado com sucesso!!!";
        }

        
        public ActionResult CadastrarContaBancaria()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> CadastrarContaBancaria([FromBody] ContaBancaria info)
        {
            var usuario = await UserManager.GetUserAsync(this.User);
            var id = usuario.Id;
            info.ClienteId = id;

            await db.ContaBancaria.AddAsync(info);
            await db.SaveChangesAsync();


            return "Cadastro feito com sucesso!!!";
        }        

    }
}
