using System;
using System.Collections.Generic;
using System.Text;
using MeuProjetoAgora.Models.business.Elemento;
using MeuProjetoAgora.Models.business;
using MeuProjetoAgora.Models.Join;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeuProjetoAgora.Data
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
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Pagina> Pagina { get; set; }
        public DbSet<Div> Div { get; set; }
        public DbSet<Texto> Texto { get; set; }
        public DbSet<Background> Background { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Elemento> Elemento { get; set; }
        public DbSet<ElementoDependente> ElementoDependente { get; set; }
        public DbSet<Campo> Campo { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<Formulario> Form { get; set; }
        public DbSet<ItemRequisicao> ItemRequisicao { get; set; }
        public DbSet<Requisicao> Requisicao { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Produto> Produto { get; set; }
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
            builder.Entity<Video>().ToTable("Video");
            builder.Entity<Imagem>().ToTable("Imagem");
            builder.Entity<Produto>().ToTable("Produto");
            builder.Entity<Link>().ToTable("Link");
            builder.Entity<Texto>().ToTable("Texto");
            builder.Entity<Formulario>().ToTable("Formulario");
            builder.Entity<Table>().ToTable("Table");
            builder.Entity<Campo>().ToTable("Campo");
            builder.Entity<Elemento>().ToTable("Elemento");

            builder.Entity<Pedido>()
            .HasIndex(u => u.DominioTemporario)
            .IsUnique();

        }
    }
}
