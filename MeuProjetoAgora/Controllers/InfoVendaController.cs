using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MeuProjetoAgora.Controllers
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
