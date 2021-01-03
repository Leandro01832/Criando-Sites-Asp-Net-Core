using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.business.Elemento;
using MeuProjetoAgora.Models.Join;
using MeuProjetoAgora.Models.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuProjetoAgora.Controllers
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
            var pagina = await db.Pagina.FirstAsync(p => p.IdPagina == Pagina);
            var PedidoId = pagina.pedido_;
            var paginas = db.Pagina.Where(m => m.pedido_ == PedidoId);

            return Json(paginas);
        }

        public JsonResult GetPaginasDoSite(int Pedido)
        {
            var paginas = db.Pagina.Where(m => m.pedido_ == Pedido);

            return Json(paginas);
        }

        public async Task<JsonResult> GetSites(int Pagina)
        {
            var pagina = await db.Pagina.FirstAsync(p => p.IdPagina == Pagina);
            var PedidoId = pagina.pedido_;
            var pedido = await  db.Pedido.FirstAsync(m => m.IdPedido == PedidoId);
            var pedidos = db.Pedido.Where(m => m.ClienteId == pedido.ClienteId);

            return Json(pedidos);
        }

        public async Task<JsonResult> GetBackgrounds(int PaginaId)
        {
            var background = await db.Background.Where(b => b.PaginaId == PaginaId).ToListAsync();

            return Json(background.AsQueryable());
        }

        public async Task<JsonResult> GetSelectedBackgrounds(int PaginaId)
        {
            // selected = "selected"
            var background = await db.Background.Where(b => b.PaginaId == PaginaId).ToListAsync();

            return Json(background.AsQueryable());
        }

        public JsonResult GetBackgroundsGradiente(int PaginaId)
        {
            // db.Configuration.ProxyCreationEnabled = false;
            var backgrounds = db.Background.Where(m => m.PaginaId == PaginaId && m.backgroundImage == false &&
            m.backgroundTransparente == false && m.Gradiente == true);

            return Json(backgrounds);
        }

        public async Task<JsonResult> Elementos(int Pagina, string Tipo)
        {
            var pagina = await db.Pagina.FirstAsync(p => p.IdPagina == Pagina);
            var PedidoId = pagina.pedido_;
            var pedido = await db.Pedido.Include(p => p.Paginas)
                .FirstAsync(m => m.IdPedido == PedidoId);

            List<string> result = new List<string>();

            List<Elemento> elementos = new List<Elemento>();

            foreach(var pag in pedido.Paginas)
            {
                var page = await db.Pagina.Include(p => p.Div)
                .FirstAsync(p => p.IdPagina == pag.IdPagina);

                var elements = await db.Elemento.Where(e => e.Pagina_ == pag.IdPagina).ToListAsync();

                elementos.AddRange(elements);
            }

            if (Tipo == "Table")
            {
                foreach (var item in elementos.OfType<Table>())
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in elementos.OfType<Table>())
                {
                    result.Add(item.Nome);
                }
            }

            if (Tipo == "Carrossel")
            {
                foreach (var item in elementos.OfType<Carousel>())
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in elementos.OfType<Carousel>())
                {
                    result.Add(item.Nome);
                }
            }

            if (Tipo == "Imagem")
            {
                foreach (var item in elementos.OfType<Imagem>())
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in elementos.OfType<Imagem>())
                {
                    result.Add(item.Nome);
                }
            }

            if (Tipo == "Video")
            {
                foreach (var item in elementos.OfType<Video>())
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in elementos.OfType<Video>())
                {
                    result.Add(item.Nome);
                }
            }

            if (Tipo == "Texto")
            {
                foreach (var item in elementos.OfType<Texto>())
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in elementos.OfType<Texto>())
                {
                    result.Add(item.Nome);
                }
            }

            if (Tipo == "Produto")
            {
                foreach (var item in elementos.OfType<Produto>())
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in elementos.OfType<Produto>())
                {
                    result.Add(item.Nome);
                }
            }

            if (Tipo == "Form")
            {
                foreach (var item in elementos.OfType<Formulario>())
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in elementos.OfType<Formulario>())
                {
                    result.Add(item.Nome);
                }
            }

            if (Tipo == "Campo")
            {
                foreach (var item in elementos.OfType<Campo>())
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in elementos.OfType<Campo>())
                {
                    result.Add(item.Nome);
                }
            }

            if (Tipo == "Link")
            {
                foreach (var item in elementos.OfType<Link>())
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in elementos.OfType<Link>())
                {
                    result.Add(item.Nome);
                }
            }

            if (Tipo == "Elementos")
            {
                foreach (var item in elementos)
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in elementos)
                {
                    result.Add(item.Nome);
                }
            }

            return Json(result);
        }
    }
}