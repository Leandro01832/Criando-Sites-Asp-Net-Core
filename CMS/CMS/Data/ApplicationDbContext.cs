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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<BackgroundGradiente> BackgroundGradiente { get; set; }
        public DbSet<Cadastro> Cadastro { get; set; }
        public DbSet<DadoFormulario> DadoFormulario { get; set; }
        public DbSet<Dropdown> Dropdown { get; set; }
        public DbSet<PaginaCarouselPagina> PaginaCarouselPagina { get; set; }
        public DbSet<CarouselPagina> CarouselPagina { get; set; }
        public DbSet<DivElemento> DivElemento { get; set; }
        public DbSet<DivPagina> DivPagina { get; set; }
        public DbSet<ElementoDependenteElemento> ElementoDependenteElemento { get; set; }
        public DbSet<Cor> Cor { get; set; }
        public DbSet<Rota> Rota { get; set; }
        public DbSet<ContaBancaria> ContaBancaria { get; set; }
        public DbSet<InfoEntrega> InfoEntrega { get; set; }
        public DbSet<InfoVenda> InfoVenda { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<Carousel> Carousel { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<ImagemDependente> ImagemDependente { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Pagina> Pagina { get; set; }
        public DbSet<Div> Div { get; set; }
        public DbSet<Texto> Texto { get; set; }
        public DbSet<TextoDependente> TextoDependente { get; set; }
        public DbSet<Background> Background { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Elemento> Elemento { get; set; }
        public DbSet<ElementoComum> ElementoComum { get; set; }
        public DbSet<ElementoDependente> ElementoDependente { get; set; }
        public DbSet<Campo> Campo { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<Formulario> Form { get; set; }
        public DbSet<ItemRequisicao> ItemRequisicao { get; set; }
        public DbSet<Requisicao> Requisicao { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<MensagemChat> MensagemChat { get; set; }
        public DbSet<PastaImagem> PastaImagem { get; set; }


        public object Configuration { get; internal set; }

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

            builder.Entity<Pedido>()
            .HasIndex(u => u.DominioTemporario)
            .IsUnique();

        }

        public DbSet<business.business.Elementos.produto.Acessorio> Acessorio { get; set; }

        public DbSet<business.business.Elementos.produto.Alimenticio> Alimenticio { get; set; }

        public DbSet<business.business.Elementos.produto.Calcado> Calcado { get; set; }

        public DbSet<business.business.Elementos.produto.Roupa> Roupa { get; set; }

        public DbSet<business.business.link.LinkBody> LinkBody { get; set; }

        public DbSet<business.business.link.LinkMenu> LinkMenu { get; set; }

        public DbSet<business.business.carousel.CarouselImg> CarouselImg { get; set; }

        public DbSet<business.business.Elementos.produto.Show> Show { get; set; }

        public DbSet<business.div.DivComum> DivComum { get; set; }

        public DbSet<business.div.DivFixo> DivFixo { get; set; }

        public DbSet<business.Back.BackgroundImagem> BackgroundImagem { get; set; }

        public DbSet<business.Back.BackgroundCor> BackgroundCor { get; set; }
    }
}
