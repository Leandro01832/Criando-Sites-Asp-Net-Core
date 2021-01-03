using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuProjetoAgora.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }

        public UserManager<IdentityUser> UserManager { get; }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Admin()
        {
            var usuario = await UserManager.GetUserAsync(this.User);

            var pedidos = await _context.Pedido
                .Include(p => p.Paginas)
                .ThenInclude(p => p.Div)
                .ThenInclude(p => p.Div)
                .ThenInclude(p => p.Elemento)
                .ThenInclude(p => p.Elemento)
                .ThenInclude(p => p.Despendentes)
                .ThenInclude(p => p.ElementoDependente)
                .ThenInclude(p => p.Dependente)
                .Where(p => p.ClienteId == usuario.Id).ToListAsync();

            var lista = new List<DadoFormulario>();

            foreach(var site in pedidos)
            {
                foreach (var pagina in site.Paginas)
                {
                    foreach (var div in pagina.Div)
                    {
                        foreach (var elemento in div.Div.Elemento)
                        {
                            if (elemento.Elemento.GetType().Name == "Formulario")
                            {
                                var dados = await _context.DadoFormulario
                                .Where(df => df.Formulario == elemento.Elemento.IdElemento)
                                .ToListAsync();
                                lista.AddRange(dados);
                            }
                        }
                    }
                }
            }

            ViewBag.dados = lista;

            return View();
        }

        [HttpPost]
        [Authorize(Roles="Admin")]
        public async Task<JsonResult> SalvarDados(int Id, string Videos, string Texto, string Imagem, string Carousel, string Background,
            string Music, string Link, string Div, string Elemento, string Pagina, string Ecommerce)
        {
            
            var users = UserManager.Users.ToList();
            var permissoes = _context.Permissao.Where(t => t.Site == Id && t.NomePermissao != "Admin").ToList();

            foreach (var permissao in permissoes)
            {
                _context.Permissao.Remove(permissao);
              await  _context.SaveChangesAsync();
            }

            try
            {
              await  SalvarPermissaoAsync(Videos, Id, "Video");
              await  SalvarPermissaoAsync(Texto, Id, "Texto");
              await  SalvarPermissaoAsync(Imagem, Id, "Imagem");
              await  SalvarPermissaoAsync(Carousel, Id, "Carousel");
              await  SalvarPermissaoAsync(Background, Id, "Background");
              await  SalvarPermissaoAsync(Music, Id, "Music");
              await  SalvarPermissaoAsync(Link, Id, "Link");
              await  SalvarPermissaoAsync(Div, Id, "Div");
              await  SalvarPermissaoAsync(Elemento, Id, "Elemento");
              await  SalvarPermissaoAsync(Pagina, Id, "Pagina");
              await  SalvarPermissaoAsync(Ecommerce, Id, "Ecommerce");
            }
            catch (Exception ex)
            {
                var erro = "Preencha o formulario corretamente" + ex;
                return Json("");
            }

            return Json("Valor");
        }

        public async Task SalvarPermissaoAsync(string perm, int Site, string permissao)
        {
            var users = UserManager.Users.ToList();
            var str = perm.Replace(" ", "").Split(',');
            for (int i = 0; i < str.Length; i++)
            {
                var user = users.FirstOrDefault(u => u.UserName == str[i]);
                if (user != null)
                {
                    if ( !await UserManager.IsInRoleAsync(user, permissao))
                    {
                      await  UserManager.AddToRoleAsync(user, permissao);
                    }
                    _context.Permissao.Add(new Permissao { NomePermissao = permissao, Site = Site, UserName = str[i] });
                    _context.SaveChanges();
                }
            }

        }

        [Authorize(Roles="Admin")]
        public async Task<ActionResult> EditPermissao(int id)
        {
            var site = _context.Pagina.First(p => p.IdPagina == id).pedido_;
            var usuario = await UserManager.GetUserAsync(this.User);
            var email = usuario.UserName;
            if (_context.Permissao.FirstOrDefault(p => p.Site == site
            && p.UserName == email && p.NomePermissao == "Admin") == null)
            {
                return RedirectToAction("Account", "Login", null);
            }

            var stringVideos = MontarString(site, "Video");
            var stringTexto = MontarString(site, "Texto");
            var stringImagem = MontarString(site, "Imagem");
            var Carousel = MontarString(site, "Carousel");
            var Background = MontarString(site, "Background");
            var Music = MontarString(site, "Music");
            var Link = MontarString(site, "Link");
            var Div = MontarString(site, "Div");
            var Elemento = MontarString(site, "Elemento");
            var Pagina = MontarString(site, "Pagina");
            var Ecommerce = MontarString(site, "Ecommerce");

            ViewBag.Videos = stringVideos;
            ViewBag.Texto = stringTexto;
            ViewBag.Imagem = stringImagem;
            ViewBag.Carousel = Carousel;
            ViewBag.Background = Background;
            ViewBag.Music = Music;
            ViewBag.Link = Link;
            ViewBag.Div = Div;
            ViewBag.Elemento = Elemento;
            ViewBag.Pagina = Pagina;
            ViewBag.Ecommerce = Ecommerce;
            ViewBag.site = site;

            return PartialView();
        }

        public string MontarString(int site, string permisssao)
        {
            var valor = "";
            var lista = _context.Permissao.Where(p => p.NomePermissao == permisssao && p.Site == site).ToList();
            foreach (var item in lista)
            {
                valor += item.UserName + ", ";
            }

            return valor;
        }
    }
}