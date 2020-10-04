using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MeuProjetoAgora.Controllers
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

        public PaginaController(ApplicationDbContext context, IRepositoryPedido repositoryPedido,
            IRepositoryPagina repositoryPagina, IHttpHelper httpHelper,
            IRepositoryBackground repositoryBackground, IHttpContextAccessor contextAccessor,
            UserManager<IdentityUser> userManager)
        {
            db = context;
            RepositoryPedido = repositoryPedido;
            RepositoryPagina = repositoryPagina;
            HttpHelper = httpHelper;
            RepositoryBackground = repositoryBackground;
            ContextAccessor = contextAccessor;
            UserManager = userManager;
        }

        [AllowAnonymous]
        public ActionResult EmBranco()
        {            
            return PartialView();
        }

        [AllowAnonymous]
        public async Task<ActionResult> QuantidadeBloco(int div)
        {
            var bloco = await  db.Div
                .Include(d => d.Carousel)
                .Include(d => d.Pagina.Pastas)
                .Include(d => d.Link)
                .Include(d => d.form)
                .Include(d => d.Tabelas)
                .Include(d => d.Video)
                .Include(d => d.Textos)
                .FirstAsync(d => d.IdDiv == div);

            ViewBag.Quantidade = bloco.Carousel.Count + bloco.Pagina.Pastas.Count + bloco.Link.Count +
                bloco.form.Count + bloco.Tabelas.Count + bloco.Video.Count + bloco.Textos.Count;
            return PartialView();
        }

        [AllowAnonymous]
        public async Task<ActionResult> IdentificacaoBloco(int div)
        {
            var bloco = await db.Div
                .Include(d => d.Carousel)
                .Include(d => d.Pagina.Pastas)
                .Include(d => d.Link)
                .Include(d => d.form)
                .Include(d => d.Tabelas)
                .Include(d => d.Video)
                .Include(d => d.Textos)
                .FirstAsync(d => d.IdDiv == div);

            ViewBag.Quantidade = bloco.Carousel.Count + bloco.Pagina.Pastas.Count + bloco.Link.Count +
                bloco.form.Count + bloco.Tabelas.Count + bloco.Video.Count + bloco.Textos.Count;
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
            Pagina pagina = lista.FirstOrDefault(p => p.IdPagina == id);

            if (pagina == null)
            {
                ViewBag.sites = new SelectList( await db.Pedido
                .ToListAsync(), "IdPedido", "Nome");
                ViewBag.paginas = new SelectList(new List<Pagina>(), "IdPedido", "Nome");
            }
            else
            {
                HttpHelper.SetPedidoId(pagina.pedido_);
                string html = RepositoryPagina.renderizarPaginaComCarousel(pagina);
                ViewBag.Html = html;
                pagina.Html = html;
               
            }            

            return View(pagina);
        }

        [AllowAnonymous]
        public async Task<ActionResult> GetView(int? id)
        {
            var lista = await BuscarPaginas();
            Pagina pagina = lista.FirstOrDefault(p => p.IdPagina == id);

            if (pagina == null)
            {
                return HttpNotFound();
            }
            ViewBag.html = RepositoryPagina.renderizarPagina(pagina);

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

            Pagina pag = new Pagina();

            if (pagina != null)
            {
                var lista = await BuscarPaginas();
                pagina = RemoveAccents(pagina);
                pag = lista
                .FirstOrDefault(p => p.Pedido.DominioTemporario
                .ToLower()
                == dominio.ToLower() && p.Titulo
                .Replace(" ", "")
                .Replace("à", "a")
                .Replace("á", "a")
                .Replace("ã", "a")
                .Replace("â", "a")
                .Replace("é", "e")
                .Replace("ê", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("õ", "o")
                .Replace("ô", "o")
                .Replace("ú", "u")
                .Replace("ü", "u")
                .ToLower()
                == pagina.ToLower());
            }

            if (pagina == null)
            {
                try
                {
                    var lista2 = await BuscarPaginas();
                    var lista = lista2
                    .Where(p => p.Pedido.DominioTemporario
                    .Replace(" ", "")
                    .Replace("www", "")
                    .Replace(".com", "")
                    .Replace(".com.br", "")
                    .Replace("à", "a")
                    .Replace("á", "a")
                    .Replace("ã", "a")
                    .Replace("â", "a")
                    .Replace("é", "e")
                    .Replace("ê", "e")
                    .Replace("í", "i")
                    .Replace("ó", "o")
                    .Replace("õ", "o")
                    .Replace("ô", "o")
                    .Replace("ú", "u")
                    .Replace("ü", "u")
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

            foreach (var div in pag.Div)
            {
                div.Elemento = div.Elemento.OrderBy(e => e.Ordem).ToList();
            }

            string html = RepositoryPagina.renderizarPaginaComMenuDropDown(pag);
            ViewBag.html = html;
            pag.Html = html;
            RepositoryPagina.criandoArquivoHtml(pag);
            return View(pag);            
        }

        public async Task<IActionResult> Salvar(int id)
        {
            var lista = await BuscarPaginas();
            Pagina pag = lista.FirstOrDefault(p => p.IdPagina == id);

            RepositoryPagina.criandoArquivoHtml(pag);
            ViewBag.html = RepositoryPagina.renderizarPagina(pag);

            return Content("Salvo com sucesso");
        }

        public async Task<List<Pagina>> BuscarPaginas()
        {
            List<Pagina> lista = await db.Pagina
            .Include(p => p.Pastas)
            .Include(p => p.Background)
            .ThenInclude(b => b.imagem)
            .Include(p => p.Background)
            .ThenInclude(b => b.BackgroundGradiente)
            .ThenInclude(b => b.Cores)
            .Include(p => p.Pedido)
            .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.texto)
            .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.carousel)
            .ThenInclude(b => b.imagens).ThenInclude(b => b.Imagem)
            .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.carousel)
            .ThenInclude(b => b.imagens).ThenInclude(b => b.Carousel)
            .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.form)
            .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.imagem)
            .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.video)
            .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.link)
            .ThenInclude(b => b.texto)
            .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.link)
            .ThenInclude(b => b.imagem)
            .Include(p => p.Div)
            .ThenInclude(b => b.Elemento)
            .ThenInclude(b => b.table)
            .ThenInclude(b => b.Produtos)
            .ThenInclude(b => b.Imagens)
            .ThenInclude(b => b.Imagem)
            .Include(p => p.Div)
            .ThenInclude(b => b.Elemento)
            .ThenInclude(b => b.table)
            .ThenInclude(b => b.Produtos)
            .ThenInclude(b => b.Imagens)
            .ThenInclude(b => b.Produto)
            .ToListAsync();
          

            foreach (var pag in lista)
            {
                foreach (var div in pag.Div)
                {
                    div.Elemento = div.Elemento.OrderBy(e => e.Ordem).ToList();
                }
            }

            return lista;
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
    }
}