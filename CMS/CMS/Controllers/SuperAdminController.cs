using business.business;
using business.Join;
using CMS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Controllers
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
            var applicationDbContext = _context.Background;
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> IndexElementoDependente()
        {
            var elementos = _context.ElementoDependente;
            return View(await elementos.ToListAsync());
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mensagemChat == null)
            {
                return NotFound();
            }

            return View(mensagemChat);
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
            if (id != mensagemChat.Id)
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
                .FirstOrDefaultAsync(m => m.Id == id);
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
        #endregion

    }
}
