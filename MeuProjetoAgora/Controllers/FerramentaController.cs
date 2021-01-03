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
using MeuProjetoAgora.Models.business.Elemento;

namespace MeuProjetoAgora.Controllers
{
    public class FerramentaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FerramentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Background")]
        public async Task<IActionResult> ListaCores(int? id)
        {
            List<Cor> lista = new List<Cor>();

            var pagina = await _context.Pagina.FirstAsync(p => p.IdPagina == id);
            var pedido = await _context.Pedido.Include(p => p.Paginas)
            .FirstAsync(p => p.IdPedido == pagina.pedido_);

            foreach (var page in pedido.Paginas)
            {
                var cores = await _context.Cor
                .Include(p => p.BackgroundGradiente)
                .ThenInclude(p => p.Background)
                .ThenInclude(p => p.Pagina)
                .Where(d => d.BackgroundGradiente.Background.PaginaId == page.IdPagina).ToListAsync();

                lista.AddRange(cores);
            }

            return PartialView(lista);
        }

        [Authorize(Roles = "Background")]
        public async Task<IActionResult> ListaBackground(int? id)
        {
            List<Background> lista = new List<Background>();
            
            var backgroud = await _context.Background
            .Include(p => p.Pagina)
            .Where(d => d.PaginaId == id).ToListAsync();

            lista.AddRange(backgroud);
            return PartialView(lista);
        }

        [Authorize(Roles = "Imagem")]
        public IActionResult CreatePasta()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Imagem")]
        public async Task<string> CreatePasta([FromBody]PastaImagem pasta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pasta);
                await _context.SaveChangesAsync();
                return $"Chave da pasta: {pasta.IdPastaImagem}";
            }

            return "";
        }

        [Authorize(Roles = "Background")]
        public IActionResult CreateCor()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Background")]
        public async Task<string> CreateCor([FromBody]Cor cor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cor);
                await _context.SaveChangesAsync();
                return $"Chave da cor: {cor.IdCor}";
            }
            
            return "";
        }

        [Authorize(Roles = "Background")]
        public async Task<IActionResult> EditCor(int? id)
        {
            var cor = await _context.Cor.FindAsync(id);
            if (cor == null)
            {
                return NotFound();
            }
            ViewBag.selecionado = cor.BackgroundGradienteId;
            return PartialView(cor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Background")]
        public async Task<string> EditCor([FromBody]Cor cor)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var b = await _context.BackgroundGradiente
                        .FirstAsync(bg => bg.IdBackgroundGradiente == cor.BackgroundGradienteId);
                    b.Grau = cor.Grau;
                    _context.Update(b);
                    _context.Update(cor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return "";
                }
                return "";
            }

            return "";
        }

        [Authorize(Roles = "Background")]
        public IActionResult CreateBackgroundGradiente()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Background")]
        public async Task<string> CreateBackgroundGradiente([FromBody]BackgroundGradiente BackgroundGradiente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(BackgroundGradiente);
                await _context.SaveChangesAsync();
                return "";
            }
            
            return "";
        }

        [Authorize(Roles = "Background")]
        public async Task<IActionResult> EditBackgroundGradiente(int? id)
        {
            var backgroundGradiente = await _context.BackgroundGradiente.FindAsync(id);
            if (backgroundGradiente == null)
            {
                return NotFound();
            }
            return PartialView(backgroundGradiente);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Background")]
        public async Task<string> EditBackgroundGradiente([FromBody]BackgroundGradiente backgroundGradiente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(backgroundGradiente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return "";
                }
                return "";
            }
            
            return "";
        }

        [Authorize(Roles = "Background")]
        public IActionResult CreateBackground()
        {
            return PartialView();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Background")]
        public async Task<string> CreateBackground([FromBody]Background background)
        {
            if (ModelState.IsValid)
            {
                background.BackgroundGradiente = new BackgroundGradiente();
                background.BackgroundGradiente.Grau = 0;
                _context.Add(background);
                await _context.SaveChangesAsync();
                return $"Chave do plano de fundo {background.IdBackground}";
            }
            ViewBag.PaginaId = new SelectList(new List<Pagina>(), "IdPagina", "Titulo", background.PaginaId);
            ViewBag.imagem_ = new SelectList(new List<Imagem>(), "IdImagem", "IdImagem", background.imagem_);
            return "";
        }

        [Authorize(Roles = "Background")]
        public async Task<IActionResult> EditBackground(int? id)
        {
            var background = await _context.Background.FindAsync(id);
            if (background == null)
            {
                return NotFound();
            }

            ViewBag.selecionado = background.imagem_;
            return PartialView(background);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Background")]
        public async Task<string> EditBackground([FromBody]Background background)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(background);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return "";
                }
                return "";
            }
            ViewBag.PaginaId = new SelectList(_context.Pagina, "IdPagina", "Titulo", background.PaginaId);
            ViewBag.imagem_ = new SelectList(_context.Imagem, "IdImagem", "IdImagem", background.imagem_);
            return "";
        }
        

        public async Task<IActionResult> DeleteBackground(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var background = await _context.Background
                .Include(b => b.Pagina)
                .Include(b => b.imagem)
                .FirstOrDefaultAsync(m => m.IdBackground == id);
            if (background == null)
            {
                return NotFound();
            }

            return PartialView(background);
        }
        
        [HttpPost, ActionName("DeleteBackground")]
        [ValidateAntiForgeryToken]
        public async Task<string> DeleteBackgroundConfirmed(int id)
        {
            var background = await _context.Background.FindAsync(id);
            _context.Background.Remove(background);
            await _context.SaveChangesAsync();
            return "";
        }

        public async Task<IActionResult> DeleteCor(int? id)
        {
            var cor = await _context.Cor
                .Include(b => b.BackgroundGradiente)
                .ThenInclude(b => b.Background)
                .FirstOrDefaultAsync(m => m.IdCor == id);
            if (cor == null)
            {
                return NotFound();
            }

            return PartialView(cor);
        }

        [HttpPost, ActionName("DeleteCor")]
        [ValidateAntiForgeryToken]
        public async Task<string> DeleteCorConfirmed(int id)
        {
            var cor = await _context.Cor.FindAsync(id);
            _context.Cor.Remove(cor);
            await _context.SaveChangesAsync();
            return "";
        }

        private bool BackgroundExists(int id)
        {
            return _context.Background.Any(e => e.IdBackground == id);
        }
    }
}
