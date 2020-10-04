using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuProjetoAgora.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContaBancaria",
                columns: table => new
                {
                    IdContaBancaria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoBanco = table.Column<string>(nullable: true),
                    TipoConta = table.Column<string>(nullable: true),
                    Agencia = table.Column<string>(nullable: true),
                    DVAgencia = table.Column<string>(nullable: true),
                    Conta = table.Column<string>(nullable: true),
                    DVConta = table.Column<string>(nullable: true),
                    ClienteId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaBancaria", x => x.IdContaBancaria);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estado = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Rua = table.Column<string>(nullable: true),
                    Numero = table.Column<long>(nullable: false),
                    Cep = table.Column<string>(nullable: true),
                    ClienteId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "InfoEntrega",
                columns: table => new
                {
                    IdInfoEntrega = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    entregaCorreio = table.Column<bool>(nullable: false),
                    LarguraCaixa = table.Column<int>(nullable: true),
                    AlturaCaixa = table.Column<int>(nullable: true),
                    PesoCaixa = table.Column<int>(nullable: true),
                    ComprimentoCaixa = table.Column<int>(nullable: true),
                    CidadesEntrega = table.Column<string>(nullable: true),
                    EstadosEntrega = table.Column<string>(nullable: true),
                    ValorFrete = table.Column<decimal>(nullable: true),
                    ClienteId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoEntrega", x => x.IdInfoEntrega);
                });

            migrationBuilder.CreateTable(
                name: "InfoVenda",
                columns: table => new
                {
                    IdInfoVenda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cpf = table.Column<string>(nullable: true),
                    ClienteId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoVenda", x => x.IdInfoVenda);
                });

            migrationBuilder.CreateTable(
                name: "MensagemChat",
                columns: table => new
                {
                    IdMensagem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pagina = table.Column<int>(nullable: false),
                    NomeUsuario = table.Column<string>(nullable: true),
                    Mensagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagemChat", x => x.IdMensagem);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    IdPedido = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Venda = table.Column<bool>(nullable: false),
                    DominioTemporario = table.Column<string>(maxLength: 30, nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Datapedido = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.IdPedido);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    IdPermissao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomePermissao = table.Column<string>(nullable: true),
                    Site = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.IdPermissao);
                });

            migrationBuilder.CreateTable(
                name: "Requisicao",
                columns: table => new
                {
                    IdRequisicao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: true),
                    DataPedidoCompra = table.Column<DateTime>(nullable: false),
                    ValorPedido = table.Column<string>(nullable: true),
                    ClienteId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisicao", x => x.IdRequisicao);
                });

            migrationBuilder.CreateTable(
                name: "Rota",
                columns: table => new
                {
                    IdRota = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeRota = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rota", x => x.IdRota);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    IdTelefone = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DDD_Celular = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    DDD_Telefone = table.Column<string>(nullable: true),
                    Fone = table.Column<string>(nullable: true),
                    ClienteId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.IdTelefone);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagina",
                columns: table => new
                {
                    IdPagina = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: false),
                    Facebook = table.Column<string>(nullable: true),
                    Twiter = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    ArquivoMusic = table.Column<string>(nullable: true),
                    Rotas = table.Column<string>(nullable: true),
                    Music = table.Column<bool>(nullable: false),
                    Margem = table.Column<bool>(nullable: false),
                    pedido_ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagina", x => x.IdPagina);
                    table.ForeignKey(
                        name: "FK_Pagina_Pedido_pedido_",
                        column: x => x.pedido_,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servico",
                columns: table => new
                {
                    IdServico = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servico", x => x.IdServico);
                    table.ForeignKey(
                        name: "FK_Servico_Pedido_IdServico",
                        column: x => x.IdServico,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnderecoRequisicao",
                columns: table => new
                {
                    IdEnderecoRequisicao = table.Column<int>(nullable: false),
                    Cep = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Rua = table.Column<string>(nullable: true),
                    NumeroCasa = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoRequisicao", x => x.IdEnderecoRequisicao);
                    table.ForeignKey(
                        name: "FK_EnderecoRequisicao_Requisicao_IdEnderecoRequisicao",
                        column: x => x.IdEnderecoRequisicao,
                        principalTable: "Requisicao",
                        principalColumn: "IdRequisicao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PastaImagem",
                columns: table => new
                {
                    IdPastaImagem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    PaginaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaImagem", x => x.IdPastaImagem);
                    table.ForeignKey(
                        name: "FK_PastaImagem_Pagina_PaginaId",
                        column: x => x.PaginaId,
                        principalTable: "Pagina",
                        principalColumn: "IdPagina",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    IdImagem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Arquivo = table.Column<string>(nullable: true),
                    PastaImagemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.IdImagem);
                    table.ForeignKey(
                        name: "FK_Imagem_PastaImagem_PastaImagemId",
                        column: x => x.PastaImagemId,
                        principalTable: "PastaImagem",
                        principalColumn: "IdPastaImagem",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Background",
                columns: table => new
                {
                    IdBackground = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    backgroundImage = table.Column<bool>(nullable: false),
                    backgroundTransparente = table.Column<bool>(nullable: false),
                    Gradiente = table.Column<bool>(nullable: false),
                    Cor = table.Column<string>(nullable: true),
                    Background_Repeat = table.Column<string>(nullable: true),
                    Background_Position = table.Column<string>(nullable: true),
                    PaginaId = table.Column<int>(nullable: false),
                    imagem_ = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Background", x => x.IdBackground);
                    table.ForeignKey(
                        name: "FK_Background_Pagina_PaginaId",
                        column: x => x.PaginaId,
                        principalTable: "Pagina",
                        principalColumn: "IdPagina",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Background_Imagem_imagem_",
                        column: x => x.imagem_,
                        principalTable: "Imagem",
                        principalColumn: "IdImagem",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BackgroundGradiente",
                columns: table => new
                {
                    IdBackgroundGradiente = table.Column<int>(nullable: false),
                    Grau = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundGradiente", x => x.IdBackgroundGradiente);
                    table.ForeignKey(
                        name: "FK_BackgroundGradiente_Background_IdBackgroundGradiente",
                        column: x => x.IdBackgroundGradiente,
                        principalTable: "Background",
                        principalColumn: "IdBackground",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Div",
                columns: table => new
                {
                    IdDiv = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Padding = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Colunas = table.Column<string>(nullable: true),
                    Desenhado = table.Column<int>(nullable: false),
                    Divisao = table.Column<string>(nullable: true),
                    BorderRadius = table.Column<int>(nullable: false),
                    Ordem = table.Column<int>(nullable: false),
                    background_ = table.Column<int>(nullable: false),
                    PaginaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Div", x => x.IdDiv);
                    table.ForeignKey(
                        name: "FK_Div_Pagina_PaginaId",
                        column: x => x.PaginaId,
                        principalTable: "Pagina",
                        principalColumn: "IdPagina",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Div_Background_background_",
                        column: x => x.background_,
                        principalTable: "Background",
                        principalColumn: "IdBackground",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cor",
                columns: table => new
                {
                    IdCor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CorBackground = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Transparencia = table.Column<double>(nullable: false),
                    BackgroundGradienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cor", x => x.IdCor);
                    table.ForeignKey(
                        name: "FK_Cor_BackgroundGradiente_BackgroundGradienteId",
                        column: x => x.BackgroundGradienteId,
                        principalTable: "BackgroundGradiente",
                        principalColumn: "IdBackgroundGradiente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carousel",
                columns: table => new
                {
                    IdCarousel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    div_2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carousel", x => x.IdCarousel);
                    table.ForeignKey(
                        name: "FK_Carousel_Div_div_2",
                        column: x => x.div_2,
                        principalTable: "Div",
                        principalColumn: "IdDiv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DivImagem",
                columns: table => new
                {
                    ImagemId = table.Column<int>(nullable: false),
                    DivId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivImagem", x => new { x.ImagemId, x.DivId });
                    table.ForeignKey(
                        name: "FK_DivImagem_Div_DivId",
                        column: x => x.DivId,
                        principalTable: "Div",
                        principalColumn: "IdDiv",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivImagem_Imagem_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagem",
                        principalColumn: "IdImagem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    IdTable = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Estilo = table.Column<string>(nullable: true),
                    div_ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.IdTable);
                    table.ForeignKey(
                        name: "FK_Table_Div_div_",
                        column: x => x.div_,
                        principalTable: "Div",
                        principalColumn: "IdDiv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Texto",
                columns: table => new
                {
                    IdTexto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Palavras = table.Column<string>(nullable: true),
                    div_ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texto", x => x.IdTexto);
                    table.ForeignKey(
                        name: "FK_Texto_Div_div_",
                        column: x => x.div_,
                        principalTable: "Div",
                        principalColumn: "IdDiv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    IdVideo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArquivoVideo = table.Column<string>(nullable: true),
                    div_ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.IdVideo);
                    table.ForeignKey(
                        name: "FK_Video_Div_div_",
                        column: x => x.div_,
                        principalTable: "Div",
                        principalColumn: "IdDiv",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarouselImagem",
                columns: table => new
                {
                    CarouselId = table.Column<int>(nullable: false),
                    ImagemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselImagem", x => new { x.ImagemId, x.CarouselId });
                    table.ForeignKey(
                        name: "FK_CarouselImagem_Carousel_CarouselId",
                        column: x => x.CarouselId,
                        principalTable: "Carousel",
                        principalColumn: "IdCarousel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarouselImagem_Imagem_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagem",
                        principalColumn: "IdImagem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    IdProduto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    estoque = table.Column<long>(nullable: true),
                    table_ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produto_Table_table_",
                        column: x => x.table_,
                        principalTable: "Table",
                        principalColumn: "IdTable",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    IdLink = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    texto_ = table.Column<int>(nullable: true),
                    imagem_ = table.Column<int>(nullable: true),
                    div_ = table.Column<int>(nullable: true),
                    pagina_ = table.Column<int>(nullable: true),
                    Url = table.Column<bool>(nullable: false),
                    TextoLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.IdLink);
                    table.ForeignKey(
                        name: "FK_Link_Div_div_",
                        column: x => x.div_,
                        principalTable: "Div",
                        principalColumn: "IdDiv",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_Imagem_imagem_",
                        column: x => x.imagem_,
                        principalTable: "Imagem",
                        principalColumn: "IdImagem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_Pagina_pagina_",
                        column: x => x.pagina_,
                        principalTable: "Pagina",
                        principalColumn: "IdPagina",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Link_Texto_texto_",
                        column: x => x.texto_,
                        principalTable: "Texto",
                        principalColumn: "IdTexto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemRequisicao",
                columns: table => new
                {
                    IdItem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantidade = table.Column<int>(nullable: false),
                    requisicao_ = table.Column<int>(nullable: false),
                    produto_ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRequisicao", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_ItemRequisicao_Produto_produto_",
                        column: x => x.produto_,
                        principalTable: "Produto",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemRequisicao_Requisicao_requisicao_",
                        column: x => x.requisicao_,
                        principalTable: "Requisicao",
                        principalColumn: "IdRequisicao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoImagem",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false),
                    ImagemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoImagem", x => new { x.ImagemId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_ProdutoImagem_Imagem_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagem",
                        principalColumn: "IdImagem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoImagem_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    IdForm = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    link_ = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    div_ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.IdForm);
                    table.ForeignKey(
                        name: "FK_Form_Div_div_",
                        column: x => x.div_,
                        principalTable: "Div",
                        principalColumn: "IdDiv",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Form_Link_link_",
                        column: x => x.link_,
                        principalTable: "Link",
                        principalColumn: "IdLink",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campo",
                columns: table => new
                {
                    IdCampo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Placeholder = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    formularioIdForm = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campo", x => x.IdCampo);
                    table.ForeignKey(
                        name: "FK_Campo_Form_formularioIdForm",
                        column: x => x.formularioIdForm,
                        principalTable: "Form",
                        principalColumn: "IdForm",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Elemento",
                columns: table => new
                {
                    IdElemento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    texto_ = table.Column<int>(nullable: true),
                    carousel_ = table.Column<int>(nullable: true),
                    imagem_ = table.Column<int>(nullable: true),
                    video_ = table.Column<int>(nullable: true),
                    link_ = table.Column<int>(nullable: true),
                    form_ = table.Column<int>(nullable: true),
                    table_ = table.Column<int>(nullable: true),
                    div_2 = table.Column<int>(nullable: true),
                    Ordem = table.Column<int>(nullable: false),
                    Renderizar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elemento", x => x.IdElemento);
                    table.ForeignKey(
                        name: "FK_Elemento_Carousel_carousel_",
                        column: x => x.carousel_,
                        principalTable: "Carousel",
                        principalColumn: "IdCarousel",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_Div_div_2",
                        column: x => x.div_2,
                        principalTable: "Div",
                        principalColumn: "IdDiv",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_Form_form_",
                        column: x => x.form_,
                        principalTable: "Form",
                        principalColumn: "IdForm",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_Imagem_imagem_",
                        column: x => x.imagem_,
                        principalTable: "Imagem",
                        principalColumn: "IdImagem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_Link_link_",
                        column: x => x.link_,
                        principalTable: "Link",
                        principalColumn: "IdLink",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_Table_table_",
                        column: x => x.table_,
                        principalTable: "Table",
                        principalColumn: "IdTable",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_Texto_texto_",
                        column: x => x.texto_,
                        principalTable: "Texto",
                        principalColumn: "IdTexto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_Video_video_",
                        column: x => x.video_,
                        principalTable: "Video",
                        principalColumn: "IdVideo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Background_PaginaId",
                table: "Background",
                column: "PaginaId");

            migrationBuilder.CreateIndex(
                name: "IX_Background_imagem_",
                table: "Background",
                column: "imagem_");

            migrationBuilder.CreateIndex(
                name: "IX_Campo_formularioIdForm",
                table: "Campo",
                column: "formularioIdForm");

            migrationBuilder.CreateIndex(
                name: "IX_Carousel_div_2",
                table: "Carousel",
                column: "div_2");

            migrationBuilder.CreateIndex(
                name: "IX_CarouselImagem_CarouselId",
                table: "CarouselImagem",
                column: "CarouselId");

            migrationBuilder.CreateIndex(
                name: "IX_Cor_BackgroundGradienteId",
                table: "Cor",
                column: "BackgroundGradienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Div_PaginaId",
                table: "Div",
                column: "PaginaId");

            migrationBuilder.CreateIndex(
                name: "IX_Div_background_",
                table: "Div",
                column: "background_");

            migrationBuilder.CreateIndex(
                name: "IX_DivImagem_DivId",
                table: "DivImagem",
                column: "DivId");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_carousel_",
                table: "Elemento",
                column: "carousel_");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_div_2",
                table: "Elemento",
                column: "div_2");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_form_",
                table: "Elemento",
                column: "form_");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_imagem_",
                table: "Elemento",
                column: "imagem_");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_link_",
                table: "Elemento",
                column: "link_");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_table_",
                table: "Elemento",
                column: "table_");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_texto_",
                table: "Elemento",
                column: "texto_");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_video_",
                table: "Elemento",
                column: "video_");

            migrationBuilder.CreateIndex(
                name: "IX_Form_div_",
                table: "Form",
                column: "div_");

            migrationBuilder.CreateIndex(
                name: "IX_Form_link_",
                table: "Form",
                column: "link_");

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_PastaImagemId",
                table: "Imagem",
                column: "PastaImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequisicao_produto_",
                table: "ItemRequisicao",
                column: "produto_");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequisicao_requisicao_",
                table: "ItemRequisicao",
                column: "requisicao_");

            migrationBuilder.CreateIndex(
                name: "IX_Link_div_",
                table: "Link",
                column: "div_");

            migrationBuilder.CreateIndex(
                name: "IX_Link_imagem_",
                table: "Link",
                column: "imagem_");

            migrationBuilder.CreateIndex(
                name: "IX_Link_pagina_",
                table: "Link",
                column: "pagina_");

            migrationBuilder.CreateIndex(
                name: "IX_Link_texto_",
                table: "Link",
                column: "texto_");

            migrationBuilder.CreateIndex(
                name: "IX_Pagina_pedido_",
                table: "Pagina",
                column: "pedido_");

            migrationBuilder.CreateIndex(
                name: "IX_PastaImagem_PaginaId",
                table: "PastaImagem",
                column: "PaginaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_DominioTemporario",
                table: "Pedido",
                column: "DominioTemporario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_table_",
                table: "Produto",
                column: "table_");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoImagem_ProdutoId",
                table: "ProdutoImagem",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Table_div_",
                table: "Table",
                column: "div_");

            migrationBuilder.CreateIndex(
                name: "IX_Texto_div_",
                table: "Texto",
                column: "div_");

            migrationBuilder.CreateIndex(
                name: "IX_Video_div_",
                table: "Video",
                column: "div_");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Campo");

            migrationBuilder.DropTable(
                name: "CarouselImagem");

            migrationBuilder.DropTable(
                name: "ContaBancaria");

            migrationBuilder.DropTable(
                name: "Cor");

            migrationBuilder.DropTable(
                name: "DivImagem");

            migrationBuilder.DropTable(
                name: "Elemento");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "EnderecoRequisicao");

            migrationBuilder.DropTable(
                name: "InfoEntrega");

            migrationBuilder.DropTable(
                name: "InfoVenda");

            migrationBuilder.DropTable(
                name: "ItemRequisicao");

            migrationBuilder.DropTable(
                name: "MensagemChat");

            migrationBuilder.DropTable(
                name: "Permissao");

            migrationBuilder.DropTable(
                name: "ProdutoImagem");

            migrationBuilder.DropTable(
                name: "Rota");

            migrationBuilder.DropTable(
                name: "Servico");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BackgroundGradiente");

            migrationBuilder.DropTable(
                name: "Carousel");

            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Requisicao");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "Texto");

            migrationBuilder.DropTable(
                name: "Div");

            migrationBuilder.DropTable(
                name: "Background");

            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.DropTable(
                name: "PastaImagem");

            migrationBuilder.DropTable(
                name: "Pagina");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
