using business.Back;
using business.business;
using CMS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    public class FerramentaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserManager<IdentityUser> UserManager { get; }

        public FerramentaController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }

        [Authorize(Roles = "Background")]
        public async Task<IActionResult> ListaCores(int? id)
        {
            List<Cor> lista = new List<Cor>();

            var pagina = await _context.Pagina
                .Include(p => p.Div)
                .ThenInclude(p => p.Div)
                .ThenInclude(p => p.Background)
                .FirstAsync(p => p.Id == id);

                foreach(var item in pagina.Div)
                {
                    if(item.Div.Background is BackgroundGradiente)
                    {
                        var backcolor = await _context.BackgroundGradiente.Include(b => b.Cores)
                        .FirstAsync(b => b.Id == item.Div.Background.Id);
                        lista.AddRange(backcolor.Cores);
                    }
                }                
            

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
                return $"Chave da pasta: {pasta.Id}";
            }

            return "";
        }

        [Authorize(Roles = "Background")]
        public async Task<IActionResult> CreateCor(int? id)
        {
            List<Background> lista = new List<Background>();

            var pagina = await _context.Pagina
                .Include(p => p.Div)
                .ThenInclude(p => p.Div)
                .ThenInclude(p => p.Background)
                .ThenInclude(p => p.Cores)
                .FirstAsync(p => p.Id == id);

            foreach (var item in pagina.Div)
            {
                if (item.Div.Background is BackgroundGradiente)
                {
                    lista.Add(item.Div.Background);
                }
            }


            ViewBag.BackgroundId = new SelectList(lista, "Id", "Id");
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
                return $"Chave da cor: {cor.Id}";
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
            List<Background> lista = new List<Background>();
            var black = _context.Background.Include(b => b.Div).First(b => b.Id == cor.BackgroundId);
            var pagina = await _context.Pagina
                .Include(p => p.Div)
                .ThenInclude(p => p.Div)
                .ThenInclude(p => p.Background)
                .FirstAsync(p => p.Id == black.Div.Pagina_);

            foreach (var item in pagina.Div)
            {
                if (item.Div.Background is BackgroundGradiente)
                {
                    lista.Add(item.Div.Background);
                }
            }

            ViewBag.BackgroundId = new SelectList(lista, "Id", "Id", cor.BackgroundId);
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
                        .FirstAsync(bg => bg.Id == cor.BackgroundId);
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
        
        

        public async Task<IActionResult> DeleteCor(int? id)
        {
            var cor = await _context.Cor
                .Include(b => b.Background)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            return _context.Background.Any(e => e.Id == id);
        }
    }
}
