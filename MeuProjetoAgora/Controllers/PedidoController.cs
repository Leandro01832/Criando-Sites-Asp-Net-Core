﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeuProjetoAgora.business;
using MeuProjetoAgora.Models.Repository;
using NVelocity.App;
using System.Text;
using NVelocity;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using MeuProjetoAgora.Data;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Hosting.Internal;
using RestSharp;

namespace MeuProjetoAgora.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ApplicationDbContext Context;

        public IRepositoryPedido RepositoryPedido { get; }
        public IRepositoryPagina RepositoryPagina { get; }
        public IHttpHelper HttpHelper { get; }
        public IRepositoryBackground RepositoryBackground { get; }
        public IHttpContextAccessor ContextAccessor { get; }
        public IUserHelper UserHelper { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public HostingEnvironment HostingEnvironment;

        public PedidoController(ApplicationDbContext context, IRepositoryPedido repositoryPedido,
            IRepositoryPagina repositoryPagina, IHttpHelper httpHelper,
            IRepositoryBackground repositoryBackground, IHttpContextAccessor contextAccessor,
            IUserHelper userHelper, HostingEnvironment hostingEnvironment,
            UserManager<IdentityUser> userManager
            )
        {
            HostingEnvironment = hostingEnvironment;
            Context = context;
            RepositoryPedido = repositoryPedido;
            RepositoryPagina = repositoryPagina;
            HttpHelper = httpHelper;
            RepositoryBackground = repositoryBackground;
            ContextAccessor = contextAccessor;
            UserHelper = userHelper;
            UserManager = userManager;
        }
        
        [Route("Carousel")]
        [Route("Carrossel")]
        [Route("Pages")]
        [Route("Paginas")]
        [Route("Index")]
        [Route("")]        
        public async Task<IActionResult> Index()
        {
            IList<Pagina> pages = await RepositoryPagina.MostrarPageModels();
            List<Pagina> pages2 = new List<Pagina>();
            foreach (var p in pages.Where(p => p.Exibicao == true))
            {
              p.Html = await RepositoryPagina.renderizarPagina(p);
                pages2.Add(p);
            }

            return View(pages2);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            var pedido = await Context.Pedido.FirstAsync(p => p.IdPedido == id);

            return PartialView(pedido);
        }

        [Route("Criar")]
        [Route("Create")]
        [Route("Cadastrar")]
        [Route("Inserir")]
        [Route("ViewCreate")]
        public IActionResult ViewCreate()
        {
            return View();
        }       
        
        [Authorize]
        [Route("Criar-Site")]
        [Route("Create-Site")]
        [Route("Cadastrar-Site")]
        [Route("Inserir-Site")]
        [Route("Pedido/Create")]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [Route("Criar-Site")]
        [Route("Create-Site")]
        [Route("Cadastrar-Site")]
        [Route("Inserir-Site")]
        [Route("Pedido/Create")]
        public async Task<IActionResult> Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.Datapedido = DateTime.Now;
                var usuario = await UserManager.GetUserAsync(this.User);

                try
                {
                    pedido.ClienteId = usuario.Id;
                    pedido.DiasLiberados = 7;

                    Context.Add(pedido);
                    await Context.SaveChangesAsync();
                    HttpHelper.SetPedidoId(pedido.IdPedido);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null &&
                  ex.InnerException.Message.Contains("IX_Pedido_DominioTemporario"))
                    {
                        ModelState.AddModelError(string.Empty, $"Não é possível escolher este dominio. Escolha outro dominio que seja diferente de {pedido.DominioTemporario}.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    return View(pedido);
                }

                await RepositoryPedido.PermissoesDoSite(pedido, usuario);

                return RedirectToAction(nameof(GaleriaSite), new { email = usuario.UserName });
            }
            return View(pedido);
        }
        
        [Authorize(Roles ="Admin")]
        [Route("Editar-Site/{id?}")]
        [Route("EditarSite/{id?}")]
        [Route("Edit-Site/{id?}")]
        [Route("EditSite/{id?}")]
        [Route("Alterar-Site/{id?}")]
        [Route("AlterarSite/{id?}")]
        [Route("Pedido/Edit/{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await Context.Pedido.Include(p => p.Servico)
                .FirstOrDefaultAsync(p => p.IdPedido == id);

            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        [Route("Editar-Site/{id?}")]
        [Route("EditarSite/{id?}")]
        [Route("Edit-Site/{id?}")]
        [Route("EditSite/{id?}")]
        [Route("Alterar-Site/{id?}")]
        [Route("AlterarSite/{id?}")]
        [Route("Pedido/Edit/{id?}")]
        public async Task<IActionResult> Edit(Pedido pedido)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(pedido);
                    await Context.SaveChangesAsync();
                }

                catch (Exception ex)
                {
                    if (ex.InnerException != null &&
                  ex.InnerException.Message.Contains("IX_Pedido_DominioTemporario"))
                    {
                        ModelState.AddModelError(string.Empty, $"Não é possível escolher este dominio. Escolha outro dominio que seja diferente de {pedido.DominioTemporario}.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    return View(pedido);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        } 
        
        [Route("Galeria/{id?}")]
        [Route("Pedido/Galeria/{id?}")]
        [Route("Paginas-de-um-site/{id?}")]
        [Route("Paginas-do-site/{id?}")]
        [Route("Paginas/{id?}")]
        public async Task<ActionResult> Galeria(int? id)
        {
            if (id == null) return View("Index");
            var paginas = await Context.Pagina.Where(p => p.pedido_ == id).ToListAsync();
            return View(paginas);
        }

        [Route("Sites/{email}")]
        [Route("GaleriaSite/{email}")]
        [Route("Pedido/GaleriaSite/{email}")]
        public async Task<ActionResult> GaleriaSite(string email)
        {
            var usuario = await UserManager.Users.FirstOrDefaultAsync(user => user.UserName == email);
            if (usuario == null) return View("Index");
            var sites = await Context.Pedido.Where(c => c.ClienteId == usuario.Id).ToListAsync();
            return View(sites);
        }

        [Authorize(Roles = "Admin")]
        public async Task<FileResult> Baixar(int id)
            {
            var site = await Context.Pedido.Include(p => p.Paginas).FirstAsync(p => p.IdPedido == id);

            var finalResult = RepositoryPagina.FazerDownload(site);

            return File(finalResult, "application/zip", site.DominioTemporario);

            }
        
        [Authorize]
        [Route("Pedido/CreatePagina")]
        [Route("CreatePage")]
        [Route("Criar-Pagina")]
        [Route("CriarPagina")]
        public async Task<ActionResult> CreatePagina()
        {
            var usuario = await UserManager.GetUserAsync(this.User);
            var sites = await  Context.Pedido.Where(c => c.ClienteId == usuario.Id).ToListAsync();   

            ViewBag.pedido_ = new SelectList(sites, "IdPedido", "Nome");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [Route("Pedido/CreatePagina")]
        [Route("CreatePage")]
        [Route("Criar-Pagina")]
        [Route("CriarPagina")]
        public async Task<ActionResult> CreatePagina(Pagina pagina)
        {
            var usuario = await UserManager.GetUserAsync(this.User);
            var sites = await Context.Pedido.Where(c => c.ClienteId == usuario.Id).ToListAsync();

            if (ModelState.IsValid)
            {
                HttpHelper.SetPedidoId(pagina.pedido_);
                var pag = RepositoryPagina.LinksPagina(pagina);

                pagina.Margem = true;
                pagina.Rotas = "";
              await  Context.Pagina.AddAsync(pagina);
                await  Context.SaveChangesAsync();

               await RepositoryBackground.CriarBackground(pagina, await Context.Imagem.Where(i => i.IdElemento <= 3).ToListAsync());              

                return RedirectToAction("Galeria", new { id = pagina.pedido_ });
            }


            ViewBag.pedido_ = new SelectList(sites, "IdPedido", "Nome", pagina.pedido_);
            return View(pagina);
        }

        [Route("Buscar/{dominio}/{extensao}")]
        public IActionResult Buscar(string dominio, string extensao)
        {
            if(dominio.Contains(' ') || dominio == null)
            {
                ViewBag.erro = "Não pode haver espaços no dominio e dominio não pode ser vazio";
                return View("Create");
            }
            dominio.Replace("www.", "");
            dominio.Replace(".", "");
            dominio.Replace("https://", "");
            dominio.Replace("http://", "");
            var client = new RestClient($"https://api.promptapi.com/whois/check?domain={dominio}{extensao}");
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddHeader("apikey", "8x2bc41bcJxbKJnIY8OJAIc6ws4fc3xU");

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            if (response.Content.Contains("registered"))
            {
                ViewBag.negativo = "este dominio não esta disponível";
                RepositoryPedido.SalvarDominioExistente(dominio + extensao);
            }
            else
            {
                ViewBag.positivo = "este dominio esta disponível";
            }

            return View("Create");
        }

        private bool PedidoExists(int id)
        {
            return Context.Pedido.Any(e => e.IdPedido == id);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
    }
}
