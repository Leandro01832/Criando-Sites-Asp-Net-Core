using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class Inicio : Migration
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
                    Id = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Cadastro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContaBancaria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_ContaBancaria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DadoFormulario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Formulario = table.Column<int>(nullable: false),
                    Campo = table.Column<int>(nullable: false),
                    Valor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadoFormulario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Div",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Padding = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Colunas = table.Column<string>(nullable: true),
                    Desenhado = table.Column<int>(nullable: false),
                    Divisao = table.Column<string>(nullable: true),
                    BorderRadius = table.Column<int>(nullable: false),
                    Ordem = table.Column<int>(nullable: false),
                    Pagina_ = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    PosicaoFixacao = table.Column<int>(nullable: true),
                    InicioFixacao = table.Column<int>(nullable: true),
                    EixoYBlocoFixado = table.Column<int>(nullable: true),
                    EixoXBlocoFixado = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Div", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoEntrega",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LarguraCaixa = table.Column<int>(nullable: true),
                    AlturaCaixa = table.Column<int>(nullable: true),
                    PesoCaixa = table.Column<int>(nullable: true),
                    ComprimentoCaixa = table.Column<int>(nullable: true),
                    ClienteId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoEntrega", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoVenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_InfoVenda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MensagemChat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pagina = table.Column<int>(nullable: false),
                    NomeUsuario = table.Column<string>(nullable: true),
                    Mensagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagemChat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomePermissao = table.Column<string>(nullable: true),
                    Site = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NomeRota = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DDD_Celular = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    DDD_Telefone = table.Column<string>(nullable: true),
                    Fone = table.Column<string>(nullable: true),
                    ClienteId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    PedidoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagina_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
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
                        principalColumn: "Id",
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivPagina_Pagina_PaginaId",
                        column: x => x.PaginaId,
                        principalTable: "Pagina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PastaImagem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    PaginaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastaImagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PastaImagem_Pagina_PaginaId",
                        column: x => x.PaginaId,
                        principalTable: "Pagina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Elemento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Ordem = table.Column<int>(nullable: false),
                    Pagina_ = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FormularioId = table.Column<int>(nullable: true),
                    Placeholder = table.Column<string>(nullable: true),
                    TipoCampo = table.Column<string>(nullable: true),
                    ArquivoVideo = table.Column<string>(nullable: true),
                    ArquivoImagem = table.Column<string>(nullable: true),
                    Width = table.Column<int>(nullable: true),
                    PastaImagemId = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: true),
                    estoque = table.Column<long>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Segmento = table.Column<string>(nullable: true),
                    PalavrasTexto = table.Column<string>(nullable: true),
                    Link_TextoId = table.Column<int>(nullable: true),
                    Link_PaginaId = table.Column<int>(nullable: true),
                    EstiloTabela = table.Column<string>(nullable: true),
                    ImagemDependente_ArquivoImagem = table.Column<string>(nullable: true),
                    ImagemDependente_Width = table.Column<int>(nullable: true),
                    ImagemDependente_PastaImagemId = table.Column<int>(nullable: true),
                    TextoId = table.Column<int>(nullable: true),
                    PaginaId = table.Column<int>(nullable: true),
                    TableId = table.Column<int>(nullable: true),
                    ProdutoDependente_Descricao = table.Column<string>(nullable: true),
                    ProdutoDependente_Preco = table.Column<decimal>(nullable: true),
                    ProdutoDependente_estoque = table.Column<long>(nullable: true),
                    ProdutoDependente_Codigo = table.Column<string>(nullable: true),
                    ProdutoDependente_Segmento = table.Column<string>(nullable: true),
                    TextoDependente_PalavrasTexto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elemento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elemento_Elemento_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "Elemento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_PastaImagem_PastaImagemId",
                        column: x => x.PastaImagemId,
                        principalTable: "PastaImagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_PastaImagem_ImagemDependente_PastaImagemId",
                        column: x => x.ImagemDependente_PastaImagemId,
                        principalTable: "PastaImagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_Pagina_PaginaId",
                        column: x => x.PaginaId,
                        principalTable: "Pagina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_Elemento_TextoId",
                        column: x => x.TextoId,
                        principalTable: "Elemento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_Elemento_TableId",
                        column: x => x.TableId,
                        principalTable: "Elemento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_Pagina_Link_PaginaId",
                        column: x => x.Link_PaginaId,
                        principalTable: "Pagina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Elemento_Elemento_Link_TextoId",
                        column: x => x.Link_TextoId,
                        principalTable: "Elemento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Background",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ImagemId1 = table.Column<int>(nullable: true),
                    Cor = table.Column<string>(nullable: true),
                    backgroundTransparente = table.Column<bool>(nullable: true),
                    Grau = table.Column<int>(nullable: true),
                    Background_Repeat = table.Column<string>(nullable: true),
                    Background_Position = table.Column<string>(nullable: true),
                    ImagemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Background", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Background_Div_Id",
                        column: x => x.Id,
                        principalTable: "Div",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Background_Elemento_ImagemId1",
                        column: x => x.ImagemId1,
                        principalTable: "Elemento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Background_Elemento_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Elemento",
                        principalColumn: "Id",
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivElemento_Elemento_ElementoId",
                        column: x => x.ElementoId,
                        principalTable: "Elemento",
                        principalColumn: "Id",
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
                        name: "FK_ElementoDependenteElemento_Elemento_ElementoDependenteId",
                        column: x => x.ElementoDependenteId,
                        principalTable: "Elemento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementoDependenteElemento_Elemento_ElementoId",
                        column: x => x.ElementoId,
                        principalTable: "Elemento",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ItemRequisicao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantidade = table.Column<int>(nullable: false),
                    RequisicaoId = table.Column<int>(nullable: false),
                    PrecoUnitario = table.Column<decimal>(nullable: false),
                    ElementoId = table.Column<int>(nullable: false),
                    ProdutoComumId = table.Column<int>(nullable: true),
                    ProdutoDependenteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRequisicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemRequisicao_Elemento_ElementoId",
                        column: x => x.ElementoId,
                        principalTable: "Elemento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemRequisicao_Elemento_ProdutoComumId",
                        column: x => x.ProdutoComumId,
                        principalTable: "Elemento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemRequisicao_Elemento_ProdutoDependenteId",
                        column: x => x.ProdutoDependenteId,
                        principalTable: "Elemento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemRequisicao_Requisicao_RequisicaoId",
                        column: x => x.RequisicaoId,
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaginaCarouselPagina_Pagina_PaginaId",
                        column: x => x.PaginaId,
                        principalTable: "Pagina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CorBackground = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Transparencia = table.Column<double>(nullable: false),
                    BackgroundGradienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cor_Background_BackgroundGradienteId",
                        column: x => x.BackgroundGradienteId,
                        principalTable: "Background",
                        principalColumn: "Id",
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
                name: "IX_Background_ImagemId1",
                table: "Background",
                column: "ImagemId1");

            migrationBuilder.CreateIndex(
                name: "IX_Background_ImagemId",
                table: "Background",
                column: "ImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Cor_BackgroundGradienteId",
                table: "Cor",
                column: "BackgroundGradienteId");

            migrationBuilder.CreateIndex(
                name: "IX_DivElemento_ElementoId",
                table: "DivElemento",
                column: "ElementoId");

            migrationBuilder.CreateIndex(
                name: "IX_DivPagina_PaginaId",
                table: "DivPagina",
                column: "PaginaId");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_FormularioId",
                table: "Elemento",
                column: "FormularioId");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_PastaImagemId",
                table: "Elemento",
                column: "PastaImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_ImagemDependente_PastaImagemId",
                table: "Elemento",
                column: "ImagemDependente_PastaImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_PaginaId",
                table: "Elemento",
                column: "PaginaId");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_TextoId",
                table: "Elemento",
                column: "TextoId");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_TableId",
                table: "Elemento",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_Link_PaginaId",
                table: "Elemento",
                column: "Link_PaginaId");

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_Link_TextoId",
                table: "Elemento",
                column: "Link_TextoId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementoDependenteElemento_ElementoId",
                table: "ElementoDependenteElemento",
                column: "ElementoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequisicao_ElementoId",
                table: "ItemRequisicao",
                column: "ElementoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequisicao_ProdutoComumId",
                table: "ItemRequisicao",
                column: "ProdutoComumId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequisicao_ProdutoDependenteId",
                table: "ItemRequisicao",
                column: "ProdutoDependenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemRequisicao_RequisicaoId",
                table: "ItemRequisicao",
                column: "RequisicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagina_PedidoId",
                table: "Pagina",
                column: "PedidoId");

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
                name: "Background");

            migrationBuilder.DropTable(
                name: "Requisicao");

            migrationBuilder.DropTable(
                name: "Div");

            migrationBuilder.DropTable(
                name: "Elemento");

            migrationBuilder.DropTable(
                name: "Cadastro");

            migrationBuilder.DropTable(
                name: "PastaImagem");

            migrationBuilder.DropTable(
                name: "Pagina");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
