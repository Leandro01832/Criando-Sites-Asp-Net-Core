using business.business;
using business.business.element;
using CMS.Data;
using CMS.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    public class PaginaController : Controller
    {
        private readonly ApplicationDbContext db;       
        public IRepositoryPedido RepositoryPedido { get; }
        public IRepositoryPagina RepositoryPagina { get; }
        public IHttpHelper HttpHelper { get; }
        public IRepositoryBackground RepositoryBackground { get; }
        public IHttpContextAccessor ContextAccessor { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IUserHelper UserHelper { get; }

        public PaginaController(ApplicationDbContext context, IRepositoryPedido repositoryPedido,
            IRepositoryPagina repositoryPagina, IHttpHelper httpHelper,
            IRepositoryBackground repositoryBackground, IHttpContextAccessor contextAccessor,
            UserManager<IdentityUser> userManager, IUserHelper userHelper)
        {
            db = context;
            RepositoryPedido = repositoryPedido;
            RepositoryPagina = repositoryPagina;
            HttpHelper = httpHelper;
            RepositoryBackground = repositoryBackground;
            ContextAccessor = contextAccessor;
            UserManager = userManager;
            UserHelper = userHelper;
        }

        [AllowAnonymous]
        public ActionResult EmBranco()
        {            
            return PartialView();
        }

        [AllowAnonymous]
        public async Task<ActionResult> QuantidadeBloco(int div)
        {
            var bloco = await  db.DivElemento
                .Include(de => de.Elemento)
                .Include(de => de.Div)
                .Where(d => d.Div.Id == div).ToListAsync();

            ViewBag.Quantidade = bloco.Count;
            return PartialView();
        }

        [AllowAnonymous]
        public async Task<ActionResult> IdentificacaoBloco(int div)
        {
            var bloco = await db.DivElemento
                .Include(de => de.Elemento)
                .Include(de => de.Div)
                .Where(d => d.Div.Id == div).ToListAsync();

            ViewBag.Quantidade = bloco.Count;
            ViewBag.id = div;
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult IdentificacaoElemento(int elemento)
        {
            ViewBag.id = elemento;
            return PartialView();
        }        

        [Route("Pagina/RenderizarDinamico/{id?}")]
        [Route("Alterar/{id?}")]
        [Route("Configurar/{id?}")]
        [Route("Renderizar/{id?}")]
        [Route("Mostrar/{id?}")]
        [Route("Pagina/{id?}")]
        public async Task<IActionResult> RenderizarDinamico(int? id)
        {
            var lista = await BuscarPaginas();
            Pagina pagina = lista.FirstOrDefault(p => p.Id == id);

            if (pagina == null)
            {
                ViewBag.sites = new SelectList( await db.Pedido
                .ToListAsync(), "Id", "Nome");
                ViewBag.paginas = new SelectList(new List<Pagina>(), "Id", "Nome");
            }
            else
            {
                HttpHelper.SetPedidoId(pagina.PedidoId);
                string html = await RepositoryPagina.renderizarPaginaComCarousel(pagina);
                ViewBag.Html = html;
                pagina.Html = html;


            }            

            return View(pagina);
        }

        [AllowAnonymous]
        public async Task<ActionResult> GetView(int? id)
        {
            var lista = await BuscarPaginas();
            Pagina pagina = lista.FirstOrDefault(p => p.Id == id);

            if (pagina == null)
            {
                return HttpNotFound();
            }
            ViewBag.html = await RepositoryPagina.renderizarPagina(pagina);

            return PartialView("GetView");
        }

        [Route("-/{dominio}/{pagina}")]
        [Route("*/{dominio}/{pagina}")]
        [Route("Site/{dominio}/{pagina}")]
        [Route("Site/{dominio}/")]
        [Route("*/{dominio}/")]
        [Route("-/{dominio}/")]
        public async Task<ActionResult> Site(string dominio, string pagina)
        {
            if(dominio == null)
            {
                return RedirectToAction("Index", "Pedido", null);
            }

            Pagina pag = null;

            if (pagina != null)
            {
                var pedido = await  RepositoryPedido.includes()
                .FirstOrDefaultAsync(p => p.DominioTemporario
                .ToLower()
                == dominio.ToLower());

                if(pedido != null)
                {
                    foreach (var p in pedido.Paginas)
                    {
                        var array = p.Rotas.Replace(" ", "").Split(',').ToList();

                        foreach(var v in array)
                        {
                            if(v.ToLower() == pagina.ToLower())
                            {
                                var lista = await BuscarPaginas();
                                pag = lista.FirstOrDefault(page => page.Id == p.Id);
                            }
                        }
                    }
                    if(pag == null)
                    {
                        var lista = await BuscarPaginas();
                        pagina = RemoveAccents(pagina);
                        pag = lista
                        .FirstOrDefault(p => p.Pedido.DominioTemporario
                        .ToLower()
                        == dominio.ToLower() && RemoveAccents(p.Titulo)
                        .Replace(" ", "")
                        .ToLower()
                        == pagina.ToLower());
                    }
                }              
                
            }

            if (pagina == null)
            {
                try
                {
                    var lista2 = await BuscarPaginas();
                    var lista = lista2
                    .Where(p => RemoveAccents(p.Pedido.DominioTemporario) 
                    .Replace(" ", "")
                    .Replace("www", "")
                    .Replace(".com", "")
                    .Replace(".com.br", "")                    
                    == dominio).ToList();
                    pag = lista[1];
                }
                catch (Exception)
                {
                    await db.Rota.AddAsync(new Rota { NomeRota = dominio });
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "Pedido", null);
                }
            }

            if(pag == null && !string.IsNullOrEmpty(pagina))
            {
                await db.Rota.AddAsync(new Rota { NomeRota = dominio + "/" + pagina });
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Pedido", null);
            }

            foreach (var div in pag.Div)
            {
                div.Div.Elemento = div.Div.Elemento.OrderBy(e => e.Elemento.Ordem).ToList();
            }

            string html = await RepositoryPagina.renderizarPaginaComMenuDropDown(pag);
            ViewBag.html = html;
            pag.Html = html;
            RepositoryPagina.criandoArquivoHtml(pag);
            return View(pag);            
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Salvar(int id)
        {
            var lista = await BuscarPaginas();
            Pagina pag = lista.FirstOrDefault(p => p.Id == id);

            RepositoryPagina.criandoArquivoHtml(pag);
            ViewBag.html = RepositoryPagina.renderizarPagina(pag);

            return Content("Salvo com sucesso");
        }

        public async Task<List<Pagina>> BuscarPaginas()
        {
            var lista = await RepositoryPagina.MostrarPageModels();
          

            foreach (var pag in lista.ToList())
            {
                foreach (var div in pag.Div)
                {
                    div.Div.Elemento = div.Div.Elemento.OrderBy(e => e.Elemento.Ordem).ToList();
                }
            }

            return lista.ToList();
        }        

        public string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Pagina")]
        public async Task<IActionResult> EditarPagina(int id)
        {
            bool permissao = await UserHelper.VerificarPermissaoSite(id);
            if (!permissao)
            {
                return PartialView("NoPermission");
            }

            var pagina = db.Pagina
            .Include(p => p.Pedido)
            .Include(p => p.Div)
            .ThenInclude(p => p.Div)
            .First(p => p.Id == id);
            var usuario = await UserManager.GetUserAsync(this.User);
            var sites = await db.Pedido.Where(c => c.ClienteId == usuario.Id).ToListAsync();
            ViewBag.pedido_ = new SelectList(sites, "Id", "Nome", pagina.Id);

            var site = pagina.Pedido.DominioTemporario;

            var rotas = db.Rota.Where(r => r.NomeRota.Contains(site)).ToList();
            var rotasPossiveis = "";
            foreach(var r in rotas)
            {
                if(!pagina.Rotas.Contains(r.NomeRota.Replace(site + "/", "")))
                rotasPossiveis += r.NomeRota.Replace(site + "/", "") + ", ";
            }
            ViewBag.Rotas = rotasPossiveis;

            var elements = "";

            foreach (var ele in pagina.Div)
            {
                elements += ele.Div.Id.ToString() + ", "; 
            }

            ViewBag.elementos = elements;
            return PartialView(pagina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Pagina")]
        public async Task<string> EditarPagina([FromBody]Pagina pagina)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(pagina);
                    await db.SaveChangesAsync();

                    var Pagina = await db.Pagina
                        .Include(p => p.Div)
                        .ThenInclude(p => p.Div)
                        .FirstAsync(p => p.Id == pagina.Id);

                    await RepositoryPagina.BlocosdaPagina(Pagina);

                }
                catch (Exception ex)
                {
                    return "Erro!!!" + ex.Message;

                }
                return "";
            }
            return "Erro!!!";
        }

        public IActionResult NoPermission()
        {
            return PartialView();
        }
    }
}