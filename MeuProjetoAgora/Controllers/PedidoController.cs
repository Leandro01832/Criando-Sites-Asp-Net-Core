using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeuProjetoAgora.Models.business;
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
            foreach (var p in pages)
            {
              p.Html = RepositoryPagina.renderizarPagina(p);
            }

            return View(pages);
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
                    Context.Add(pedido);
                    await Context.SaveChangesAsync();
                    HttpHelper.SetPedidoId(pedido.IdPedido);
                    await RepositoryPedido.criarPedido(Context.Imagem.Where(i => i.IdImagem <= 3).ToList());
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
               await UserHelper.CreateUserASPAsync(usuario.UserName, "Admin");
               await Context.Permissao.AddAsync(new Permissao
                    { NomePermissao = "Video", Site = pedido.IdPedido, UserName = usuario.UserName });
               await Context.Permissao.AddAsync(new Permissao                             
                    { NomePermissao = "Texto", Site = pedido.IdPedido, UserName = usuario.UserName });
               await Context.Permissao.AddAsync(new Permissao                             
                   { NomePermissao = "Imagem", Site = pedido.IdPedido, UserName = usuario.UserName });
               await Context.Permissao.AddAsync(new Permissao                             
                 { NomePermissao = "Carousel", Site = pedido.IdPedido, UserName = usuario.UserName });
               await Context.Permissao.AddAsync(new Permissao                             
               { NomePermissao = "Background", Site = pedido.IdPedido, UserName = usuario.UserName });
               await Context.Permissao.AddAsync(new Permissao                             
                    { NomePermissao = "Music", Site = pedido.IdPedido, UserName = usuario.UserName });
               await Context.Permissao.AddAsync(new Permissao                             
                     { NomePermissao = "Link", Site = pedido.IdPedido, UserName = usuario.UserName });
               await Context.Permissao.AddAsync(new Permissao                             
                      { NomePermissao = "Div", Site = pedido.IdPedido, UserName = usuario.UserName });
               await Context.Permissao.AddAsync(new Permissao                             
                 { NomePermissao = "Elemento", Site = pedido.IdPedido, UserName = usuario.UserName });
               await Context.Permissao.AddAsync(new Permissao                             
                   { NomePermissao = "Pagina", Site = pedido.IdPedido, UserName = usuario.UserName });
               await Context.Permissao.AddAsync(new Permissao                             
                { NomePermissao = "Ecommerce", Site = pedido.IdPedido, UserName = usuario.UserName });
               await Context.Permissao.AddAsync(new Permissao                             
                    { NomePermissao = "Admin", Site = pedido.IdPedido, UserName = usuario.UserName });

               await Context.SaveChangesAsync();

                return RedirectToAction(nameof(Galeria));
            }
            return View(pedido);
        }
        
        [Authorize]
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
        [Authorize]
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
        
        [Authorize]
        [Route("Apagar-Site/{id?}")]
        [Route("Deletar-Site/{id?}")]
        [Route("Delete/{id?}")]
        [Route("Pedido/Delete/{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await Context.Pedido
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }
                
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        [Route("Apagar-Site/{id?}")]
        [Route("Deletar-Site/{id?}")]
        [Route("Delete/{id?}")]
        [Route("Pedido/DeleteConfirmed/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await Context.Pedido.FindAsync(id);
            Context.Pedido.Remove(pedido);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }               

        [Authorize]        
        [Route("Galeria/{id?}")]
        [Route("Pedido/Galeria/{id?}")]
        [Route("Paginas-de-um-site/{id?}")]
        [Route("Paginas-do-site/{id?}")]
        [Route("Paginas/{id?}")]
        public async Task<ActionResult> Galeria(int? id)
        {
            if(id == null)
            {
                id = HttpHelper.GetPedidoId();
            } 
            var paginas = await Context.Pagina.Where(p => p.pedido_ == id).ToListAsync();
            return View(paginas);
        }

        [Authorize]
        [Route("Sites")]
        [Route("GaleriaSite")]
        [Route("Pedido/GaleriaSite")]
        public async Task<ActionResult> GaleriaSite()
        {
            var usuario = await UserManager.GetUserAsync(this.User);            
            var sites = await Context.Pedido.Where(c => c.ClienteId == usuario.Id).ToListAsync();
            return View(sites);
        }

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
        public async Task<ActionResult> CreatePagina([Bind("PaginaId,Titulo,Codigo,pedido_,Facebook,Twiter,Instagram,Rotas")] Pagina pagina)
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

               await RepositoryBackground.CriarBackground(pagina, await Context.Imagem.Where(i => i.IdImagem <= 3).ToListAsync());              

                return RedirectToAction("Galeria");
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
