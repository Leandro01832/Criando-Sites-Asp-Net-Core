using business.Back;
using business.business;
using business.business.carousel;
using business.business.element;
using business.business.Elementos;
using business.business.Elementos.element;
using business.business.Elementos.imagem;
using business.business.Elementos.link;
using business.business.Elementos.produto;
using business.business.Elementos.texto;
using business.business.link;
using business.div;
using business.ecommerce;
using business.Join;
using Microsoft.EntityFrameworkCore;

namespace business
{
    public class CmsContext : DbContext
    {

        public DbSet<BackgroundGradiente> BackgroundGradientes { get; set; }
        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<DadoFormulario> DadoFormularios { get; set; }
        public DbSet<Dropdown> Dropdowns { get; set; }
        public DbSet<PaginaCarouselPagina> PaginaCarouselPaginas { get; set; }
        public DbSet<CarouselPagina> CarouselPaginas { get; set; }
        public DbSet<DivElemento> DivElementos { get; set; }
        public DbSet<DivPagina> DivPaginas { get; set; }
        public DbSet<ElementoDependenteElemento> ElementoDependenteElementos { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<Rota> Rotas { get; set; }
        public DbSet<ContaBancaria> ContaBancarias { get; set; }
        public DbSet<InfoEntrega> InfoEntregas { get; set; }
        public DbSet<InfoVenda> InfoVendas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Carousel> Carousseis { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<ImagemDependente> ImagemDependentes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Pagina> Paginas { get; set; }
        public DbSet<Div> Divs { get; set; }
        public DbSet<Texto> Texto { get; set; }
        public DbSet<TextoDependente> TextoDependentes { get; set; }
        public DbSet<Background> Backgrounds { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Elemento> Elementos{ get; set; }
        public DbSet<ElementoComum> ElementoComuns { get; set; }
        public DbSet<ElementoDependente> ElementoDependentes { get; set; }
        public DbSet<Campo> Campos { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Formulario> Forms { get; set; }
        public DbSet<ItemRequisicao> ItemRequisicaos { get; set; }
        public DbSet<Requisicao> Requisicoes { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<MensagemChat> MensagemChats { get; set; }
        public DbSet<PastaImagem> PastaImagens { get; set; }

        public DbSet<Acessorio> Acessorios { get; set; }

        public DbSet<Alimenticio> Alimenticios { get; set; }

        public DbSet<Calcado> Calcados { get; set; }

        public DbSet<Roupa> Roupas { get; set; }

        public DbSet<LinkBody> LinkBodys { get; set; }

        public DbSet<LinkMenu> LinkMenus { get; set; }

        public DbSet<CarouselImg> CarouselImgs { get; set; }

        public DbSet<Show> Shows { get; set; }

        public DbSet<DivComum> DivComuns { get; set; }

        public DbSet<DivFixo> DivFixos { get; set; }

        public DbSet<BackgroundImagem> BackgroundImagens { get; set; }

        public DbSet<BackgroundCor> BackgroundCores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-CMS-06C6F929-E569-4BE7-8ECA-BCB310B74739;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ElementoDependenteElemento>()
            .HasKey(p => new { p.ElementoDependenteId, p.ElementoId });

            base.OnModelCreating(builder);
            builder.Entity<PaginaCarouselPagina>()
            .HasKey(p => new { p.CarouselPaginaId, p.PaginaId });

            base.OnModelCreating(builder);
            builder.Entity<DivPagina>()
            .HasKey(p => new { p.DivId, p.PaginaId });

            base.OnModelCreating(builder);
            builder.Entity<DivElemento>()
            .HasKey(p => new { p.DivId, p.ElementoId });

            builder.Entity<Carousel>().ToTable("Carousel");
            builder.Entity<Elemento>().ToTable("Elemento");
            builder.Entity<ElementoComum>().ToTable("ElementoComum");
            builder.Entity<ElementoDependente>().ToTable("ElementoDependente");
            builder.Entity<Div>().ToTable("Div");
            builder.Entity<Link>().ToTable("Link");
            builder.Entity<LinkDependente>().ToTable("LinkDependente");

            builder.Entity<ProdutoComum>().ToTable("ProdutoComum");
            builder.Entity<ProdutoDependente>().ToTable("ProdutoDependente");

            builder.Entity<Background>().ToTable("Background");
            builder.Entity<BackgroundCor>().ToTable("BackgroundCor");
            builder.Entity<BackgroundImagem>().ToTable("BackgroundImagem");
            builder.Entity<BackgroundGradiente>().ToTable("BackgroundGradiente");

            builder.Entity<CarouselPagina>().ToTable("CarouselPagina");
            builder.Entity<CarouselImg>().ToTable("CarouselImg");

            builder.Entity<Calcado>().ToTable("Calcado");
            builder.Entity<Roupa>().ToTable("Roupa");
            builder.Entity<Acessorio>().ToTable("Acessorio");
            builder.Entity<Alimenticio>().ToTable("Alimenticio");
            builder.Entity<Show>().ToTable("Show");

            builder.Entity<LinkBody>().ToTable("LinkBody");
            builder.Entity<LinkMenu>().ToTable("LinkMenu");

            builder.Entity<DivFixo>().ToTable("DivFixo");
            builder.Entity<DivComum>().ToTable("DivComum");


            builder.Entity<Imagem>().ToTable("Imagem");
            builder.Entity<ImagemDependente>().ToTable("ImagemDependente");


            builder.Entity<Texto>().ToTable("Texto");
            builder.Entity<Formulario>().ToTable("Formulario");
            builder.Entity<Table>().ToTable("Table");
            builder.Entity<Campo>().ToTable("Campo");
            builder.Entity<Video>().ToTable("Video");
            builder.Entity<Dropdown>().ToTable("Dropdown");
        }

    }
}
