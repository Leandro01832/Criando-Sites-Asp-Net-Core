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
                name: "Cadastro",
                columns: table => new
                {
                    IdCadastro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: false),
                    Complemento = table.Column<string>(nullable: false),
                    Bairro = table.Column<string>(nullable: false),
                    Municipio = table.Column<string>(nullable: false),
                    UF = table.Column<string>(nullable: false),
                    CEP = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.IdCadastro);
                });

            migrationBuilder.CreateTable(
                name: "ContaBancaria",
                columns: table => new
                {
                    IdContaBancaria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoBanco = table.Column<string>(nullable: false),
                    TipoConta = table.Column<string>(nullable: false),
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
                name: "DadoFormulario",
                columns: table => new
                {
                    IdDadoFormulario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Formulario = table.Column<int>(nullable: false),
                    Campo = table.Column<int>(nullable: false),
                    Valor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadoFormulario", x => x.IdDadoFormulario);
                });

            migrationBuilder.CreateTable(
                name: "InfoEntrega",
                columns: table => new
                {
                    IdInfoEntrega = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LarguraCaixa = table.Column<int>(nullable: true),
                    AlturaCaixa = table.Column<int>(nullable: true),
                    PesoCaixa = table.Column<int>(nullable: true),
                    ComprimentoCaixa = table.Column<int>(nullable: true),
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
                    Cpf = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    Bairro = table.Column<string>(nullable: false),
                    Rua = table.Column<string>(nullable: false),
                    Numero = table.Column<long>(nullable: false),
                    Cep = table.Column<string>(nullable: false),
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
                    DiasLiberados = table.Column<int>(nullable: false),
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
                name: "Requisicao",
                columns: table => new
                {
                    IdRequisicao = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    DataPedidoCompra = table.Column<DateTime>(nullable: false),
                    ValorPedido = table.Column<string>(nullable: true),
                    ClienteId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisicao", x => x.IdRequisicao);
                    table.ForeignKey(
                        name: "FK_Requisicao_Cadastro_IdRequisicao",
                        column: x => x.IdRequisicao,
                        principalTable: "Cadastro",
                        principalColumn: "IdCadastro",
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
                    Topo = table.Column<bool>(nullable: false),
                    Menu = table.Column<bool>(nullable: false),
                    Exibicao = table.Column<bool>(nullable: false),
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
                name: "Elemento",
                columns: table => new
                {
                    IdElemento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Ordem = table.Column<int>(nullable: false),
                    Pagina_ = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Placeholder = table.Column<string>(nullable: true),
                    TipoCampo = table.Column<string>(nullable: true),
                    ArquivoImagem = table.Column<string>(nullable: true),
                    Width = table.Column<int>(nullable: true),
                    PastaImagemId = table.Column<int>(nullable: true),
                    UrlLink = table.Column<bool>(nullable: true),
                    Menu = table.Column<bool>(nullable: true),
                    TextoLink = table.Column<string>(nullable: true),
                    paginaDestinoLink_ = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: true),
                    estoque = table.Column<long>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Segmento = table.Column<string>(nullable: true),
                    EstiloTabela = table.Column<string>(nullable: true),
                    PalavrasTexto = table.Column<string>(nullable: true),
                    ArquivoVideo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elemento", x => x.IdElemento);
                    table.ForeignKey(
                        name: "FK_Elemento_PastaImagem_PastaImagemId",
                        column: x => x.PastaImagemId,
                        principalTable: "PastaImagem",
                        principalColumn: "IdPastaImagem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_Pagina_paginaDestinoLink_",
                        column: x => x.paginaDestinoLink_,
                        principalTable: "Pagina",
                        principalColumn: "IdPagina",
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
                        name: "FK_Background_Elemento_imagem_",
                        column: x => x.imagem_,
                        principalTable: "Elemento",
                        principalColumn: "IdElemento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElementoDependente",
                columns: table => new
                {
                    IdElementoDependente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Elemento_ = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementoDependente", x => x.IdElementoDependente);
                    table.ForeignKey(
                        name: "FK_ElementoDependente_Elemento_Elemento_",
                        column: x => x.Elemento_,
                        principalTable: "Elemento",
                        principalColumn: "IdElemento",
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
                    PrecoUnitario = table.Column<decimal>(nullable: false),
                    produto_ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRequisicao", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_ItemRequisicao_Elemento_produto_",
                        column: x => x.produto_,
                        principalTable: "Elemento",
                        principalColumn: "IdElemento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemRequisicao_Requisicao_requisicao_",
                        column: x => x.requisicao_,
                        principalTable: "Requisicao",
                        principalColumn: "IdRequisicao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaginaCarouselPagina",
                columns: table => new
                {
                    CarouselPaginaId = table.Column<int>(nullable: false),
                    PaginaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaginaCarouselPagina", x => new { x.CarouselPaginaId, x.PaginaId });
                    table.ForeignKey(
                        name: "FK_PaginaCarouselPagina_Elemento_CarouselPaginaId",
                        column: x => x.CarouselPaginaId,
                        principalTable: "Elemento",
                        principalColumn: "IdElemento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaginaCarouselPagina_Pagina_PaginaId",
                        column: x => x.PaginaId,
                        principalTable: "Pagina",
                        principalColumn: "IdPagina",
                        onDelete: ReferentialAction.Cascade);
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
                    Fixado = table.Column<bool>(nullable: false),
                    EscolherPosicao = table.Column<bool>(nullable: false),
                    PosicaoFixacao = table.Column<int>(nullable: false),
                    InicioFixacao = table.Column<int>(nullable: false),
                    EixoYBlocoFixado = table.Column<int>(nullable: false),
                    EixoXBlocoFixado = table.Column<int>(nullable: false),
                    Ordem = table.Column<int>(nullable: false),
                    background_ = table.Column<int>(nullable: false),
                    Pagina_ = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Div", x => x.IdDiv);
                    table.ForeignKey(
                        name: "FK_Div_Background_background_",
                        column: x => x.background_,
                        principalTable: "Background",
                        principalColumn: "IdBackground",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementoDependenteElemento",
                columns: table => new
                {
                    ElementoId = table.Column<int>(nullable: false),
                    ElementoDependenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementoDependenteElemento", x => new { x.ElementoDependenteId, x.ElementoId });
                    table.ForeignKey(
                        name: "FK_ElementoDependenteElemento_ElementoDependente_ElementoDependenteId",
                        column: x => x.ElementoDependenteId,
                        principalTable: "ElementoDependente",
                        principalColumn: "IdElementoDependente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementoDependenteElemento_Elemento_ElementoId",
                        column: x => x.ElementoId,
                        principalTable: "Elemento",
                        principalColumn: "IdElemento",
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
                name: "DivElemento",
                columns: table => new
                {
                    ElementoId = table.Column<int>(nullable: false),
                    DivId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivElemento", x => new { x.DivId, x.ElementoId });
                    table.ForeignKey(
                        name: "FK_DivElemento_Div_DivId",
                        column: x => x.DivId,
                        principalTable: "Div",
                        principalColumn: "IdDiv",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivElemento_Elemento_ElementoId",
                        column: x => x.ElementoId,
                        principalTable: "Elemento",
                        principalColumn: "IdElemento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DivPagina",
                columns: table => new
                {
                    PaginaId = table.Column<int>(nullable: false),
                    DivId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivPagina", x => new { x.DivId, x.PaginaId });
                    table.ForeignKey(
                        name: "FK_DivPagina_Div_DivId",
                        column: x => x.DivId,
                        principalTable: "Div",
                        principalColumn: "IdDiv",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivPagina_Pagina_PaginaId",
                        column: x => x.PaginaId,
                        principalTable: "Pagina",
                        principalColumn: "IdPagina",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Cor_BackgroundGradienteId",
                table: "Cor",
                column: "BackgroundGradienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Div_background_",
                table: "Div",
                column: "background_");

            migrationBuilder.CreateIndex(
                name: "IX_DivElemento_ElementoId",
                table: "DivElemento",
                column: "ElementoId");

            migrationBuilder.CreateIndex(
                name: "IX_DivPagina_PaginaId",
                table: "DivPagina",
                column: "PaginaId");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_PastaImagemId",
                table: "Elemento",
                column: "PastaImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_paginaDestinoLink_",
                table: "Elemento",
                column: "paginaDestinoLink_");

            migrationBuilder.CreateIndex(
                name: "IX_ElementoDependente_Elemento_",
                table: "ElementoDependente",
                column: "Elemento_");

            migrationBuilder.CreateIndex(
                name: "IX_ElementoDependenteElemento_ElementoId",
                table: "ElementoDependenteElemento",
                column: "ElementoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequisicao_produto_",
                table: "ItemRequisicao",
                column: "produto_");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequisicao_requisicao_",
                table: "ItemRequisicao",
                column: "requisicao_");

            migrationBuilder.CreateIndex(
                name: "IX_Pagina_pedido_",
                table: "Pagina",
                column: "pedido_");

            migrationBuilder.CreateIndex(
                name: "IX_PaginaCarouselPagina_PaginaId",
                table: "PaginaCarouselPagina",
                column: "PaginaId");

            migrationBuilder.CreateIndex(
                name: "IX_PastaImagem_PaginaId",
                table: "PastaImagem",
                column: "PaginaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_DominioTemporario",
                table: "Pedido",
                column: "DominioTemporario",
                unique: true);
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
                name: "ContaBancaria");

            migrationBuilder.DropTable(
                name: "Cor");

            migrationBuilder.DropTable(
                name: "DadoFormulario");

            migrationBuilder.DropTable(
                name: "DivElemento");

            migrationBuilder.DropTable(
                name: "DivPagina");

            migrationBuilder.DropTable(
                name: "ElementoDependenteElemento");

            migrationBuilder.DropTable(
                name: "InfoEntrega");

            migrationBuilder.DropTable(
                name: "InfoVenda");

            migrationBuilder.DropTable(
                name: "ItemRequisicao");

            migrationBuilder.DropTable(
                name: "MensagemChat");

            migrationBuilder.DropTable(
                name: "PaginaCarouselPagina");

            migrationBuilder.DropTable(
                name: "Permissao");

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
                name: "Div");

            migrationBuilder.DropTable(
                name: "ElementoDependente");

            migrationBuilder.DropTable(
                name: "Requisicao");

            migrationBuilder.DropTable(
                name: "Background");

            migrationBuilder.DropTable(
                name: "Cadastro");

            migrationBuilder.DropTable(
                name: "Elemento");

            migrationBuilder.DropTable(
                name: "PastaImagem");

            migrationBuilder.DropTable(
                name: "Pagina");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
