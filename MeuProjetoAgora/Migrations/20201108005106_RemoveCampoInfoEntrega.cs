using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuProjetoAgora.Migrations
{
    public partial class RemoveCampoInfoEntrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CidadesEntrega",
                table: "InfoEntrega");

            migrationBuilder.DropColumn(
                name: "EstadosEntrega",
                table: "InfoEntrega");

            migrationBuilder.DropColumn(
                name: "ValorFrete",
                table: "InfoEntrega");

            migrationBuilder.DropColumn(
                name: "entregaCorreio",
                table: "InfoEntrega");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CidadesEntrega",
                table: "InfoEntrega",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadosEntrega",
                table: "InfoEntrega",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorFrete",
                table: "InfoEntrega",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "entregaCorreio",
                table: "InfoEntrega",
                nullable: false,
                defaultValue: false);
        }
    }
}
