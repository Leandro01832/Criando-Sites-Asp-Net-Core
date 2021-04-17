using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeuProjetoAgora.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MeuProjetoAgora.Models.Repository;
using Microsoft.AspNetCore.Identity;
using MeuProjetoAgora.Models;
using System.Text.RegularExpressions;
using MeuProjetoAgora.business.Elementos;
using MeuProjetoAgora.business;

namespace MeuProjetoAgora.Controllers
{
    public class ElementoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IRepositoryElemento RepositoryElemento { get; }
        public IRepositoryDiv RepositoryDiv { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IHttpHelper HttpHelper { get; }
        public IRepositoryCarouselPaginaCarousel RepositoryCarouselPaginaCarousel { get; }
        public IRepositoryLink RepositoryLink { get; }
        public IUserHelper UserHelper { get; }

        public ElementoController(ApplicationDbContext context, IRepositoryElemento repositoryElemento,
            IRepositoryDiv repositoryDiv, UserManager<IdentityUser> userManager, IHttpHelper httpHelper,
            IRepositoryCarouselPaginaCarousel repositoryCarouselPaginaCarousel, IRepositoryLink repositoryLink,
            IUserHelper userHelper)
        {
            _context = context;
            RepositoryElemento = repositoryElemento;
            RepositoryDiv = repositoryDiv;
            UserManager = userManager;
            HttpHelper = httpHelper;
            RepositoryCarouselPaginaCarousel = repositoryCarouselPaginaCarousel;
            RepositoryLink = repositoryLink;
            UserHelper = userHelper;
        }

        [Route("Elemento/ListaBlocos/{id}")]
        public async Task<IActionResult> ListaBlocos(int id)
        {
            List<Div> lista = new List<Div>();

            var pagina = await _context.Pagina.FirstAsync(p => p.IdPagina == id);
            var pedido = await _context.Pedido.Include(p => p.Paginas)
            .FirstAsync(p => p.IdPedido == pagina.pedido_);

            foreach(var page in pedido.Paginas)
            {
                var divs = await RepositoryDiv.includes()
                .Where(d => d.Pagina_ == page.IdPagina).ToListAsync();

                foreach(var d in divs)
                {
                    foreach (var el in d.Elemento)
                    {
                        if(el.Elemento.GetType().Name == "CarouselPagina")
                        {
                            el.Elemento = await 
                                RepositoryCarouselPaginaCarousel.includes()
                                .FirstAsync(cp => cp.IdElemento == el.Elemento.IdElemento);
                        }
                    }
                }

                lista.AddRange(divs);
            }

            ViewBag.Pagina = id;
            return PartialView(lista);
        }

        [Route("Elemento/Lista/{id}/{condicao}")]
        public async Task<IActionResult> Lista(string id, int condicao)
        {
            var numero = Regex.Match(id, @"\d+").Value;
            List<Elemento> lista = new List<Elemento>();
            var listaLink = new List<Link>();
            var listaCarouselPagina = new List<CarouselPagina>();
            var pagina = await _context.Pagina.FirstAsync(p => p.IdPagina == int.Parse(numero));
            var pedido = await _context.Pedido.Include(p => p.Paginas).FirstAsync(p => p.IdPedido == pagina.pedido_);

            var l = RepositoryElemento.includes();

            var l2 = RepositoryLink.includes();

            var l3 = RepositoryCarouselPaginaCarousel.includes();

            ViewBag.elemento = id.Replace(numero, "").Replace("GaleriaElemento", "");

            if(condicao == 0)
            {
                 lista = await l
            .Where(e => e.Pagina_ == int.Parse(numero)).ToListAsync();
            }
            else if(condicao == 1)
            {
                foreach (var page in pedido.Paginas)
                {
                    var itens = await l
                    .Where(e => e.Pagina_ == page.IdPagina).ToListAsync();

                    lista.AddRange(itens);
                }
            }

            if (id.Replace(numero, "").Replace("GaleriaElemento", "") == "Link" && condicao == 0)
            {
                 listaLink = await l2
                .Where(e => e.Pagina_ == int.Parse(numero)).ToListAsync();
                return PartialView(listaLink);
            }
            else if(id.Replace(numero, "").Replace("GaleriaElemento", "") == "Link" && condicao == 1)
            {
                foreach (var page in pedido.Paginas)
                {
                    var itens = await l2
                    .Where(e => e.Pagina_ == int.Parse(numero)).ToListAsync();
                    listaLink.AddRange(itens);
                }
                return PartialView(listaLink);
            }
            else if (id.Replace(numero, "").Replace("GaleriaElemento", "") == "CarouselPagina" && condicao == 0)
            {
                var itens = await l3
                .Where(e => e.Pagina_ == int.Parse(numero)).ToListAsync();               
                return PartialView(listaCarouselPagina);
            }

            else if (id.Replace(numero, "").Replace("GaleriaElemento", "") == "CarouselPagina" && condicao == 1)
            {
                foreach (var page in pedido.Paginas)
                {
                    var itens = await l3
                    .Where(e => e.Pagina_ == int.Parse(numero)).ToListAsync();
                    listaCarouselPagina.AddRange(itens);
                }
                return PartialView(listaCarouselPagina);
            }
            return PartialView(lista);
        }
        
        [Authorize(Roles ="Div")]
        public IActionResult CreateDiv()
        {
            ViewBag.background_ = new SelectList(_context.Background, "IdBackground", "Nome");
            ViewBag.PaginaId = new SelectList(_context.Pagina, "IdPgina", "Titulo");
            return PartialView();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Div")]
        public async Task<string> CreateDiv([FromBody] Div div)
        {

            var v = await RepositoryDiv.SalvarBloco(div);
            ViewBag.background_ = new SelectList(_context.Background, "Idbackground", "Nome", div.background_);
            return v;
        }

        [Authorize(Roles = "Div")]
        public async Task<IActionResult> EditDiv(int? id)
        {
            var div = await _context.Div
                .Include(d => d.Elemento)
                .ThenInclude(d => d.Elemento)
                .FirstAsync(d => d.IdDiv == id);
            if (div == null)
            {
                return NotFound();
            }

            bool permissao = await UserHelper.VerificarPermissaoDiv(id);
            if (!permissao) return PartialView("NoPermission");

            var elements = "";
            foreach (var el in div.Elemento)
            {
                elements += el.Elemento.IdElemento + ", ";
            }

            ViewBag.elementos = elements;
            ViewBag.selecionado = div.background_;
            return PartialView(div);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Div")]
        public async Task<string> EditDiv([FromBody] Div div)
        {
            var v = await RepositoryDiv.EditarBloco(div);
            return "";
        }

        [Route("Elemento/Create/{elemento}")]
        public async Task<IActionResult> Create(string elemento)
        {
            var site = HttpHelper.GetPedidoId();
            var usuario = await UserManager.GetUserAsync(this.User);
            var email = usuario.UserName;
            var condicao = "";
            ViewBag.elemento = elemento;
            ViewBag.condicao = _context.InfoVenda.FirstOrDefault(i => i.ClienteId == usuario.Id);
            ViewBag.condicao2 = _context.InfoEntrega.FirstOrDefault(i => i.ClienteId == usuario.Id);
            ViewBag.condicao3 = _context.ContaBancaria.FirstOrDefault(i => i.ClienteId == usuario.Id);

            var claims = User.Claims.ToList();
            var roles = "";
            foreach(var v in claims)
            {
                roles += v.Value + ", ";
            }
            
            bool permissao2 = await UserHelper.VerificarPermissao2(site, email, condicao, elemento);
            bool permissao = await UserHelper.VerificarPermissao(site, roles, elemento);

            if (!permissao2)
            {
                return PartialView("NoPermission");
            }
            
            if (!permissao) return PartialView("NoPermission");

            return PartialView();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> Create([FromBody] Elemento elemento)
        {
            var v = await RepositoryElemento.salvar(elemento);
            return v;
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            var usuario = await UserManager.GetUserAsync(this.User);
            string verifica = "";
            Elemento elemento;
            ViewBag.condicao = _context.InfoVenda.FirstOrDefault(i => i.ClienteId == usuario.Id);
            ViewBag.condicao2 = _context.InfoEntrega.FirstOrDefault(i => i.ClienteId == usuario.Id);
            ViewBag.condicao3 = _context.ContaBancaria.FirstOrDefault(i => i.ClienteId == usuario.Id);

            var claims = User.Claims.ToList();
            var roles = "";
            foreach (var v in claims)
            {
                roles += v.Value + ", ";
            }

            try
            {
               elemento = await RepositoryElemento.includes()
               .FirstAsync(e => e.IdElemento == id);
            }
            catch (Exception)
            {
                return RedirectToAction("NaoEncontrado");
            }

            var site = HttpHelper.GetPedidoId();
            
            var email = usuario.UserName;
            var sites = await _context.Pedido.Where(c => c.ClienteId == usuario.Id).ToListAsync();

            if (elemento == null)
            {
                return NotFound();
            }

            bool permissao2 = await UserHelper.VerificarPermissao2(site, email, verifica, elemento.GetType().Name);
            bool permissao = await UserHelper.VerificarPermissao(site, roles, elemento.GetType().Name);            

            if (!permissao2)
            {
                return PartialView("NoPermission");
            }
            
            if (!permissao) return PartialView("NoPermission");

            string elementos = "";

            foreach (var dependente in elemento.Despendentes)
            {
                elementos += dependente.ElementoDependente.Dependente.IdElemento + ", ";
            }

            var condicao = await _context.ElementoDependente.Include(e => e.Dependente)
                .FirstOrDefaultAsync(e => e.Dependente.IdElemento == elemento.IdElemento);

            if (condicao == null)
                ViewBag.condicao = false;
            else
                ViewBag.condicao = true;



            var elements = await RepositoryElemento.includes()
                    .Where(e => e.Pagina_ == elemento.Pagina_).ToListAsync();

            if (elemento.GetType().Name == "Link")
            {
                ViewBag.selecionadotexto = elemento.Despendentes[0].ElementoDependente.Dependente.IdElemento;
                if(elemento.Despendentes.Count > 1)
                {
                    ViewBag.selecionadoimagem = elemento.Despendentes[1].ElementoDependente.Dependente.IdElemento;
                }

                var link = (Link)elemento;
                if (!link.UrlLink)
                {
                    ViewBag.selecionadopagina = link.paginaDestinoLink_;
                 //   ViewBag.selecionadopedido = link.div.Pagina.pedido_;

                }
                
            }

            if (elemento.GetType().Name == "Produto")
            {
                ViewBag.selecionadoimagem = elemento.Despendentes[0].ElementoDependente.Dependente.IdElemento;
                var tables = elements.OfType<Table>();

                foreach(var table in tables)
                {
                    foreach(var depe in table.Despendentes)
                    {
                        if(depe.ElementoDependente.Dependente.IdElemento == elemento.IdElemento)
                        {
                            ViewBag.selecionadotable = depe.ElementoDependente.Dependente.IdElemento;
                        }
                    }
                }
            }

            if (elemento.GetType().Name == "Campo")
            {
                var formularios =  elements.OfType<Formulario>();

                foreach (var formulario in formularios)
                {
                    foreach (var depe in formulario.Despendentes)
                    {
                        if (depe.ElementoDependente.Dependente.IdElemento == elemento.IdElemento)
                        {
                            ViewBag.selecionadoformulario = depe.ElementoDependente.Dependente.IdElemento;
                        }
                    }
                }
            }

            if (elemento.GetType().Name == "CarouselPagina")
            {
                var carouselPagina = await RepositoryCarouselPaginaCarousel.includes()
                    .FirstAsync(e => e.IdElemento == elemento.IdElemento);

                var pages = "";
                foreach (var pcp in carouselPagina.Paginas)
                {
                    pages += pcp.Pagina.IdPagina + ", ";
                }
                ViewBag.Paginas = pages;
            }


            ViewBag.elementos = elementos;
           // ViewBag.selecioando = elemento.div_;
            
            return PartialView(elemento);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> Edit([FromBody] Elemento elemento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await RepositoryElemento.Editar(elemento);
                }
                catch (Exception ex)
                {
                        return "" + ex.Message;
                    
                }
                return "";
            }
           // ViewData["div_"] = new SelectList(_context.Div, "IdDiv", "Nome", elemento.div_);
            return "";
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Div")]
        public async Task<JsonResult> AlterarPosicaoBloco(IList<int> numeros, int? id)
        {
            //  db.Configuration.ProxyCreationEnabled = false;
            try
            {
                var pagina = await _context.Pagina.FirstAsync(p => p.IdPagina == id);
                var site = pagina.pedido_;
                var usuario = await UserManager.GetUserAsync(this.User);
                var sites = _context.Pedido.Where(c => c.ClienteId == usuario.Id).ToList();
                if (await _context.Permissao.FirstOrDefaultAsync(p => p.Site == site
                && p.UserName == usuario.UserName && p.NomePermissao == "Div") == null)
                {
                    return Json("");
                }
            }
            catch (Exception)
            {
                return Json("");
            }

            for (int i = 0; i < numeros.Count; i++)
            {
                var bloco = await _context.Div.FirstAsync(d => d.IdDiv == numeros[i]);
                bloco.Ordem = i;
                _context.Entry(bloco).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
            return Json("valor");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Elemento")]
        public async Task<JsonResult> AlterarPosicaoElemento(IList<int> numeros, int? id)
        {
            //  db.Configuration.ProxyCreationEnabled = false;
            try
            {
                var pagina = await _context.Pagina.FirstAsync(p => p.IdPagina == id);
                var site = pagina.pedido_;
                var usuario = await UserManager.GetUserAsync(this.User);
                var sites = _context.Pedido.Where(c => c.ClienteId == usuario.Id).ToList();
                if (await _context.Permissao.FirstOrDefaultAsync(p => p.Site == site
                && p.UserName == usuario.UserName && p.NomePermissao == "Elemento") == null)
                {
                    return Json("");
                }
            }
            catch (Exception)
            {
                return Json("");
            }

            for (int i = 0; i < numeros.Count; i++)
            {
                var elemento = await _context.Elemento.FirstAsync(d => d.IdElemento == numeros[i]);
                elemento.Ordem = i;
                _context.Entry(elemento).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
            return Json("valor");
        }
        
        public IActionResult NoPermission()
        {
            return PartialView();
        }

        public IActionResult NaoEncontrado()
        {
            return PartialView();
        }
    }
}
