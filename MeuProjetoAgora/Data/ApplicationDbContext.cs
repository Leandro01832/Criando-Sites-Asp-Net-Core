using System;
using System.Collections.Generic;
using System.Text;
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
        public DbSet<Cor> Cor { get; set; }
        public DbSet<Rota> Rota { get; set; }
        public DbSet<ContaBancaria> ContaBancaria { get; set; }
        public DbSet<InfoEntrega> InfoEntrega { get; set; }
        public DbSet<InfoVenda> InfoVenda { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<EnderecoRequisicao> EnderecoRequisicao { get; set; }
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
        // public DbSet<Dados> Dados { get; set; }
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
            builder.Entity<DivImagem>()
            .HasKey(p => new { p.ImagemId, p.DivId });

            builder.Entity<CarouselImagem>()
            .HasKey(p => new { p.ImagemId, p.CarouselId });

            builder.Entity<ProdutoImagem>()
            .HasKey(p => new { p.ImagemId, p.ProdutoId });

            builder.Entity<Pedido>()
            .HasIndex(u => u.DominioTemporario)
            .IsUnique();

            base.OnModelCreating(builder);
        }
    }
}
