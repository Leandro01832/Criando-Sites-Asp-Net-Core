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
        public async Task<JsonResult> CadastrarCpf(string Cpf)
        {
            var usuario = await UserManager.GetUserAsync(this.User);

            var id = usuario.Id;            

            InfoVenda info = new InfoVenda
            {
                ClienteId = id,
                 Cpf = Cpf                  
            };

                await db.InfoVenda.AddAsync(info);
                await db.SaveChangesAsync();
            

            return Json("Cadastro realizado com sucesso!!!");
        }

        
        public ActionResult CadastrarInfoEntrega()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CadastrarInfoEntrega(int? AlturaCaixa, string CidadesEntrega,
            int? ComprimentoCaixa, bool entregaCorreio, string EstadosEntrega, int? LarguraCaixa,
            int? PesoCaixa, decimal? ValorFrete)
        {
            var usuario = await UserManager.GetUserAsync(this.User);
            var id = usuario.Id;

            InfoEntrega info = new InfoEntrega
            {
                AlturaCaixa = AlturaCaixa,
                CidadesEntrega = CidadesEntrega,
                ComprimentoCaixa = ComprimentoCaixa,
                entregaCorreio = entregaCorreio,
                EstadosEntrega = EstadosEntrega,
                ClienteId = id,
                LarguraCaixa = LarguraCaixa,
                PesoCaixa = PesoCaixa,
                ValorFrete = ValorFrete
            };

            await db.InfoEntrega.AddAsync(info);
            await db.SaveChangesAsync();


            return Json("Cadastro realizado com sucesso!!!");
        }

        
        public ActionResult CadastrarContaBancaria()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CadastrarContaBancaria(string Agencia, string CodigoBanco,
            string Conta, string DVAgencia, string DVConta, string TipoConta)
        {
            var usuario = await UserManager.GetUserAsync(this.User);
            var id = usuario.Id;

            ContaBancaria info = new ContaBancaria
            {
                ClienteId = id,
                Agencia = Agencia,
                CodigoBanco = CodigoBanco,
                Conta = Conta,
                DVAgencia = DVAgencia,
                DVConta = DVConta,
                TipoConta = TipoConta

            };

            await db.ContaBancaria.AddAsync(info);
            await db.SaveChangesAsync();


            return Json("Cadastro feito com sucesso!!!");
        }
        

    }
}
