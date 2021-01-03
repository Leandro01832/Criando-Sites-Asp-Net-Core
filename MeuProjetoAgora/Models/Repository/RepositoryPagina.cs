using MeuProjetoAgora.Data;
using MeuProjetoAgora.Models.business;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NVelocity;
using NVelocity.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeuProjetoAgora.Models.Join;
using MeuProjetoAgora.Models.business.Elemento;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Identity;

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryPagina
    {
        Task<IList<Pagina>> MostrarPageModels();
        Task<string> renderizarPagina(Pagina pagina);
        Task<string> renderizarPaginaComMenuDropDown(Pagina pagina);
        Task<bool> verificaTable(Pagina pagina);
        void verificaBackground(Pagina pagina);
        int[] criarRows(Pagina pagina);
        void CriarBackgrounds(Pagina pag, List<Imagem> imagens);
        Pagina LinksPagina(Pagina pagina);
        void criandoArquivoHtml(Pagina pagina);
        byte[] FazerDownload(Pedido site);
        Task<string> renderizarPaginaComCarousel(Pagina pagina);
        Task BlocosdaPagina(Pagina pagina);
        Task<Pagina> TestarPagina(string id);
        IIncludableQueryable<Pagina, Div> includes();
    }

    public class RepositoryPagina : BaseRepository<Pagina>, IRepositoryPagina
    {
        public RepositoryPagina(IConfiguration configuration, ApplicationDbContext contexto,
            IRepositoryBackground repositoryBackground, IHostingEnvironment hostingEnvironment,
             SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
              IHttpContextAccessor contextAccessor, IRepositoryDiv repositoryDiv,
              IRepositoryCarouselPaginaCarousel repositoryCarouselPaginaCarousel) : base(configuration, contexto)
        {
            RepositoryBackground = repositoryBackground;
            HostingEnvironment = hostingEnvironment;
            SignInManager = signInManager;
            UserManager = userManager;
            ContextAccessor = contextAccessor;
            RepositoryDiv = repositoryDiv;
            RepositoryCarouselPaginaCarousel = repositoryCarouselPaginaCarousel;
        }

        string path = Directory.GetCurrentDirectory();

        public string MenuDropDown { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/MenuDropDown.cshtml")); } }

        //529
        public string CodigoCss2 { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/DocCss.cshtml")); } }

        //142 linhas
        public string CodigoCss { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/DocCss2.cshtml")); } }

        public string CodigoCssMenuDropDwn { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/DocCss2MenuDropDown.cshtml")); } }

        //119 linhas
        public string CodigoBloco { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/DocBloco.cshtml")); } }
        
        //785 linhas
        public string CodigoProducao { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/DocProducao.cshtml")); } }

        public string CodigoHtmlInicio { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/html/DocHtmlInicio.cshtml")); } }
        public string CodigoHtml1 { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/html/DocImagem.cshtml")); } }
        public string CodigoHtml2 { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/html/DocTexto.cshtml")); } }
        public string CodigoHtml3 { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/html/DocCarousel.cshtml")); } }
        public string CodigoHtml4 { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/html/DocFormulario.cshtml")); } }
        public string CodigoHtml5 { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/html/DocLink.cshtml")); } }
        public string CodigoHtml6 { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/html/DocTable.cshtml")); } }
        public string CodigoHtml7 { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/html/DocVideo.cshtml")); } }
        public string CodigoHtml8 { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/html/DocCarouselPagina.cshtml")); } }
        public string CodigoHtmlFim { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/html/DocHtmlFim.cshtml")); } }
        
        public string CodigoModal { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/modal.cshtml")); } }
        
        public string CodigoMusic { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/music.cshtml")); } }

        public string CodigoCarousel { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/Carousel.cshtml")); } }

        public string Html { get { return Path.Combine(path + "/wwwroot/Html/"); } }

        public IRepositoryBackground RepositoryBackground { get; }
        public IHostingEnvironment HostingEnvironment { get; }
        public SignInManager<IdentityUser> SignInManager { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IHttpContextAccessor ContextAccessor { get; }
        public IRepositoryDiv RepositoryDiv { get; }
        public IRepositoryCarouselPaginaCarousel RepositoryCarouselPaginaCarousel { get; }

        public async Task<IList<Pagina>> MostrarPageModels()
        {         

            var lista = await  includes()
            .ToListAsync();

            foreach (var pag in lista)
            {
                foreach (var b in pag.Div)
                {
                    foreach (var e in b.Div.Elemento)
                    {
                        if(e.Elemento.GetType().Name == "CarouselPagina")
                        {
                            e.Elemento = await RepositoryCarouselPaginaCarousel.IncluiPaginas(e.Elemento.IdElemento);
                        }
                    }
                }

            }

            foreach (var pag in lista)
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
            }

            return  lista;
        }

        public async Task<string> renderizarPagina(Pagina pagina)
        {
            // desenvolvimento
            //var resultado = await renderizar(pagina, CodigoCss + CodigoBloco
            //    + CodigoCss2 + CodigoHtmlInicio + CodigoHtml1 + CodigoHtml2 + CodigoHtml3 + CodigoHtml4
            //    + CodigoHtml5 + CodigoHtml6 + CodigoHtml7 + CodigoHtml8 + CodigoHtmlFim + CodigoMusic
            //    + CodigoModal);

            //producao
            var resultado = await renderizar(pagina, CodigoCss + CodigoBloco
               + CodigoCss2 + CodigoProducao + CodigoMusic  + CodigoModal);
            return resultado;
        }

        public void verificaBackground(Pagina pagina)
        {
            foreach (var fundo in pagina.Background)
            {
                if (fundo.backgroundTransparente)
                {
                    fundo.Cor = "transparent";
                }
            }

            foreach (var dp in pagina.Div)
            {
                if (dp.Div.Background.backgroundTransparente)
                {
                    dp.Div.Background.Cor = "transparent";
                }
            }
        }

        public async Task<bool> verificaTable(Pagina pagina)
        {
            bool verifica = false;
            foreach (var pag in pagina.Pedido.Paginas)
            {
                var ele = await contexto.Elemento.Include(e => e.div)
                    .ThenInclude(e => e.Div)
                    .OfType<Table>()
                .FirstOrDefaultAsync(e => e.Pagina_ == pag.IdPagina);

                if (ele != null)
                {
                    verifica = true;
                }
            }
            return verifica;
        }

        public int[] criarRows(Pagina pagina)
        {
            int espaco = 0;
            int rows = 0;

            foreach (var bloco in pagina.Div.Select(d => d.Div))
            {
                if (bloco.Divisao == "col-md-12" || bloco.Divisao == "col-sm-12")
                    espaco += 12;

                if (bloco.Divisao == "col-md-6" || bloco.Divisao == "col-sm-6")
                    espaco += 6;

                if (bloco.Divisao == "col-md-4" || bloco.Divisao == "col-sm-4")
                    espaco += 4;

                if (bloco.Divisao == "col-md-3" || bloco.Divisao == "col-sm-3")
                    espaco += 3;

                if (bloco.Divisao == "col-md-2" || bloco.Divisao == "col-sm-2")
                    espaco += 2;


            }

            rows = espaco / 12;

            rows += 1;

            int[] numero = new int[rows];

            for (int i = 0; i < numero.Length; i++)
            {
                numero[i] += i + 1;

            }

            return numero;
        }

        public void CriarBackgrounds(Pagina pag, List<Imagem> imagens)
        {
            RepositoryBackground.CriarBackground(pag, imagens);
        }

        public Pagina LinksPagina(Pagina pagina)
        {
            
            if (pagina.Facebook == null)
            {
                pagina.Facebook = "vazio";
            }
            if (pagina.Twiter == null)
            {
                pagina.Twiter = "vazio";
            }
            if (pagina.Instagram == null)
            {
                pagina.Instagram = "vazio";
            }

            return pagina;
        }

        public async Task<string> renderizarPaginaComMenuDropDown(Pagina pagina)
        {
            //desenvolvimento
            //var resultado = await renderizar(pagina, MenuDropDown + CodigoCssMenuDropDwn +
            //    CodigoBloco + CodigoCss2 + CodigoHtmlInicio + CodigoHtml1 + CodigoHtml2 + CodigoHtml3
            //    + CodigoHtml4 + CodigoHtml5 + CodigoHtml6 + CodigoHtml7 + CodigoHtml8 + CodigoHtmlFim
            //    + CodigoMusic + CodigoModal);

            //producao
            var resultado = await renderizar(pagina, MenuDropDown + CodigoCssMenuDropDwn +
               CodigoBloco + CodigoCss2 + CodigoProducao  + CodigoMusic + CodigoModal);
            return resultado;
        }

        public async Task<string> renderizarPaginaComCarousel(Pagina pagina)
        {
            // desenvolvimento
            //var resultado = await renderizar(pagina, CodigoCss + CodigoBloco + CodigoCss2 +
            //    CodigoHtmlInicio + CodigoHtml1 + CodigoHtml2 + CodigoHtml3 + CodigoHtml4
            //    + CodigoHtml5 + CodigoHtml6 + CodigoHtml7 + CodigoHtml8 + CodigoHtmlFim + CodigoMusic
            //    + CodigoCarousel + CodigoModal);

            var resultado = await renderizar(pagina, CodigoCss + CodigoBloco + CodigoCss2 +
                CodigoProducao + CodigoMusic
                + CodigoCarousel + CodigoModal);
            return resultado;
        }

        public void criandoArquivoHtml(Pagina pagina)
        {
            string path = this.HostingEnvironment.WebRootPath + "\\Html\\" + $"\\{pagina.Pedido.DominioTemporario}\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(
                Html + $"{pagina.Pedido.DominioTemporario}/" +
                pagina.Titulo.Trim() +
                ".html", false))
            {   
                sw.WriteLine("<div class='content'>");             
                sw.WriteLine(pagina.Html);
                sw.WriteLine("</div>"); 
                sw.Close();
            }
        }

        public byte[] FazerDownload(Pedido site)
        {
            foreach (var pag in site.Paginas)
            {
                criandoArquivoHtml(pag);
            }

            var webroot = this.HostingEnvironment.WebRootPath;
            var filename = $"{site.DominioTemporario}.zip";
            var tempOutput = webroot + $"/Html/{site.DominioTemporario}/" + filename;

            using (ZipOutputStream zipOutputStream = new ZipOutputStream(System.IO.File.Create(tempOutput)))
            {
                zipOutputStream.SetLevel(9);
                byte[] buffer = new byte[4096];
                var imageList = new List<string>();

                foreach (var pag in site.Paginas)
                {
                    imageList.Add(webroot + "/Html" + $"/{site.DominioTemporario}/{pag.Titulo.Trim()}.html");
                }

                for (int i = 0; i < imageList.Count; i++)
                {
                    ZipEntry entry = new ZipEntry(Path.GetFileName(imageList[i]));
                    entry.DateTime = DateTime.Now;
                    entry.IsUnicodeText = true;
                    zipOutputStream.PutNextEntry(entry);

                    using (FileStream fileStream = System.IO.File.OpenRead(imageList[i]))
                    {
                        int sourcebytes;
                        do
                        {
                            sourcebytes = fileStream.Read(buffer, 0, buffer.Length);
                            zipOutputStream.Write(buffer, 0, sourcebytes);
                        } while (sourcebytes > 0);
                    }
                }

                zipOutputStream.Finish();
                zipOutputStream.Flush();
                zipOutputStream.Close();
            }

            byte[] finalResult = System.IO.File.ReadAllBytes(tempOutput);

            if (System.IO.File.Exists(tempOutput))
            {
                System.IO.File.Delete(tempOutput);
            }

            if (finalResult == null || !finalResult.Any())
            {
                throw new Exception(string.Format("Nothing Found"));
            }

            return finalResult;
        }

        public async Task BlocosdaPagina(Pagina pagina)
        {
            var site1 = await contexto.Pedido.FirstAsync(p => p.IdPedido == pagina.pedido_);
            var cliente = site1.ClienteId;

            string blocosGravados = "";
            var array = pagina.Blocos.Replace(" ", "").Split(',');

            if (pagina.Div != null)
            {

                foreach (var divPagina in pagina.Div)
                {
                    blocosGravados += divPagina.Div.IdDiv + ", ";
                    if (!pagina.Blocos.Contains(divPagina.Div.IdDiv.ToString()))
                    {
                        DivPagina dp;
                        try
                        {
                            dp = await contexto.DivPagina
                            .Include(de => de.Pagina)
                            .Include(de => de.Div)
                            .FirstOrDefaultAsync(e => e.Div.IdDiv == divPagina.Div.IdDiv &&
                            e.Pagina.IdPagina == divPagina.Pagina.IdPagina);
                        }
                        catch (Exception)
                        {
                            dp = null;
                        }
                        if (dp != null)
                        {
                            contexto.DivPagina.Remove(dp);
                        }
                    }
                }
                await contexto.SaveChangesAsync();
            }

            foreach (var id in array)
            {
                var page = await contexto.Pagina.Include(d => d.Div).FirstAsync(d => d.IdPagina == pagina.IdPagina);
                Div div;
                bool MesmoCliente = false;

                var Bloco = await contexto.Div.FirstOrDefaultAsync(d => d.IdDiv == int.Parse(id));                

                if (Bloco != null) 
                {
                    var paginaBloco = contexto.Pagina.First(p => p.IdPagina == Bloco.Pagina_);
                    var site = contexto.Pedido.First(p => p.IdPedido == paginaBloco.pedido_);
                    if (site.ClienteId == cliente)
                    {
                        MesmoCliente = true;
                    }
                }
                

                try
                {
                    div = await contexto.Div.FirstOrDefaultAsync(d => d.IdDiv == int.Parse(id));
                }
                catch (Exception)
                {
                    div = null;
                }

                bool possuiTableProduto = await RepositoryDiv.VerificarExistenciaTable(id);

                if (div != null && MesmoCliente && !blocosGravados.Contains(id) && !possuiTableProduto)
                {
                    page.IncluiDiv(div);
                    await contexto.SaveChangesAsync();
                }
                   
            }
        }

        public async Task<string> renderizar(Pagina pagina, string TextoHtml)
        {
            int[] numero = criarRows(pagina);

            pagina = LinksPagina(pagina);

            verificaBackground(pagina);

            var condicao = await verificaTable(pagina);

            var condicaoLogin = SignInManager.IsSignedIn(ContextAccessor.HttpContext.User);

            var username = UserManager.GetUserName(ContextAccessor.HttpContext.User);

            Velocity.Init();
            var Modelo = new
            {
                Usuario = username,
                Login = condicaoLogin,
                Pedidos = condicao,
                Musicbool = pagina.Music,
                arquivoMusic = pagina.ArquivoMusic,
                Pagina = pagina,
                titulo = pagina.Titulo,
                facebook = pagina.Facebook,
                twiter = pagina.Twiter,
                instagram = pagina.Instagram,
                background = pagina.Background.OrderBy(b => b.IdBackground).ToList()[0],
                background_topo = pagina.Background.OrderBy(b => b.IdBackground).ToList()[1],
                background_menu = pagina.Background.OrderBy(b => b.IdBackground).ToList()[2],
                background_borda_esquerda = pagina.Background.OrderBy(b => b.IdBackground).ToList()[3],
                background_borda_direita = pagina.Background.OrderBy(b => b.IdBackground).ToList()[4],
                background_bloco = pagina.Background.OrderBy(b => b.IdBackground).ToList()[5],
                divs = pagina.Div.OrderBy(d => d.Div.Ordem).ToList(),
                Rows = numero,
                espacamento = 0,
                indice = 1

            };

            var velocitycontext = new VelocityContext();
            velocitycontext.Put("model", Modelo);
            velocitycontext.Put("divs", pagina.Div.OrderBy(d => d.Div.Ordem).ToList());
            var html = new StringBuilder();
            bool result = Velocity.Evaluate(velocitycontext, new StringWriter(html), "NomeParaCapturarLogError",
            new StringReader(TextoHtml));

            return html.ToString();
        }

        public async Task<Pagina> TestarPagina(string id)
        {
            Pagina pag;
            try
            {
                pag = await contexto.Pagina.FirstOrDefaultAsync(e => e.IdPagina == int.Parse(id));
            }
            catch (Exception)
            {
                pag = null;
            }
            return pag;
        }

        public IIncludableQueryable<Pagina, Div> includes()
        {
            var include = dbSet
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
