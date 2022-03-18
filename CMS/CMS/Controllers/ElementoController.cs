using business.Back;
using business.business;
using business.business.carousel;
using business.business.Elementos;
using business.business.Elementos.element;
using business.business.Elementos.imagem;
using business.business.Elementos.produto;
using business.business.Elementos.texto;
using business.business.link;
using business.div;
using business.Join;
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
        public IUserHelper UserHelper { get; }
        public IRepositoryPagina epositoryPagina { get; }

        public ElementoController(ApplicationDbContext context, IRepositoryElemento repositoryElemento,
            IRepositoryDiv repositoryDiv, UserManager<IdentityUser> userManager, IHttpHelper httpHelper,
            IUserHelper userHelper, IRepositoryPagina repositoryPagina)
        {
            _context = context;
            RepositoryElemento = repositoryElemento;
            RepositoryDiv = repositoryDiv;
            UserManager = userManager;
            HttpHelper = httpHelper;
            UserHelper = userHelper;
            epositoryPagina = repositoryPagina;
        }        

        [Route("Elemento/Lista/{id}")]
        public async Task<IActionResult> Lista(string id)
        {
            var arr = id.Split('-');
            var numero = int.Parse(arr[1]);
            var tipo = arr[0].Replace("GaleriaElemento", "");
            List<Elemento> lista =  await _context.Elemento
                .Include(e => e.Imagem)
                .Include(e => e.Texto)
                .Include(e => e.Table)
                .Include(e => e.Formulario)
                .Include(e => e.Dependentes).ThenInclude(e => e.Elemento)
                .Include(e => e.Dependentes).ThenInclude(e => e.ElementoDependente)
                .Include(e => e.Paginas).ThenInclude(e => e.Pagina)
                .Include(e => e.Paginas).ThenInclude(e => e.Elemento)
                .Where(e => e.Pagina_ == numero &&  e.GetType().Name == tipo).ToListAsync();            

            Pagina pagina = new Pagina();
            pagina.Margem = false;
            pagina.MostrarDados = 1;
            pagina.Div = new List<DivPagina>();

            pagina.Div.AddRange(new List<DivPagina> {
                new DivPagina{ Div = new DivComum() }, new DivPagina{ Div = new DivComum() },
                new DivPagina{ Div = new DivComum() }, new DivPagina{ Div = new DivComum() },
                new DivPagina{ Div = new DivComum() }, new DivPagina{ Div = new DivComum() },
                new DivPagina{ Div = new DivComum() }
            });
            
            for (int i = 0; i <= 6; i++)
            {
                if (i <= 6)
                    pagina.Div[i].Div = new DivComum
                    {
                        Background = new BackgroundCor
                        {
                            backgroundTransparente = true,
                            Cor = "transparent"
                        }
                    };
            }

            if (RepositoryPagina.paginas.Count == 0)
                RepositoryPagina.paginas = await epositoryPagina.MostrarPageModels();

            foreach (var div in pagina.Div)
            {
                foreach (var item in div.Div.Elemento)
                {
                    if (item.Elemento is CarouselPagina)
                    {
                        foreach (var item2 in item.Elemento.Paginas)
                            item2.Pagina = RepositoryPagina.paginas.First(p => p.Id == item2.PaginaId);
                    }
                }
            }

            List<DivElemento> listaDivElemento = new List<DivElemento>();
            foreach (var item in lista)
                listaDivElemento.Add(new DivElemento { Div = pagina.Div[6].Div, Elemento = item });

            pagina.Div[6].Div.Elemento = listaDivElemento;
            pagina.Div[6].Div.Colunas = "auto auto auto";

            string html = await epositoryPagina.renderizarPaginaComCarousel(pagina);
            ViewBag.Html = html;
            return PartialView(pagina);
        }        
                
        [Route("Elemento/Create/{elemento}/{pagina}")]
        public async Task<IActionResult> Create(string elemento, int pagina)
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
            
            if (elemento == "Imagem")            ele =  new Imagem         ();
            if (elemento == "Show")              ele =  new Show           ();
            if (elemento == "Video")             ele =  new Video          ();
            if (elemento == "Texto")             ele =  new Texto          ();
            if (elemento == "Table")             ele =  new Table          ();
            if (elemento == "Roupa")             ele =  new Roupa          ();
            if (elemento == "Calcado")           ele =  new Calcado        ();
            if (elemento == "Alimenticio")       ele =  new Alimenticio    ();
            if (elemento == "Acessorio")         ele =  new Acessorio      ();
            if (elemento == "LinkBody")          ele =  new LinkBody       ();
            if (elemento == "Formulario")        ele =  new Formulario     ();
            if (elemento == "Dropdown")          ele =  new Dropdown       ();
            if (elemento == "CarouselPagina")    ele =  new CarouselPagina ();
            if (elemento == "CarouselImg")       ele =  new CarouselImg    ();
            if (elemento == "Campo")             ele =  new Campo          ();

            var pedido = await _context.Pedido.Include(p => p.Paginas).Include(p => p.Pastas).FirstAsync(p => p.Id == site);
            var elementos = new List<Elemento>();
            var els = await _context.Elemento.Where(elem => elem.Pagina_ == pagina).ToListAsync();

            List<Pagina> lista = new List<Pagina>();
            lista.Add(new Pagina { Id = 0, Titulo = "[[ Escolha uma pagina ]]" });
            var page = await _context.Pagina.Include(p => p.Story)
            .ThenInclude(p => p.Pagina).FirstAsync(p => p.Id == pagina);
            lista.AddRange(page.Story.Pagina);
            ViewBag.PaginaEscolhida = new SelectList(lista, "Id", "Titulo");

            elementos.AddRange(els);
            
            ViewBag.condicao = ! page.Layout;

            PreencherCombo(ele, pedido, elementos);

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

            var pedido = await _context.Pedido.Include(p => p.Paginas).Include(p => p.Pastas).FirstAsync(p => p.Id == site);
            var elementos = new List<Elemento>();
            
                var els = await _context.Elemento.Where(ele => ele.Pagina_ == elemento.Pagina_).ToListAsync();
                elementos.AddRange(els);           

            bool permissao2 = await UserHelper.VerificarPermissao2(site, email, verifica, elemento.GetType().Name);
            bool permissao = await UserHelper.VerificarPermissao(site, roles, elemento.GetType().Name);

            if (!permissao2)
            {
                return PartialView("NoPermission");
            }

            if (!permissao) return PartialView("NoPermission");

            List<Pagina> lista = new List<Pagina>();
            lista.Add(new Pagina { Id = 0, Titulo = "[[ Escolha uma pagina ]]" });
            var page = await _context.Pagina.Include(p => p.Story)
            .ThenInclude(p => p.Pagina).FirstAsync(p => p.Id == elemento.Pagina_);
            lista.AddRange(page.Story.Pagina);
            if (elemento.PaginaEscolhida == null) elemento.PaginaEscolhida = 0;
            ViewBag.PaginaEscolhida = new SelectList(lista, "Id", "Titulo", elemento.PaginaEscolhida);

            ViewBag.condicao = ! page.Layout;

            PreencherCombo(elemento, pedido, elementos);

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

        private void PreencherCombo(Elemento elemento, Pedido pedido, List<Elemento> elementos)
        {
            if (elemento is LinkBody)
            {
                var els = new List<Elemento>();
                els.Add(new Imagem { Id = 0, Nome = "[[ Escolha uma imagem ]]" });
                els.AddRange(elementos.OfType<Imagem>().ToList());
                var link = (LinkBody)elemento;
                ViewBag.ImagemId = new SelectList(els, "Id", "NomeComId", link.ImagemId);
                ViewBag.TextoId = new SelectList(elementos.OfType<Texto>().ToList(), "Id", "NomeComId", link.TextoId);
            }           

            if (elemento is Campo)
            {
                var c = (Campo)elemento;
                ViewBag.FormularioId = new SelectList(elementos.OfType<Formulario>().ToList(), "Id", "NomeComId", c.FormularioId);
            }

            if (elemento is Produto)
            {
                var c = (Produto)elemento;
                ViewBag.FormularioId = new SelectList(elementos.OfType<Table>().ToList(), "Id", "NomeComId", c.TableId);
            }
        }
    }
}