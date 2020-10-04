using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MeuProjetoAgora.Models.Repository;
using Microsoft.AspNetCore.Identity;
using MeuProjetoAgora.Models;

namespace MeuProjetoAgora.Controllers
{
    public class ElementoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IRepositoryElemento RepositoryElemento { get; }
        public IRepositoryDiv RepositoryDiv { get; }
        public UserManager<IdentityUser> UserManager { get; }

        public ElementoController(ApplicationDbContext context, IRepositoryElemento repositoryElemento,
            IRepositoryDiv repositoryDiv, UserManager<IdentityUser> userManager)
        {
            _context = context;
            RepositoryElemento = repositoryElemento;
            RepositoryDiv = repositoryDiv;
            UserManager = userManager;
        }

        
        public IActionResult CreateDiv()
        {
            ViewBag.background_ = new SelectList(_context.Background, "IdBackground", "Nome");
            ViewBag.PaginaId = new SelectList(_context.Pagina, "IdPgina", "Titulo");
            return PartialView();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> CreateDiv([FromBody] Div div)
        {

            var v = await RepositoryDiv.SalvarBloco(div);
            ViewBag.PaginaId = new SelectList(_context.Pagina, "IdPagina", "Titulo", div.PaginaId);
            ViewBag.background_ = new SelectList(_context.Background, "Idbackground", "Nome", div.background_);
            return v;
        }
        
        public async Task<IActionResult> EditDiv(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var div = await _context.Div.FindAsync(id);
            if (div == null)
            {
                return NotFound();
            }

            ViewBag.PaginaId = new SelectList(_context.Pagina, "IdPagina", "Titulo", div.PaginaId);
            ViewBag.background_ = new SelectList(_context.Background, "Idbackground", "Nome", div.background_);
            return View(div);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string EditDiv([FromBody] Div div)
        {
                try
                {
                    RepositoryDiv.EditarBloco(div);
                }
                catch (Exception)
                {
                     return "Erro na edição do bloco";
                }

            ViewBag.PaginaId = new SelectList(_context.Pagina, "IdPagina", "Titulo", div.PaginaId);
            ViewBag.background_ = new SelectList(_context.Background, "Idbackground", "Nome", div.background_);
            return "";
        }
        
        [Route("Elemento/Create/{Elemento}")]
        public IActionResult Create(string Elemento)
        {
            ViewBag.elemento = Elemento;
            ViewBag.carousel_ = new SelectList(_context.Carousel, "IdCarousel", "Nome");
            ViewBag.div_2 = new SelectList(_context.Div, "IdDiv", "Nome");
            ViewBag.form_ = new SelectList(_context.Form, "IdForm", "IdForm");
            ViewBag.imagem_ = new SelectList(_context.Imagem, "IdImagem", "IdImagem");
            ViewBag.link_ = new SelectList(_context.Link, "IdLink", "IdLink");
            ViewBag.table_ = new SelectList(_context.Table, "IdTable", "IdTable");
            ViewBag.texto_ = new SelectList(_context.Texto, "IdTexto", "Nome");
            ViewBag.video_ = new SelectList(_context.Video, "IdVideo", "IdVideo");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 409715200)]
        [RequestSizeLimit(409715200)]
        public async Task<string> Create([FromBody] ViewModelElemento elemento, IList<IFormFile> files,
            [FromServices] IHostingEnvironment hostingEnvironment)
        {            
            var v =  await  RepositoryElemento.salvar(elemento, files);             
            return v;
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elemento = await _context.Elemento.FindAsync(id);
            if (elemento == null)
            {
                return NotFound();
            }

            bool texto = (elemento.texto != null) ? true : false;
            bool link = (elemento.link != null) ? true : false;
            bool imagem = (elemento.imagem != null) ? true : false;
            bool carousel = (elemento.carousel != null) ? true : false;
            bool form = (elemento.form != null) ? true : false;
            bool table = (elemento.table != null) ? true : false;
            bool video = (elemento.video != null) ? true : false;

            var viewModel = new ViewModelElemento
            {
                Nome = elemento.Nome,
                Ordem = elemento.Ordem,
                div_ = elemento.div_2,
                Renderizar = elemento.Renderizar
            };
            if (imagem)
            {
                viewModel.ArquivoImagem = elemento.imagem.Arquivo;
                viewModel.PastaImagemId = elemento.imagem.PastaImagemId;
                ViewBag.elemento = "imagem";
            }
            if (texto)
            {
                viewModel.PalavrasTexto = elemento.texto.Palavras;
                ViewBag.elemento = "texto";
            }
            if (table)
            {
                viewModel.EstiloTable = elemento.table.Estilo;
                ViewBag.elemento = "table";
            }
            if (link)
            {
                viewModel.imagemLink_ = elemento.link.imagem_;
                viewModel.paginaDestinoLink_ = elemento.link.pagina_;
                viewModel.TextoLink = elemento.link.TextoLink;
                viewModel.UrlLink = elemento.link.Url;
                viewModel.textoLink_ = elemento.link.texto_;
                ViewBag.elemento = "link";
            }
            if (video)
            {
                ViewBag.elemento = "video";
            }
            if (form)
            {
                ViewBag.elemento = "form";
            }
            if (carousel)
            {
                ViewBag.elemento = "carousel";
            }


            ViewData["carousel_"] = new SelectList(_context.Carousel, "IdCarousel", "Nome", elemento.carousel_);
            ViewData["div_2"] = new SelectList(_context.Div, "IdDiv", "Nome", elemento.div_2);
            ViewData["form_"] = new SelectList(_context.Form, "IdForm", "IdForm", elemento.form_);
            ViewData["imagem_"] = new SelectList(_context.Imagem, "IdImagem", "IdImagem", elemento.imagem_);
            ViewData["link_"] = new SelectList(_context.Link, "IdLink", "IdLink", elemento.link_);
            ViewData["table_"] = new SelectList(_context.Table, "IdTable", "IdTable", elemento.table_);
            ViewData["texto_"] = new SelectList(_context.Texto, "IdTexto", "Nome", elemento.texto_);
            ViewData["video_"] = new SelectList(_context.Video, "IdVideo", "IdVideo", elemento.video_);
            return View(viewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> Edit([FromBody] ViewModelElemento elemento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await RepositoryElemento.Editar(elemento);
                }
                catch (Exception)
                {
                    return "Erro!!! Não foi possivel editar o elemento";
                }
                return "";
            }
            return "Erro!!! Não foi possivel editar o elemento";
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Div")]
        public async Task<JsonResult> AlterarPosicaoBloco(IList<int> numeros, int? id)
        {
            //  db.Configuration.ProxyCreationEnabled = false;
            try
            {
                var pagina = await _context.Pagina.FirstAsync(p => p.IdPagina == id);
                var site = pagina.pedido_;
                var usuario = await UserManager.GetUserAsync(this.User);
                var sites = _context.Pedido.Where(c => c.ClienteId == usuario.Id).ToList();
                if (await _context.Permissao.FirstOrDefaultAsync(p => p.Site == site
                && p.UserName == usuario.UserName && p.NomePermissao == "Div") == null)
                {
                    return Json("");
                }
            }
            catch (Exception)
            {
                return Json("");
            }

            for (int i = 0; i < numeros.Count; i++)
            {
                var bloco = await _context.Div.FirstAsync(d => d.IdDiv == numeros[i]);
                bloco.Ordem = i;
                _context.Entry(bloco).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
            return Json("valor");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Elemento")]
        public async Task<JsonResult> AlterarPosicaoElemento(IList<int> numeros, int? id)
        {
            //  db.Configuration.ProxyCreationEnabled = false;
            try
            {
                var pagina = await _context.Pagina.FirstAsync(p => p.IdPagina == id);
                var site = pagina.pedido_;
                var usuario = await UserManager.GetUserAsync(this.User);
                var sites = _context.Pedido.Where(c => c.ClienteId == usuario.Id).ToList();
                if (await _context.Permissao.FirstOrDefaultAsync(p => p.Site == site
                && p.UserName == usuario.UserName && p.NomePermissao == "Elemento") == null)
                {
                    return Json("");
                }
            }
            catch (Exception)
            {
                return Json("");
            }

            for (int i = 0; i < numeros.Count; i++)
            {
                var elemento = await _context.Elemento.FirstAsync(d => d.IdElemento == numeros[i]);
                elemento.Ordem = i;
                _context.Entry(elemento).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
            return Json("valor");
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elemento = await _context.Elemento
                .Include(e => e.carousel)
                .Include(e => e.div)
                .Include(e => e.form)
                .Include(e => e.imagem)
                .Include(e => e.link)
                .Include(e => e.table)
                .Include(e => e.texto)
                .Include(e => e.video)
                .FirstOrDefaultAsync(m => m.IdElemento == id);
            if (elemento == null)
            {
                return NotFound();
            }

            return View(elemento);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var elemento = await _context.Elemento.FindAsync(id);
            _context.Elemento.Remove(elemento);
            await _context.SaveChangesAsync();
            return RedirectToAction("RenderizarDinamico", "Pagina", null);
        }

        private bool ElementoExists(int id)
        {
            return _context.Elemento.Any(e => e.IdElemento == id);
        }
    }
}
