using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.business;
using MeuProjetoAgora.Models.Repository;
using MeuProjetoAgora.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace MeuProjetoAgora.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaginaApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IRepositoryPagina RepositoryPagina { get; }

        public PaginaApiController(ApplicationDbContext context, IRepositoryPagina repositoryPagina)
        {
            _context = context;
            RepositoryPagina = repositoryPagina;
        }

        // GET: api/PaginaApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaginaApi>>> GetPagina()
        {
            var paginas = await includes().ToListAsync();
            List<PaginaApi> lista = new List<PaginaApi>();

            foreach(var pag in paginas)
            {
                foreach (var div in pag.Div)
                {
                    div.Div.Elemento = div.Div.Elemento.OrderBy(e => e.Elemento.Ordem).ToList();

                    foreach (var elemento in div.Div.Elemento)
                    {
                        elemento.Elemento.tipo = elemento.Elemento.GetType().Name;

                        foreach (var dependente in elemento.Elemento.Despendentes)
                        {
                            dependente.ElementoDependente.Dependente.tipo =
                            dependente.ElementoDependente.Dependente.GetType().Name;
                        }
                    }
                }

                var texto = await RepositoryPagina.renderizarPaginaComMenuDropDown(pag);
                var html = texto;

                lista.Add(new PaginaApi
                {
                     Html = html,
                      id = pag.IdPagina
                });
            }

            return lista;
        }

        // GET: api/PaginaApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaginaApi>> GetPagina(int id)
        {
            var pagina = await includes().FirstAsync(p => p.IdPagina == id);

            foreach (var div in pagina.Div)
            {
                div.Div.Elemento = div.Div.Elemento.OrderBy(e => e.Elemento.Ordem).ToList();

                foreach (var elemento in div.Div.Elemento)
                {
                    elemento.Elemento.tipo = elemento.Elemento.GetType().Name;

                    foreach (var dependente in elemento.Elemento.Despendentes)
                    {
                        dependente.ElementoDependente.Dependente.tipo =
                        dependente.ElementoDependente.Dependente.GetType().Name;
                    }
                }
            }

            var texto = await RepositoryPagina.renderizarPaginaComMenuDropDown(pagina);

            var html = texto;

            if (pagina == null)
            {
                return NotFound();
            }

            var pag = new PaginaApi
            {
                 Html = html,
                 id = pagina.IdPagina
            };


            return pag;
        }

        // PUT: api/PaginaApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagina(int id, Pagina pagina)
        {
            if (id != pagina.IdPagina)
            {
                return BadRequest();
            }

            _context.Entry(pagina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaginaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaginaApi
        [HttpPost]
        public async Task<ActionResult<Pagina>> PostPagina(Pagina pagina)
        {
            _context.Pagina.Add(pagina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPagina", new { id = pagina.IdPagina }, pagina);
        }

        // DELETE: api/PaginaApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pagina>> DeletePagina(int id)
        {
            var pagina = await _context.Pagina.FindAsync(id);
            if (pagina == null)
            {
                return NotFound();
            }

            _context.Pagina.Remove(pagina);
            await _context.SaveChangesAsync();

            return pagina;
        }

        private bool PaginaExists(int id)
        {
            return _context.Pagina.Any(e => e.IdPagina == id);
        }

        public IIncludableQueryable<Pagina, Div> includes()
        {
            var include = _context.Pagina
            .Include(p => p.Pastas)
            .Include(p => p.Background)
            .ThenInclude(b => b.imagem)
            .Include(p => p.Background)
            .ThenInclude(b => b.BackgroundGradiente)
            .ThenInclude(b => b.Cores)
            .Include(p => p.Pedido)
            .ThenInclude(p => p.Paginas)
            .ThenInclude(p => p.Div)
            .ThenInclude(b => b.Div)
            .ThenInclude(b => b.Elemento)
            .ThenInclude(b => b.Elemento)
            .ThenInclude(b => b.Despendentes)
            .ThenInclude(b => b.Elemento)
            .Include(p => p.Div)
            .ThenInclude(b => b.Div)
            .ThenInclude(b => b.Elemento)
            .ThenInclude(b => b.Elemento)
            .ThenInclude(b => b.Despendentes)
            .ThenInclude(b => b.ElementoDependente)
            .ThenInclude(b => b.Dependente)
            .ThenInclude(b => b.Despendentes)
            .ThenInclude(b => b.ElementoDependente)
            .ThenInclude(b => b.Dependente)
            .Include(p => p.Div)
            .ThenInclude(b => b.Div)
            .ThenInclude(b => b.Elemento)
            .ThenInclude(b => b.Div);

            return include;
        }
    }
}
