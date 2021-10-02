using business.Back;
using business.business.carousel;
using business.business.Elementos;
using business.business.Elementos.element;
using business.business.Elementos.imagem;
using business.business.Elementos.produto;
using business.business.Elementos.texto;
using business.business.link;
using CMS.Data;
using CMS.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Controllers
{
    public class AjaxGetController : Controller
    {
        private readonly ApplicationDbContext db;

        public IRepositoryPedido RepositoryPedido { get; }
        public IRepositoryPagina RepositoryPagina { get; }
        public IHttpHelper HttpHelper { get; }
        public IRepositoryBackground RepositoryBackground { get; }

        public AjaxGetController(ApplicationDbContext context, IRepositoryPedido repositoryPedido,
            IRepositoryPagina repositoryPagina, IHttpHelper httpHelper,
            IRepositoryBackground repositoryBackground)
        {
            db = context;
            RepositoryPedido = repositoryPedido;
            RepositoryPagina = repositoryPagina;
            HttpHelper = httpHelper;
            RepositoryBackground = repositoryBackground;
        } 

        public JsonResult GetPastas(int Pagina)
        {
            var pastas = db.PastaImagem.Where(b => b.PaginaId == Pagina);

            return Json(pastas);
        }

        public JsonResult GetCores(int Background)
        {
            var cores = db.Cor.Where(b => b.BackgroundGradienteId == Background);

            return Json(cores);
        }

        public JsonResult Mensagens(int Pagina)
        {
            var pastas = db.MensagemChat.Where(b => b.Pagina == Pagina);

            return Json(pastas);
        }

        public async Task<JsonResult> GetPaginas(int Pagina)
        {
            var pagina = await db.Pagina.FirstAsync(p => p.Id == Pagina);
            var PedidoId = pagina.PedidoId;
            var paginas = db.Pagina.Where(m => m.PedidoId == PedidoId);

            return Json(paginas);
        }

        public JsonResult GetPaginasDoSite(int Pedido)
        {
            var paginas = db.Pagina.Where(m => m.PedidoId == Pedido);

            return Json(paginas);
        }

        public async Task<JsonResult> GetSites(int Pagina)
        {
            var pagina = await db.Pagina.FirstAsync(p => p.Id == Pagina);
            var PedidoId = pagina.PedidoId;
            var pedido = await  db.Pedido.FirstAsync(m => m.Id == PedidoId);
            var pedidos = db.Pedido.Where(m => m.ClienteId == pedido.ClienteId);

            return Json(pedidos);
        }

        public async Task<JsonResult> GetBackgrounds(int PaginaId)
        {
            var pagina = await db.Pagina.Include(d => d.Div).ThenInclude(d => d.Div)
                .ThenInclude(d => d.Background).FirstAsync(b => b.Id == PaginaId);
                var background = new List<Background>();
                foreach (var item in pagina.Div)
                background.Add(item.Div.Background);

            return Json(background.AsQueryable());
        }

        public async Task<JsonResult> Elementos(int Pagina)
        {
            var pagina = await db.Pagina.FirstAsync(p => p.Id == Pagina);
            var PedidoId = pagina.PedidoId;
            var pedido = await db.Pedido.Include(p => p.Paginas)
                .FirstAsync(m => m.Id == PedidoId);
            

            List<Elemento> elementos = new List<Elemento>();

            foreach(var pag in pedido.Paginas)
            {
                var page = await db.Pagina.Include(p => p.Div)
                .FirstAsync(p => p.Id == pag.Id);

                var elements = await db.Elemento.Where(e => e.Pagina_ == pag.Id).ToListAsync();

                elementos.AddRange(elements);
            }

            return Json(elementos);
        }
    }
}