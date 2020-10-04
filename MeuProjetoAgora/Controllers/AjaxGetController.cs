using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
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

        public JsonResult GetTable(int DivId)
        {
            List<string> result = new List<string>();
            List<Elemento> lista = new List<Elemento>();
            var table = db.Table.Where(m => m.div_ == DivId);
            foreach (var t in table.ToList())
            {
                var ele = db.Elemento.Include(e => e.table).First(e => e.table_ == t.IdTable);
                lista.Add(ele);
            }
            foreach (var item in lista)
            {
                result.Add(item.IdElemento.ToString());
            }
            foreach (var item in lista)
            {
                result.Add(item.table.Nome);
            }

            return Json(result);
        }       

        public JsonResult GetTexto(int DivId)
        {
            List<string> result = new List<string>();
            List<Elemento> lista = new List<Elemento>();
            var t = db.Texto.Where(m => m.div_ == DivId);
            foreach (var texto in t.ToList())
            {
                var ele = db.Elemento.Include(e => e.texto).First(e => e.texto_ == texto.IdTexto);
                lista.Add(ele);
            }
            foreach (var item in lista)
            {
                result.Add(item.IdElemento.ToString());
            }
            foreach (var item in lista)
            {
                result.Add(item.texto.Nome);
            }

            return Json(result);
        }

        public JsonResult GetImagens(int Pasta)
        {
            List<string> result = new List<string>();
            List<Elemento> lista = new List<Elemento>();
            var imagens = db.Imagem.Where(b => b.PastaImagemId == Pasta);
            foreach (var img in imagens.ToList())
            {
                var ele = db.Elemento.Include(e => e.imagem).First(e => e.imagem_ == img.IdImagem);
                lista.Add(ele);
            }
            foreach (var item in lista)
            {
                result.Add(item.IdElemento.ToString());
            }
            foreach (var item in lista)
            {
                result.Add(item.imagem.Arquivo);
            }

            return Json(result);
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

        public JsonResult GetPaginas(int PedidoId)
        {
            //  db.Configuration.ProxyCreationEnabled = false;
            var paginas = db.Pagina.Where(m => m.pedido_ == PedidoId);

            return Json(paginas);
        }

        public JsonResult GetDivs(int PaginaId)
        {
            //  db.Configuration.ProxyCreationEnabled = false;
            var backgrounds = db.Div.Where(m => m.PaginaId == PaginaId);

            return Json(backgrounds);
        }

        public JsonResult GetBackgrounds(int PaginaId)
        {
            var backgrounds = db.Background.Where(m => m.PaginaId == PaginaId);

            return Json(backgrounds);
        }

        public JsonResult GetSelectedBackgrounds(int PaginaId)
        {
           // selected = "selected"
            var backgrounds = db.Background.Where(m => m.PaginaId == PaginaId);

            return Json(backgrounds);
        }

        public JsonResult GetBackgroundsGradiente(int PaginaId)
        {
            // db.Configuration.ProxyCreationEnabled = false;
            var backgrounds = db.Background.Where(m => m.PaginaId == PaginaId && m.backgroundImage == false &&
            m.backgroundTransparente == false && m.Gradiente == true);

            return Json(backgrounds);
        }

        public JsonResult GetElementos(int DivId, string valor, int pagina, int Pasta)
        {
            if (valor == "Video")
            {
                List<string> result = new List<string>();
                List<Elemento> lista = new List<Elemento>();
                var v = db.Video.Where(m => m.div_ == DivId);
                foreach (var video in v.ToList())
                {
                    var ele = db.Elemento.Include(e => e.video).First(e => e.video_ == video.IdVideo);
                    lista.Add(ele);
                }
                foreach (var item in lista)
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in lista)
                {
                    result.Add(item.IdElemento.ToString());
                }

                return Json(result);
            }

            if (valor == "Imagem")
            {
                List<string> result = new List<string>();
                List<Elemento> lista = new List<Elemento>();
                var imagens = db.Imagem.Where(b => b.PastaImagemId == Pasta);
                foreach (var img in imagens.ToList())
                {
                    var ele = db.Elemento.Include(e => e.imagem).First(e => e.imagem_ == img.IdImagem);
                    lista.Add(ele);
                }
                foreach (var item in lista)
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in lista)
                {
                    result.Add(item.imagem.Arquivo);
                }

                return Json(result);
            }

            if (valor == "Carrossel")
            {
                List<string> result = new List<string>();
                List<Elemento> lista = new List<Elemento>();
                var c = db.Carousel.Where(m => m.div_2 == DivId);
                foreach (var carousel in c.ToList())
                {
                    var ele = db.Elemento.Include(e => e.carousel).First(e => e.carousel_ == carousel.IdCarousel);
                    lista.Add(ele);
                }
                foreach (var item in lista)
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in lista)
                {
                    result.Add(item.carousel.Nome);
                }

                return Json(result);
            }

            if (valor == "Texto")
            {
                List<string> result = new List<string>();
                List<Elemento> lista = new List<Elemento>();
                var t = db.Texto.Where(m => m.div_ == DivId);
                foreach (var texto in t.ToList())
                {
                    var ele = db.Elemento.Include(e => e.texto).First(e => e.texto_ == texto.IdTexto);
                    lista.Add(ele);
                }
                foreach (var item in lista)
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in lista)
                {
                    result.Add(item.texto.Nome);
                }

                return Json(result);
            }

            if (valor == "Link")
            {
                List<string> result = new List<string>();
                List<Elemento> lista = new List<Elemento>();
                var link = db.Link.Where(m => m.div_ == DivId);
                foreach (var l in link.ToList())
                {
                    var ele = db.Elemento.Include(e => e.link).First(e => e.link_ == l.IdLink);
                    lista.Add(ele);
                }
                foreach (var item in lista)
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in lista)
                {
                    result.Add(item.IdElemento.ToString());
                }

                return Json(result);
            }

            if (valor == "Form")
            {
                List<string> result = new List<string>();
                List<Elemento> lista = new List<Elemento>();
                var t = db.Form.Where(m => m.div_ == DivId);
                return Json(t);
            }

            if (valor == "Table")
            {
                List<string> result = new List<string>();
                List<Elemento> lista = new List<Elemento>();
                var t = db.Table.Where(m => m.div_ == DivId);
                foreach (var table in t.ToList())
                {
                    var ele = db.Elemento.Include(e => e.table).First(e => e.table_ == table.IdTable);
                    lista.Add(ele);
                }
                foreach (var item in lista)
                {
                    result.Add(item.IdElemento.ToString());
                }
                foreach (var item in lista)
                {
                    result.Add(item.table.Nome);
                }

                return Json(result);
            }

            return Json("");
        }
    }
}