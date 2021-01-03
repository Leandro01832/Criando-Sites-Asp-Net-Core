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
using MeuProjetoAgora.Models.Join;
using Microsoft.AspNetCore.Identity;

namespace MeuProjetoAgora.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class SuperAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserManager<IdentityUser> UserManager { get; }

        public SuperAdminController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }

        //Região Index
        #region
        [Route("Mensagens")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.MensagemChat.ToListAsync());
        }
        [Route("Usuarios")]
        public IActionResult IndexUsers()
        {
            var usuarios = UserManager.Users.ToList();
            return View(usuarios);
        }
        public async Task<IActionResult> IndexBackground()
        {
            var applicationDbContext = _context.Background.Include(b => b.Pagina).Include(b => b.imagem);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> IndexElementoDependente()
        {
            var elementos = _context.ElementoDependente;
            return View(await elementos.ToListAsync());
        }
        public async Task<IActionResult> IndexElementoDependenteElemento()
        {
            var applicationDbContext = _context.ElementoDependenteElemento
            .Include(e => e.Elemento).Include(e => e.ElementoDependente);
            return View(await applicationDbContext.ToListAsync());
        }
        [Route("SuperAdmin/Rotas")]
        [Route("Rotas")]
        public async Task<IActionResult> Rotas()
        {
            return View(await _context.Rota.ToListAsync());
        }
        #endregion
        
        //Região Detalhes
        #region
        public async Task<IActionResult> DetailsBackground(int? id)
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

            return View(background);
        }
        public async Task<IActionResult> DetailsElementoDependente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elemento = await _context.ElementoDependente
                .FirstOrDefaultAsync(m => m.IdElementoDependente == id);
            if (elemento == null)
            {
                return NotFound();
            }

            return View(elemento);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagemChat = await _context.MensagemChat
                .FirstOrDefaultAsync(m => m.IdMensagem == id);
            if (mensagemChat == null)
            {
                return NotFound();
            }

            return View(mensagemChat);
        }
        public async Task<IActionResult> DetailsElementoDependenteElemento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementoDependenteElemento = await _context.ElementoDependenteElemento
                .Include(e => e.Elemento)
                .Include(e => e.ElementoDependente)
                .FirstOrDefaultAsync(m => m.ElementoDependenteId == id);
            if (elementoDependenteElemento == null)
            {
                return NotFound();
            }

            return View(elementoDependenteElemento);
        }
        #endregion

        //Região Create
        #region
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMensagem,Pagina,NomeUsuario,Mensagem")] MensagemChat mensagemChat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensagemChat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mensagemChat);
        }
        public IActionResult CreateElementoDependente()
        {
            ViewData["ElementoId"] = new SelectList(_context.Elemento, "IdElemento", "Discriminator");
            ViewData["ElementoDependenteId"] = new SelectList(_context.ElementoDependente, "IdElementoDependente", "IdElementoDependente");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateElementoDependente([Bind("ElementoId,ElementoDependenteId")] ElementoDependenteElemento elementoDependenteElemento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(elementoDependenteElemento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ElementoId"] = new SelectList(_context.Elemento, "IdElemento", "Discriminator", elementoDependenteElemento.ElementoId);
            ViewData["ElementoDependenteId"] = new SelectList(_context.ElementoDependente, "IdElementoDependente", "IdElementoDependente", elementoDependenteElemento.ElementoDependenteId);
            return View(elementoDependenteElemento);
        }
        #endregion

        //Região Editar
        #region
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagemChat = await _context.MensagemChat.FindAsync(id);
            if (mensagemChat == null)
            {
                return NotFound();
            }
            return View(mensagemChat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMensagem,Pagina,NomeUsuario,Mensagem")] MensagemChat mensagemChat)
        {
            if (id != mensagemChat.IdMensagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensagemChat);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mensagemChat);
        }
        public async Task<IActionResult> EditElementoDependenteElemento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementoDependenteElemento = await _context.ElementoDependenteElemento.FindAsync(id);
            if (elementoDependenteElemento == null)
            {
                return NotFound();
            }
            ViewData["ElementoId"] = new SelectList(_context.Elemento, "IdElemento", "Discriminator", elementoDependenteElemento.ElementoId);
            ViewData["ElementoDependenteId"] = new SelectList(_context.ElementoDependente, "IdElementoDependente", "IdElementoDependente", elementoDependenteElemento.ElementoDependenteId);
            return View(elementoDependenteElemento);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditElementoDependenteElemento(int id, [Bind("ElementoId,ElementoDependenteId")] ElementoDependenteElemento elementoDependenteElemento)
        {
            if (id != elementoDependenteElemento.ElementoDependenteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(elementoDependenteElemento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ElementoId"] = new SelectList(_context.Elemento, "IdElemento", "Discriminator", elementoDependenteElemento.ElementoId);
            ViewData["ElementoDependenteId"] = new SelectList(_context.ElementoDependente, "IdElementoDependente", "IdElementoDependente", elementoDependenteElemento.ElementoDependenteId);
            return View(elementoDependenteElemento);
        }
        #endregion

        //Região Ddelete
        #region
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagemChat = await _context.MensagemChat
                .FirstOrDefaultAsync(m => m.IdMensagem == id);
            if (mensagemChat == null)
            {
                return NotFound();
            }

            return View(mensagemChat);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensagemChat = await _context.MensagemChat.FindAsync(id);
            _context.MensagemChat.Remove(mensagemChat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DeleteElementoDependente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementoDependenteElemento = await _context.ElementoDependenteElemento
                .Include(e => e.Elemento)
                .Include(e => e.ElementoDependente)
                .FirstOrDefaultAsync(m => m.ElementoDependenteId == id);
            if (elementoDependenteElemento == null)
            {
                return NotFound();
            }

            return View(elementoDependenteElemento);
        }
        [HttpPost, ActionName("DeleteElementoDependente")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteElementoDependenteConfirmed(int id)
        {
            var elementoDependenteElemento = await _context.ElementoDependenteElemento.FindAsync(id);
            _context.ElementoDependenteElemento.Remove(elementoDependenteElemento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}
