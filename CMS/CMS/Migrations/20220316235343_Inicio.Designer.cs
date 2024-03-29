﻿// <auto-generated />
using System;
using CMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220316235343_Inicio")]
    partial class Inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("business.Back.Background", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("ImagemId");

                    b.HasKey("Id");

                    b.HasIndex("ImagemId");

                    b.ToTable("Background");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Background");
                });

            modelBuilder.Entity("business.Back.Cor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BackgroundId");

                    b.Property<string>("CorBackground");

                    b.Property<int>("Position");

                    b.Property<double>("Transparencia");

                    b.HasKey("Id");

                    b.HasIndex("BackgroundId");

                    b.ToTable("Cor");
                });

            modelBuilder.Entity("business.Join.DivElemento", b =>
                {
                    b.Property<int?>("DivId");

                    b.Property<int?>("ElementoId");

                    b.HasKey("DivId", "ElementoId");

                    b.HasIndex("ElementoId");

                    b.ToTable("DivElemento");
                });

            modelBuilder.Entity("business.Join.DivPagina", b =>
                {
                    b.Property<int?>("DivId");

                    b.Property<int?>("PaginaId");

                    b.HasKey("DivId", "PaginaId");

                    b.HasIndex("PaginaId");

                    b.ToTable("DivPagina");
                });

            modelBuilder.Entity("business.Join.PaginaCarouselPagina", b =>
                {
                    b.Property<int?>("ElementoId");

                    b.Property<int?>("PaginaId");

                    b.HasKey("ElementoId", "PaginaId");

                    b.HasIndex("PaginaId");

                    b.ToTable("PaginaCarouselPagina");
                });

            modelBuilder.Entity("business.business.DadoFormulario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Campo");

                    b.Property<int>("Formulario");

                    b.Property<string>("Valor");

                    b.HasKey("Id");

                    b.ToTable("DadoFormulario");
                });

            modelBuilder.Entity("business.business.Elementos.element.Elemento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("FormularioId");

                    b.Property<int?>("ImagemId");

                    b.Property<string>("Nome");

                    b.Property<int>("Ordem");

                    b.Property<int?>("PaginaEscolhida");

                    b.Property<int>("Pagina_");

                    b.Property<int?>("TableId");

                    b.Property<int?>("TextoId");

                    b.HasKey("Id");

                    b.HasIndex("FormularioId");

                    b.HasIndex("ImagemId");

                    b.HasIndex("TableId");

                    b.HasIndex("TextoId");

                    b.ToTable("Elemento");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Elemento");
                });

            modelBuilder.Entity("business.business.Elementos.element.ElementoDependenteElemento", b =>
                {
                    b.Property<int?>("ElementoDependenteId");

                    b.Property<int?>("ElementoId");

                    b.HasKey("ElementoDependenteId", "ElementoId");

                    b.HasIndex("ElementoId");

                    b.ToTable("ElementoDependenteElemento");
                });

            modelBuilder.Entity("business.business.MensagemChat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mensagem");

                    b.Property<string>("NomeUsuario");

                    b.Property<int>("Pagina");

                    b.HasKey("Id");

                    b.ToTable("MensagemChat");
                });

            modelBuilder.Entity("business.business.Pagina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArquivoMusic");

                    b.Property<bool>("Exibicao");

                    b.Property<bool>("Margem");

                    b.Property<bool>("Menu");

                    b.Property<bool>("Music");

                    b.Property<int>("PedidoId");

                    b.Property<string>("Rotas");

                    b.Property<int>("StoryId");

                    b.Property<string>("Titulo")
                        .IsRequired();

                    b.Property<bool>("Topo");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("StoryId");

                    b.ToTable("Pagina");
                });

            modelBuilder.Entity("business.business.PastaImagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.Property<int>("PedidoId");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("PastaImagem");
                });

            modelBuilder.Entity("business.business.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClienteId")
                        .IsRequired();

                    b.Property<DateTime>("Datapedido");

                    b.Property<int>("DiasLiberados");

                    b.Property<string>("DominioTemporario")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Facebook");

                    b.Property<string>("Instagram");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Status");

                    b.Property<string>("Twiter");

                    b.Property<bool>("Venda");

                    b.HasKey("Id");

                    b.HasIndex("DominioTemporario")
                        .IsUnique();

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("business.business.Permissao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomePermissao");

                    b.Property<int>("Site");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Permissao");
                });

            modelBuilder.Entity("business.business.Rota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeRota");

                    b.HasKey("Id");

                    b.ToTable("Rota");
                });

            modelBuilder.Entity("business.business.Servico", b =>
                {
                    b.Property<int>("IdServico");

                    b.Property<string>("Descricao");

                    b.HasKey("IdServico");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("business.business.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Story");
                });

            modelBuilder.Entity("business.business.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular")
                        .IsRequired();

                    b.Property<string>("ClienteId")
                        .IsRequired();

                    b.Property<string>("DDD_Celular")
                        .IsRequired();

                    b.Property<string>("DDD_Telefone");

                    b.Property<string>("Fone");

                    b.HasKey("Id");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("business.div.Div", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BorderRadius");

                    b.Property<string>("Colunas");

                    b.Property<int>("Desenhado");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Divisao");

                    b.Property<int>("Height");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Ordem");

                    b.Property<int>("Padding");

                    b.Property<int>("Pagina_");

                    b.HasKey("Id");

                    b.ToTable("Div");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Div");
                });

            modelBuilder.Entity("business.ecommerce.Cadastro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired();

                    b.Property<string>("CEP")
                        .IsRequired();

                    b.Property<string>("Complemento")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Endereco")
                        .IsRequired();

                    b.Property<string>("Municipio")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.Property<string>("UF")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Cadastro");
                });

            modelBuilder.Entity("business.ecommerce.ContaBancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agencia");

                    b.Property<string>("ClienteId")
                        .IsRequired();

                    b.Property<string>("CodigoBanco")
                        .IsRequired();

                    b.Property<string>("Conta");

                    b.Property<string>("DVAgencia");

                    b.Property<string>("DVConta");

                    b.Property<string>("TipoConta")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ContaBancaria");
                });

            modelBuilder.Entity("business.ecommerce.InfoEntrega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlturaCaixa");

                    b.Property<string>("ClienteId")
                        .IsRequired();

                    b.Property<int?>("ComprimentoCaixa");

                    b.Property<int?>("LarguraCaixa");

                    b.Property<int?>("PesoCaixa");

                    b.HasKey("Id");

                    b.ToTable("InfoEntrega");
                });

            modelBuilder.Entity("business.ecommerce.InfoVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .IsRequired();

                    b.Property<string>("Cep")
                        .IsRequired();

                    b.Property<string>("Cidade")
                        .IsRequired();

                    b.Property<string>("ClienteId")
                        .IsRequired();

                    b.Property<string>("Cpf")
                        .IsRequired();

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<long>("Numero");

                    b.Property<string>("Rua")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("InfoVenda");
                });

            modelBuilder.Entity("business.ecommerce.ItemRequisicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ElementoId");

                    b.Property<decimal>("PrecoUnitario");

                    b.Property<int?>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.Property<int>("RequisicaoId");

                    b.HasKey("Id");

                    b.HasIndex("ElementoId");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("RequisicaoId");

                    b.ToTable("ItemRequisicao");
                });

            modelBuilder.Entity("business.ecommerce.Requisicao", b =>
                {
                    b.Property<int>("IdRequisicao");

                    b.Property<string>("ClienteId")
                        .IsRequired();

                    b.Property<DateTime>("DataPedidoCompra");

                    b.Property<string>("Status");

                    b.Property<string>("ValorPedido");

                    b.HasKey("IdRequisicao");

                    b.ToTable("Requisicao");
                });

            modelBuilder.Entity("business.Back.BackgroundCor", b =>
                {
                    b.HasBaseType("business.Back.Background");

                    b.Property<string>("Cor");

                    b.Property<bool>("backgroundTransparente");

                    b.ToTable("BackgroundCor");

                    b.HasDiscriminator().HasValue("BackgroundCor");
                });

            modelBuilder.Entity("business.Back.BackgroundGradiente", b =>
                {
                    b.HasBaseType("business.Back.Background");

                    b.Property<int>("Grau");

                    b.ToTable("BackgroundGradiente");

                    b.HasDiscriminator().HasValue("BackgroundGradiente");
                });

            modelBuilder.Entity("business.Back.BackgroundImagem", b =>
                {
                    b.HasBaseType("business.Back.Background");

                    b.Property<string>("Background_Position");

                    b.Property<string>("Background_Repeat");

                    b.ToTable("BackgroundImagem");

                    b.HasDiscriminator().HasValue("BackgroundImagem");
                });

            modelBuilder.Entity("business.business.Elementos.Campo", b =>
                {
                    b.HasBaseType("business.business.Elementos.element.Elemento");

                    b.Property<string>("Placeholder");

                    b.Property<string>("TipoCampo");

                    b.ToTable("Campo");

                    b.HasDiscriminator().HasValue("Campo");
                });

            modelBuilder.Entity("business.business.Elementos.Dropdown", b =>
                {
                    b.HasBaseType("business.business.Elementos.element.Elemento");

                    b.ToTable("Dropdown");

                    b.HasDiscriminator().HasValue("Dropdown");
                });

            modelBuilder.Entity("business.business.Elementos.Formulario", b =>
                {
                    b.HasBaseType("business.business.Elementos.element.Elemento");

                    b.ToTable("Formulario");

                    b.HasDiscriminator().HasValue("Formulario");
                });

            modelBuilder.Entity("business.business.Elementos.Table", b =>
                {
                    b.HasBaseType("business.business.Elementos.element.Elemento");

                    b.Property<string>("EstiloTabela");

                    b.ToTable("Table");

                    b.HasDiscriminator().HasValue("Table");
                });

            modelBuilder.Entity("business.business.Elementos.Video", b =>
                {
                    b.HasBaseType("business.business.Elementos.element.Elemento");

                    b.Property<string>("ArquivoVideo");

                    b.ToTable("Video");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("business.business.Elementos.produto.Produto", b =>
                {
                    b.HasBaseType("business.business.Elementos.element.Elemento");

                    b.Property<string>("Codigo")
                        .IsRequired();

                    b.Property<string>("Descricao");

                    b.Property<decimal>("Preco");

                    b.Property<string>("Segmento");

                    b.Property<long?>("estoque");

                    b.ToTable("Produto");

                    b.HasDiscriminator().HasValue("Produto");
                });

            modelBuilder.Entity("business.business.Elementos.texto.Texto", b =>
                {
                    b.HasBaseType("business.business.Elementos.element.Elemento");

                    b.Property<string>("PalavrasTexto");

                    b.ToTable("Texto");

                    b.HasDiscriminator().HasValue("Texto");
                });

            modelBuilder.Entity("business.business.carousel.CarouselImg", b =>
                {
                    b.HasBaseType("business.business.Elementos.element.Elemento");

                    b.ToTable("CarouselImg");

                    b.HasDiscriminator().HasValue("CarouselImg");
                });

            modelBuilder.Entity("business.business.carousel.CarouselPagina", b =>
                {
                    b.HasBaseType("business.business.Elementos.element.Elemento");

                    b.ToTable("CarouselPagina");

                    b.HasDiscriminator().HasValue("CarouselPagina");
                });

            modelBuilder.Entity("business.business.element.ElementoDependente", b =>
                {
                    b.HasBaseType("business.business.Elementos.element.Elemento");

                    b.ToTable("ElementoDependente");

                    b.HasDiscriminator().HasValue("ElementoDependente");
                });

            modelBuilder.Entity("business.business.link.LinkBody", b =>
                {
                    b.HasBaseType("business.business.Elementos.element.Elemento");

                    b.Property<string>("TextoLink");

                    b.ToTable("LinkBody");

                    b.HasDiscriminator().HasValue("LinkBody");
                });

            modelBuilder.Entity("business.div.DivComum", b =>
                {
                    b.HasBaseType("business.div.Div");

                    b.ToTable("DivComum");

                    b.HasDiscriminator().HasValue("DivComum");
                });

            modelBuilder.Entity("business.div.DivFixo", b =>
                {
                    b.HasBaseType("business.div.Div");

                    b.Property<int>("EixoXBlocoFixado");

                    b.Property<int>("EixoYBlocoFixado");

                    b.Property<bool>("EscolherPosicao");

                    b.Property<int>("InicioFixacao");

                    b.Property<int>("PosicaoFixacao");

                    b.ToTable("DivFixo");

                    b.HasDiscriminator().HasValue("DivFixo");
                });

            modelBuilder.Entity("business.business.Elementos.produto.Acessorio", b =>
                {
                    b.HasBaseType("business.business.Elementos.produto.Produto");

                    b.ToTable("Acessorio");

                    b.HasDiscriminator().HasValue("Acessorio");
                });

            modelBuilder.Entity("business.business.Elementos.produto.Alimenticio", b =>
                {
                    b.HasBaseType("business.business.Elementos.produto.Produto");

                    b.ToTable("Alimenticio");

                    b.HasDiscriminator().HasValue("Alimenticio");
                });

            modelBuilder.Entity("business.business.Elementos.produto.Calcado", b =>
                {
                    b.HasBaseType("business.business.Elementos.produto.Produto");

                    b.ToTable("Calcado");

                    b.HasDiscriminator().HasValue("Calcado");
                });

            modelBuilder.Entity("business.business.Elementos.produto.Roupa", b =>
                {
                    b.HasBaseType("business.business.Elementos.produto.Produto");

                    b.ToTable("Roupa");

                    b.HasDiscriminator().HasValue("Roupa");
                });

            modelBuilder.Entity("business.business.Elementos.produto.Show", b =>
                {
                    b.HasBaseType("business.business.Elementos.produto.Produto");

                    b.ToTable("Show");

                    b.HasDiscriminator().HasValue("Show");
                });

            modelBuilder.Entity("business.business.Elementos.imagem.Imagem", b =>
                {
                    b.HasBaseType("business.business.element.ElementoDependente");

                    b.Property<string>("ArquivoImagem");

                    b.Property<int?>("PastaImagemId");

                    b.Property<int>("Width");

                    b.HasIndex("PastaImagemId");

                    b.ToTable("Imagem");

                    b.HasDiscriminator().HasValue("Imagem");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.Back.Background", b =>
                {
                    b.HasOne("business.div.Div", "Div")
                        .WithOne("Background")
                        .HasForeignKey("business.Back.Background", "Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("business.business.Elementos.imagem.Imagem", "Imagem")
                        .WithMany("Background")
                        .HasForeignKey("ImagemId");
                });

            modelBuilder.Entity("business.Back.Cor", b =>
                {
                    b.HasOne("business.Back.Background", "Background")
                        .WithMany("Cores")
                        .HasForeignKey("BackgroundId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.Join.DivElemento", b =>
                {
                    b.HasOne("business.div.Div", "Div")
                        .WithMany("Elemento")
                        .HasForeignKey("DivId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("business.business.Elementos.element.Elemento", "Elemento")
                        .WithMany("div")
                        .HasForeignKey("ElementoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.Join.DivPagina", b =>
                {
                    b.HasOne("business.div.Div", "Div")
                        .WithMany("Pagina")
                        .HasForeignKey("DivId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("business.business.Pagina", "Pagina")
                        .WithMany("Div")
                        .HasForeignKey("PaginaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.Join.PaginaCarouselPagina", b =>
                {
                    b.HasOne("business.business.Elementos.element.Elemento", "Elemento")
                        .WithMany("Paginas")
                        .HasForeignKey("ElementoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("business.business.Pagina", "Pagina")
                        .WithMany("CarouselPagina")
                        .HasForeignKey("PaginaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.business.Elementos.element.Elemento", b =>
                {
                    b.HasOne("business.business.Elementos.Formulario", "Formulario")
                        .WithMany("Elemento")
                        .HasForeignKey("FormularioId");

                    b.HasOne("business.business.Elementos.imagem.Imagem", "Imagem")
                        .WithMany("Elemento")
                        .HasForeignKey("ImagemId");

                    b.HasOne("business.business.Elementos.Table", "Table")
                        .WithMany("Elemento")
                        .HasForeignKey("TableId");

                    b.HasOne("business.business.Elementos.texto.Texto", "Texto")
                        .WithMany("Elemento")
                        .HasForeignKey("TextoId");
                });

            modelBuilder.Entity("business.business.Elementos.element.ElementoDependenteElemento", b =>
                {
                    b.HasOne("business.business.element.ElementoDependente", "ElementoDependente")
                        .WithMany()
                        .HasForeignKey("ElementoDependenteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("business.business.Elementos.element.Elemento", "Elemento")
                        .WithMany("Dependentes")
                        .HasForeignKey("ElementoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.business.Pagina", b =>
                {
                    b.HasOne("business.business.Pedido", "Pedido")
                        .WithMany("Paginas")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("business.business.Story", "Story")
                        .WithMany("Pagina")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.business.PastaImagem", b =>
                {
                    b.HasOne("business.business.Pedido", "Pedido")
                        .WithMany("Pastas")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.business.Servico", b =>
                {
                    b.HasOne("business.business.Pedido", "Pedido")
                        .WithOne("Servico")
                        .HasForeignKey("business.business.Servico", "IdServico")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.ecommerce.ItemRequisicao", b =>
                {
                    b.HasOne("business.business.Elementos.element.Elemento", "Elemento")
                        .WithMany()
                        .HasForeignKey("ElementoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("business.business.Elementos.produto.Produto")
                        .WithMany("Itens")
                        .HasForeignKey("ProdutoId");

                    b.HasOne("business.ecommerce.Requisicao", "Requisicao")
                        .WithMany("ItemRequisicao")
                        .HasForeignKey("RequisicaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.ecommerce.Requisicao", b =>
                {
                    b.HasOne("business.ecommerce.Cadastro", "Cadastro")
                        .WithOne("Requisicao")
                        .HasForeignKey("business.ecommerce.Requisicao", "IdRequisicao")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("business.business.Elementos.imagem.Imagem", b =>
                {
                    b.HasOne("business.business.PastaImagem", "PastaImagem")
                        .WithMany("Imagens")
                        .HasForeignKey("PastaImagemId");
                });
#pragma warning restore 612, 618
        }
    }
}
