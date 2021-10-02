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

            var pagina = await _context.Pagina.FirstAsync(p => p.Id == id);
            var pedido = await _context.Pedido.Include(p => p.Paginas)
            .FirstAsync(p => p.Id == pagina.PedidoId);

            foreach (var page in pedido.Paginas)
            {
                var pagin = await _context.Pagina.Include(p => p.Div)
                    .ThenInclude(p => p.Div).ThenInclude(p => p.Background).FirstAsync(p => p.Id == page.Id);

                foreach(var item in pagin.Div)
                {
                    if(item.Div.Background is BackgroundGradiente)
                    {
                        var backcolor = await _context.BackgroundGradiente.Include(b => b.Cores)
                        .FirstAsync(b => b.Id == item.Div.Background.Id);
                        lista.AddRange(backcolor.Cores);
                    }
                }

                

                
            }

            return PartialView(lista);
        }

        [Authorize(Roles = "Background")]
        public async Task<IActionResult> ListaBackground(int? id)
        {
            List<Background> lista = new List<Background>();
            Pagina pagina = await _context.Pagina.FirstAsync(p => p.Id == id);
            Pedido ped = await _context.Pedido.Include(p => p.Paginas).FirstAsync(p => p.Id == pagina.PedidoId);

            foreach(var item in ped.Paginas)
            {
                Pagina pag = await _context.Pagina.Include(p => p.Div)
                    .ThenInclude(p => p.Div).ThenInclude(p => p.Background).FirstAsync(p => p.Id == item.Id);

                foreach (var item2 in pag.Div)
                    lista.Add(item2.Div.Background);
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
                        .FirstAsync(bg => bg.Id == cor.BackgroundGradienteId);
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
        public IActionResult CreateBackground(string back)
        {
            Background background = null;

            if (back == "BackgroundCor") background = new BackgroundCor();
            if (back == "BackgroundGradiente") background = new BackgroundGradiente();
            if (back == "BackgroundImagem") background = new BackgroundImagem();
            
            return PartialView(background);
        }

        [Authorize(Roles = "Background")]
        public async Task<IActionResult> EditBackground(int? id)
        {
            var background = await _context.Background.FindAsync(id);
            if (background == null)
            {
                return NotFound();
            }
            
            return PartialView(background);
        }

        #region Create-Edit-Background
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Background")]
        public async Task<string> _BackgroundCor([FromBody]BackgroundCor background)
        {
            if (background.backgroundTransparente)
                background.Cor = "transparent";
            if(background.Id == 0)
            {
                _context.Add(background); await _context.SaveChangesAsync();
                return $"Chave do plano de fundo {background.Id}";
            }
            else
            {
                _context.Update(background);  await _context.SaveChangesAsync();
                return "";
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Background")]
        public async Task<string> _BackgroundGradiente([FromBody]BackgroundGradiente background)
        {
            if (background.Id == 0)
            {
                _context.Add(background); await _context.SaveChangesAsync();
                return $"Chave do plano de fundo {background.Id}";
            }
            else
            {
                _context.Update(background); await _context.SaveChangesAsync();
                return "";
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Background")]
        public async Task<string> _BackgroundImagem([FromBody]BackgroundImagem background)
        {
            if (background.Id == 0)
            {
                _context.Add(background); await _context.SaveChangesAsync();
                return $"Chave do plano de fundo {background.Id}";
            }
            else
            {
                _context.Update(background); await _context.SaveChangesAsync();
                return "";
            }
        } 
        #endregion        
        
        public async Task<IActionResult> DeleteBackground(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var background = await _context.Background
                .FirstOrDefaultAsync(m => m.Id == id);
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
