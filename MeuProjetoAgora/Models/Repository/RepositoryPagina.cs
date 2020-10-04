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

namespace MeuProjetoAgora.Models.Repository
{
    public interface IRepositoryPagina
    {
        Task<IList<Pagina>> MostrarPageModels();
        string renderizarPagina(Pagina pagina);
        string renderizarPaginaComMenuDropDown(Pagina pagina);
        bool verificaTable(Pagina pagina);
        void verificaBackground(Pagina pagina);
        int[] criarRows(Pagina pagina);
        void CriarBackgrounds(Pagina pag, List<Imagem> imagens);
        Pagina LinksPagina(Pagina pagina);
        void criandoArquivoHtml(Pagina pagina);
        byte[] FazerDownload(Pedido site);
        string renderizarPaginaComCarousel(Pagina pagina);
    }

    public class RepositoryPagina : BaseRepository<Pagina>, IRepositoryPagina
    {
        public RepositoryPagina(IConfiguration configuration, ApplicationDbContext contexto,
            IRepositoryBackground repositoryBackground, IHostingEnvironment hostingEnvironment) : base(configuration, contexto)
        {
            RepositoryBackground = repositoryBackground;
            HostingEnvironment = hostingEnvironment;
        }

        string path = Directory.GetCurrentDirectory();

        public string MenuDropDown { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/MenuDropDown.cshtml")); } }

        public string CodigoCss2 { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/DocCss.cshtml")); } }

        public string CodigoCss { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/DocCss2.cshtml")); } }

        public string CodigoCssMenuDropDwn { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/DocCss2MenuDropDown.cshtml")); } }

        public string CodigoBloco { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/DocBloco.cshtml")); } }

        public string CodigoHtml { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/DocHtml.cshtml")); } }
        
        public string CodigoModal { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/modal.cshtml")); } }
        
        public string CodigoMusic { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/music.cshtml")); } }

        public string CodigoCarousel { get { return File.ReadAllText(Path.Combine(path + "/wwwroot/Arquivotxt/Carousel.cshtml")); } }

        public string Html { get { return Path.Combine(path + "/wwwroot/Html/"); } }

        public IRepositoryBackground RepositoryBackground { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public async Task<IList<Pagina>> MostrarPageModels()
        {
            var lista = await  dbSet
                .Include(p => p.Pastas)
                .Include(p => p.Background)
                .ThenInclude(b => b.imagem)
                .Include(p => p.Background)
                .ThenInclude(b => b.BackgroundGradiente)
                .ThenInclude(b => b.Cores)
                .Include(p => p.Pedido)
                .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.texto)
                .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.carousel)
                .ThenInclude(b => b.imagens).ThenInclude(b => b.Imagem)
                .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.carousel)
                .ThenInclude(b => b.imagens).ThenInclude(b => b.Carousel)
                .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.form)
                .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.imagem)
                .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.video)
                .Include(p => p.Div).ThenInclude(b => b.Elemento).ThenInclude(b => b.link)
                .ThenInclude(b => b.texto)
                .Include(p => p.Div).ThenInclude(b => b.Elemento)
                .ThenInclude(b => b.link).ThenInclude(b => b.imagem)
                .Include(p => p.Div)
                .ThenInclude(b => b.Elemento)
                .ThenInclude(b => b.table)
                .ThenInclude(b => b.Produtos)
                .ThenInclude(b => b.Imagens)
                .ThenInclude(b => b.Imagem)
                .Include(p => p.Div)
                .ThenInclude(b => b.Elemento)
                .ThenInclude(b => b.table)
                .ThenInclude(b => b.Produtos)
                .ThenInclude(b => b.Imagens)
                .ThenInclude(b => b.Produto)
                .Where(p => p.Titulo != "Lixeira" && p.IdPagina <= 20)
                .ToListAsync();

            foreach (var pag in lista)
            {
                foreach (var div in pag.Div)
                {
                    div.Elemento = div.Elemento.OrderBy(e => e.Ordem).ToList();
                }
            }

            return  lista;
        }

        public string renderizarPagina(Pagina pagina)
        {
            if(pagina == null)
            {
                return "";
            }

            int[] numero = criarRows(pagina);

            pagina = LinksPagina(pagina);

            verificaBackground(pagina);

            Velocity.Init();
            var Modelo = new
            {
                Pedidos = verificaTable(pagina),
                Musicbool = pagina.Music,
                arquivoMusic = pagina.ArquivoMusic,
                Pagina = pagina,
                titulo = pagina.Titulo,
                facebook = pagina.Facebook,
                twiter = pagina.Twiter,
                instagram = pagina.Instagram,
                background = pagina.Background.ToList()[0],
                background_topo = pagina.Background.ToList()[1],
                background_menu = pagina.Background.ToList()[2],
                background_borda_esquerda = pagina.Background.ToList()[3],
                background_borda_direita = pagina.Background.ToList()[4],
                background_bloco = pagina.Background.ToList()[5],
                divs = pagina.Div.OrderBy(d => d.Ordem).ToList(),
                Rows = numero,
                espacamento = 0,
                indice = 1

            };

            var velocitycontext = new VelocityContext();
            velocitycontext.Put("model", Modelo);
            velocitycontext.Put("divs", pagina.Div.OrderBy(d => d.Ordem).ToList());
            var html = new StringBuilder();
            bool result = Velocity.Evaluate(velocitycontext, new StringWriter(html), "NomeParaCapturarLogError",
            new StringReader(CodigoCss + CodigoBloco + CodigoCss2 + CodigoHtml  + CodigoMusic));

            return html.ToString();
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
        }

        public bool verificaTable(Pagina pagina)
        {
            bool verifica = false;
            foreach (var pag in pagina.Pedido.Paginas)
            {
                

                foreach (var div in pag.Div)
                {
                    foreach (var ele in div.Elemento)
                    {
                        if (ele.table_ > 0)
                        {
                            verifica = true;                            
                        }
                    }
                }
            }
            return verifica;
        }

        public int[] criarRows(Pagina pagina)
        {
            int espaco = 0;
            int rows = 0;

            foreach (var bloco in pagina.Div)
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

        public string renderizarPaginaComMenuDropDown(Pagina pagina)

        {
            int[] numero = criarRows(pagina);

            pagina = LinksPagina(pagina);

            verificaBackground(pagina);

            Velocity.Init();
            var Modelo = new
            {
                Pedidos = verificaTable(pagina),
                Musicbool = pagina.Music,
                arquivoMusic = pagina.ArquivoMusic,
                Pagina = pagina,
                titulo = pagina.Titulo,
                facebook = pagina.Facebook,
                twiter = pagina.Twiter,
                instagram = pagina.Instagram,
                background = pagina.Background.ToList()[0],
                background_topo = pagina.Background.ToList()[1],
                background_menu = pagina.Background.ToList()[2],
                background_borda_esquerda = pagina.Background.ToList()[3],
                background_borda_direita = pagina.Background.ToList()[4],
                background_bloco = pagina.Background.ToList()[5],
                divs = pagina.Div.OrderBy(d => d.Ordem).ToList(),
                Rows = numero,
                espacamento = 0,
                indice = 1

            };

            var velocitycontext = new VelocityContext();
            velocitycontext.Put("model", Modelo);
            velocitycontext.Put("divs", pagina.Div.OrderBy(d => d.Ordem).ToList());
            var html = new StringBuilder();
            bool result = Velocity.Evaluate(velocitycontext, new StringWriter(html), "NomeParaCapturarLogError",
            new StringReader(MenuDropDown + CodigoCssMenuDropDwn + CodigoBloco + CodigoCss2 + CodigoHtml + CodigoMusic));

            return html.ToString();
        }

        public string renderizarPaginaComCarousel(Pagina pagina)

        {
            int[] numero = criarRows(pagina);

            pagina = LinksPagina(pagina);

            verificaBackground(pagina);

            Velocity.Init();
            var Modelo = new
            {
                Pedidos = verificaTable(pagina),
                Musicbool = pagina.Music,
                arquivoMusic = pagina.ArquivoMusic,
                Pagina = pagina,
                titulo = pagina.Titulo,
                facebook = pagina.Facebook,
                twiter = pagina.Twiter,
                instagram = pagina.Instagram,
                background = pagina.Background.ToList()[0],
                background_topo = pagina.Background.ToList()[1],
                background_menu = pagina.Background.ToList()[2],
                background_borda_esquerda = pagina.Background.ToList()[3],
                background_borda_direita = pagina.Background.ToList()[4],
                background_bloco = pagina.Background.ToList()[5],
                divs = pagina.Div.OrderBy(d => d.Ordem).ToList(),
                Rows = numero,
                espacamento = 0,
                indice = 1

            };

            var velocitycontext = new VelocityContext();
            velocitycontext.Put("model", Modelo);
            velocitycontext.Put("divs", pagina.Div.OrderBy(d => d.Ordem).ToList());
            var html = new StringBuilder();
            bool result = Velocity.Evaluate(velocitycontext, new StringWriter(html), "NomeParaCapturarLogError",
            new StringReader(CodigoCss + CodigoBloco + CodigoCss2 + CodigoHtml + CodigoMusic + CodigoCarousel));

            return html.ToString();
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
    }
}
