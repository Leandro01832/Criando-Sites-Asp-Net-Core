﻿using business.Back;
using business.business;
using business.business.carousel;
using business.business.Elementos;
using business.business.Elementos.element;
using business.business.Elementos.imagem;
using business.business.Elementos.produto;
using business.business.Elementos.texto;
using business.business.link;
using business.div;
using CMS.Data;
using CMS.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMS.Controllers
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
            
            var pedido = await _context.Pedido.Include(p => p.Paginas)
            .FirstAsync(p => p.Id == HttpHelper.GetPedidoId());

            foreach (var page in pedido.Paginas)
            {
                var divs = await RepositoryDiv.includes()
                .Where(d => d.Pagina_ == page.Id).ToListAsync();
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
            var ped = HttpHelper.GetPedidoId();
            var pedido = await _context.Pedido.FindAsync(ped);

            if (condicao == 0)            
                lista = await _context.Elemento
                .Where(e => e.Pagina_ == int.Parse(numero))
                .Cast<Elemento>().ToListAsync();            

            else if (condicao == 1)
            foreach (var page in pedido.Paginas)
            lista.AddRange(await _context.Elemento
            .Where(e => e.Pagina_ == page.Id)
            .Cast<Elemento>().ToListAsync());           

            return PartialView(lista);
        }

        [Authorize(Roles = "Div")]
        [Route("Elemento/CreateDiv/{div}")]
        public async Task<IActionResult> CreateDiv(string div)
        {
            Div bloco = null;
            if (div == "DivComum") bloco = new DivComum();
            if (div == "DivFixo") bloco = new DivFixo();

            var backgrounds = new List<Background>();
            var site = HttpHelper.GetPedidoId();
            var pedido = await _context.Pedido.Include(p => p.Paginas).FirstAsync(p => p.Id == site);
            
            
            return PartialView(bloco);
        }

        [Authorize(Roles = "Div")]
        public async Task<IActionResult> EditDiv(int? id)
        {
            var div = await _context.Div
                .Include(d => d.Elemento)
                .ThenInclude(d => d.Elemento)
                .FirstAsync(d => d.Id == id);
            if (div == null)
            {
                return NotFound();
            }

            bool permissao = await UserHelper.VerificarPermissaoDiv(id);
            if (!permissao) return PartialView("NoPermission");

            var elements = "";
            foreach (var el in div.Elemento)
            {
                elements += el.Elemento.Id + ", ";
            }
            
            var site = HttpHelper.GetPedidoId();
            var pedido = await _context.Pedido.Include(p => p.Paginas).FirstAsync(p => p.Id == site);
            

            ViewBag.elementos = elements;
            return PartialView(div);
        }

        #region Create-Edit-Div
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Div")]
        public async Task<string> _DivComum([FromBody] DivComum div)
        {
            try
            {
                if (div.Id == 0)
                    return await RepositoryDiv.SalvarBloco(div);
                else
                    return await RepositoryDiv.EditarBloco(div);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Div")]
        public async Task<string> _DivFixo([FromBody] DivFixo div)
        {
            try
            {
                if (div.Id == 0)
                    return await RepositoryDiv.SalvarBloco(div);
                else
                    return await RepositoryDiv.EditarBloco(div);
            }
            catch (Exception ex) { return ex.Message; }
        } 
        #endregion
                
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
            foreach (var v in claims)
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

            Elemento ele = null;

            if (elemento == "TextoDependente") ele =          new TextoDependente         ();
            if (elemento == "Imagem") ele =                   new Imagem                  ();
            if (elemento == "ImagemDependente") ele =         new ImagemDependente        ();
            if (elemento == "Show") ele =                     new Show                    ();
            if (elemento == "Video") ele =                    new Video                   ();
            if (elemento == "Texto") ele =                    new Texto                   ();
            if (elemento == "Table") ele =                    new Table                   ();
            if (elemento == "Roupa") ele =                    new Roupa                   ();
            if (elemento == "Calcado") ele =                  new Calcado                 ();
            if (elemento == "Alimenticio") ele =              new Alimenticio             ();
            if (elemento == "Acessorio") ele =                new Acessorio               ();
            if (elemento == "LinkMenu") ele =                 new LinkMenu                ();
            if (elemento == "LinkBody") ele =                 new LinkBody                ();
            if (elemento == "Formulario") ele =               new Formulario              ();
            if (elemento == "Dropdown") ele =                 new Dropdown                ();
            if (elemento == "CarouselPagina") ele =           new CarouselPagina          ();
            if (elemento == "CarouselImg") ele =              new CarouselImg             ();
            if (elemento == "Campo") ele =                    new Campo                   ();


            return PartialView(ele);
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
                .FirstAsync(e => e.Id == id);
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

            var pedido = await _context.Pedido.Include(p => p.Paginas).FirstAsync(p => p.Id == site);

            var elementos = new List<Elemento>();
            foreach (var item in pedido.Paginas)
            {
                var pag = await _context.Pagina.Include(p => p.Div)
                    .ThenInclude(p => p.Div)
                    .ThenInclude(p => p.Elemento)
                    .FirstAsync(p => p.Id == item.Id);
                foreach (var item2 in pag.Div)
                    foreach (var item3 in item2.Div.Elemento)
                        elementos.Add(item3.Elemento);

            }

            var pastas = new List<PastaImagem>();
            foreach (var item in pedido.Paginas)
            {
                var pag = await _context.Pagina.Include(p => p.Pastas ).FirstAsync(p => p.Id == item.Id);
                pastas.AddRange(pag.Pastas);
            }

            bool permissao2 = await UserHelper.VerificarPermissao2(site, email, verifica, elemento.GetType().Name);
            bool permissao = await UserHelper.VerificarPermissao(site, roles, elemento.GetType().Name);

            if (!permissao2)
            {
                return PartialView("NoPermission");
            }

            if (!permissao) return PartialView("NoPermission");

            
             if (elemento is LinkBody)
            {
               var link = (LinkBody)elemento;
                ViewBag.PaginaId = new SelectList(pedido.Paginas, "Id", "Nome", link.PaginaId); 
                ViewBag.TextoId = new SelectList(elementos, "Id", "Nome", link.TextoId);
            }    
             else if (elemento is LinkMenu)
            {
                var link = (LinkMenu)elemento;
                ViewBag.PaginaId = new SelectList(pedido.Paginas, "Id", "Nome", link.PaginaId);
                ViewBag.TextoId = new SelectList(elementos, "Id", "Nome", link.TextoId);
            }

             if(elemento is Imagem)
            {
                var imagem = (Imagem)elemento;
                ViewBag.PastaImagemId = new SelectList(pastas, "Id", "Nome", imagem.PastaImagemId);
            }

            if (elemento  is Campo)
            {
                var c = (Campo)elemento;
                ViewBag.FormularioId = new SelectList(elementos, "Id", "Nome", c.FormularioId);
            }

            if (elemento  is ProdutoDependente)
            {
                var c = (ProdutoDependente)elemento;
                ViewBag.FormularioId = new SelectList(elementos, "Id", "Nome", c.TableId);
            }

            return PartialView(elemento);
        }

        #region Create-Edit-Elemento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _Imagem([FromBody] Imagem elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch(Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _ImagemDependente([FromBody] ImagemDependente elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch(Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _Show([FromBody] Show elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _Video([FromBody] Video elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _Texto([FromBody] Texto elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _Table([FromBody] Table elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _Roupa([FromBody] Roupa elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _Calcado([FromBody] Calcado elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _Alimenticio([FromBody] Alimenticio elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _Acessorio([FromBody] Acessorio elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _LinkMenu([FromBody] LinkMenu elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _LinkBody([FromBody] LinkBody elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _Formulario([FromBody] Formulario elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _Dropdown([FromBody] Dropdown elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _CarouselPagina([FromBody] CarouselPagina elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _CarouselImg([FromBody] CarouselImg elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> _Campo([FromBody] Campo elemento)
        {
            try
            {
                if (elemento.Id == 0)
                    return await RepositoryElemento.salvar(elemento);
                else
                    return await RepositoryElemento.Editar(elemento);
            }
            catch (Exception ex) { return ex.Message; }
        } 
        #endregion
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Div")]
        public async Task<JsonResult> AlterarPosicaoBloco(IList<int> numeros, int? id)
        {
            //  db.Configuration.ProxyCreationEnabled = false;
            try
            {
                var pagina = await _context.Pagina.FirstAsync(p => p.Id == id);
                var site = pagina.PedidoId;
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
                var bloco = await _context.Div.FirstAsync(d => d.Id == numeros[i]);
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
                var pagina = await _context.Pagina.FirstAsync(p => p.Id == id);
                var site = pagina.PedidoId;
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
                var elemento = await _context.Elemento.FirstAsync(d => d.Id == numeros[i]);
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