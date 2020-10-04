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

namespace MeuProjetoAgora.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class SuperAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> IndexElemento()
        {
            var applicationDbContext = _context.Elemento.Include(e => e.carousel).Include(e => e.div).Include(e => e.form).Include(e => e.imagem).Include(e => e.link).Include(e => e.table).Include(e => e.texto).Include(e => e.video);
            return View(await applicationDbContext.ToListAsync());
        }

        
        public async Task<IActionResult> DetailsElemento(int? id)
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

        [Route("Mensagens")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.MensagemChat.ToListAsync());
        }

        [Route("SuperAdmin/Rotas")]
        [Route("Rotas")]
        public async Task<IActionResult> Rotas()
        {
            return View(await _context.Rota.ToListAsync());
        }

        // GET: SuperAdmin/Details/5
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

        // GET: SuperAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: SuperAdmin/Edit/5
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

        // POST: SuperAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensagemChatExists(mensagemChat.IdMensagem))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mensagemChat);
        }

        // GET: SuperAdmin/Delete/5
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

        // POST: SuperAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensagemChat = await _context.MensagemChat.FindAsync(id);
            _context.MensagemChat.Remove(mensagemChat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensagemChatExists(int id)
        {
            return _context.MensagemChat.Any(e => e.IdMensagem == id);
        }
    }
}
