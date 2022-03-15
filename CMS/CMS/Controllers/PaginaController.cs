using business.business;
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

namespace MeuProjetoAgora.Controllers
{
    public class PaginaController : Controller
    {
        private readonly ApplicationDbContext db;
        public IRepositoryPedido RepositoryPedido { get; }
        public IRepositoryPagina epositoryPagina { get; }
        public IHttpHelper HttpHelper { get; }
        public IHttpContextAccessor ContextAccessor { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IUserHelper UserHelper { get; }


        public PaginaController(ApplicationDbContext context, IRepositoryPedido repositoryPedido,
            IRepositoryPagina repositoryPagina, IHttpHelper httpHelper, IHttpContextAccessor contextAccessor,
            UserManager<IdentityUser> userManager, IUserHelper userHelper)
        {
            db = context;
            RepositoryPedido = repositoryPedido;
            epositoryPagina = repositoryPagina;
            HttpHelper = httpHelper;
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
            var bloco = await db.DivElemento
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


        [Route("{story}/{id}")]
        public async Task<IActionResult> RenderizarDinamico(string story, int id)
        {
            var Story = story.Replace("Story-", "").Replace("-Pagina", "");

            ViewBag.story = Story;

            // var lista = Pagina.paginas;
            ViewBag.stories = db.Story.ToList();
            var lista = RepositoryPagina.paginas.Where(p => p.Story.Nome == Story).ToList();

            ViewBag.quantidadePaginas = lista.Count();

            if (id > 0)
            {
                Pagina pagina = lista.Skip((int)id - 1).FirstOrDefault();

                if (pagina == null || pagina.Id == 1) pagina = lista.Skip((int)id).FirstOrDefault();

                if (pagina == null)
                {
                    ViewBag.sites = new SelectList(await db.Pedido
                    .ToListAsync(), "IdPedido", "Nome");
                    ViewBag.paginas = new SelectList(new List<Pagina>(), "IdPedido", "Nome");
                    ViewBag.numeroErro = id;
                    return View("HttpNotFound");
                }
                else
                {
                    HttpHelper.SetPedidoId(pagina.PedidoId);
                    string html = await epositoryPagina.renderizarPaginaComMenuDropDown(pagina);
                    ViewBag.Html = html;
                    pagina.Html = html;
                }

                if (pagina.Id == 2)
                    ViewBag.proximo = 3;
                else
                    ViewBag.proximo = id + 1;
                return View(pagina);
            }
            return HttpNotFound();
        }

        [Route("Editar/{id?}")]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == 1) id = 2;

            var lista = await BuscarPaginas();
            Pagina pagina = lista.FirstOrDefault(p => p.Id == id);

            if (pagina == null)
            {
                ViewBag.sites = new SelectList(await db.Pedido
                .ToListAsync(), "Id", "Nome");
                ViewBag.paginas = new SelectList(new List<Pagina>(), "Id", "Nome");
                ViewBag.numeroErro = id;
                return View("HttpNotFound");
            }
            else
            {
                ViewBag.IdPagina = id;
                ViewBag.IdSite = pagina.PedidoId;
                HttpHelper.SetPedidoId(pagina.PedidoId);
                string html = await epositoryPagina.renderizarPaginaComCarousel(pagina);
                ViewBag.Html = html;
                pagina.Html = html;
            }

            ViewBag.proximo = id + 1;
            return View(pagina);
        }

        [AllowAnonymous]
        public async Task<ActionResult> GetView(int? id)
        {
            var lista = await BuscarPaginas();
            Pagina pagina = lista.FirstOrDefault(p => p.Id == id);

            if (pagina == null)
            {
                ViewBag.numeroErro = id;
                return View("HttpNotFound");
            }
            ViewBag.html = await epositoryPagina.renderizarPagina(pagina);

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
            if (dominio == null)
            {
                return RedirectToAction("Index", "Pedido", null);
            }

            Pagina pag = null;

            if (pagina != null)
            {
                var pedido = await RepositoryPedido.includes()
                .FirstOrDefaultAsync(p => p.DominioTemporario
                .ToLower()
                == dominio.ToLower());

                if (pedido != null)
                {
                    foreach (var p in pedido.Paginas)
                    {
                        var array = p.Rotas.Replace(" ", "").Split(',').ToList();

                        foreach (var v in array)
                        {
                            if (v.ToLower() == pagina.ToLower())
                            {
                                var lista = await BuscarPaginas();
                                pag = lista.FirstOrDefault(page => page.Id == p.Id);
                            }
                        }
                    }
                    if (pag == null)
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

            if (pag == null && !string.IsNullOrEmpty(pagina))
            {
                await db.Rota.AddAsync(new Rota { NomeRota = dominio + "/" + pagina });
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Pedido", null);
            }

            foreach (var div in pag.Div)
            {
                div.Div.Elemento = div.Div.Elemento.OrderBy(e => e.Elemento.Ordem).ToList();
            }

            string html = await epositoryPagina.renderizarPaginaComMenuDropDown(pag);
            ViewBag.html = html;
            pag.Html = html;
            epositoryPagina.criandoArquivoHtml(pag);
            return View(pag);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Salvar(int id)
        {
            var lista = await BuscarPaginas();
            RepositoryPagina.paginas.Clear();
            RepositoryPagina.paginas.AddRange(lista);
            Pagina pag = lista.FirstOrDefault(p => p.Id == id);

            epositoryPagina.criandoArquivoHtml(pag);
            ViewBag.html = epositoryPagina.renderizarPagina(pag);

            return Content("Salvo com sucesso");
        }

        public async Task<List<Pagina>> BuscarPaginas()
        {
            var lista = await epositoryPagina.MostrarPageModels();


            //foreach (var pag in lista.ToList())
            //{
            //    foreach (var div in pag.Div)
            //    {
            //        div.Div.Elemento = div.Div.Elemento.OrderBy(e => e.Elemento.Ordem).ToList();

            //        foreach (var elemento in div.Div.Elemento)
            //        {
            //            elemento.Elemento.Tipo = elemento.Elemento.GetType().Name;

            //            foreach (var dependente in elemento.Elemento.Despendentes)
            //            {
            //                dependente.Elemento.tipo = dependente.Elemento.GetType().Name;
            //            }
            //        }
            //    }
            //}

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

        public IActionResult HttpNotFound()
        {
            return View();
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
            ViewBag.PedidoId = new SelectList(sites, "Id", "Nome", pagina.PedidoId);
            ViewBag.StoryId = new SelectList(db.Story.ToList(), "Id", "Nome", pagina.StoryId);

            var site = pagina.Pedido.DominioTemporario;

            var rotas = db.Rota.Where(r => r.NomeRota.Contains(site)).ToList();
            var rotasPossiveis = "";
            foreach (var r in rotas)
            {
                if (!pagina.Rotas.Contains(r.NomeRota.Replace(site + "/", "")))
                    rotasPossiveis += r.NomeRota.Replace(site + "/", "") + ", ";
            }
            ViewBag.Rotas = rotasPossiveis;

            var elements = "";

            foreach (var ele in pagina.Div.Skip(6))
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

                    await epositoryPagina.BlocosdaPagina(Pagina);

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