using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuProjetoAgora.Migrations
{
    public partial class EscolherPosicaoBlocoFixado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EscolherPosicao",
                table: "Div",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "InicioFixacao",
                table: "Div",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosicaoFixacao",
                table: "Div",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EscolherPosicao",
                table: "Div");

            migrationBuilder.DropColumn(
                name: "InicioFixacao",
                table: "Div");

            migrationBuilder.DropColumn(
                name: "PosicaoFixacao",
                table: "Div");
        }
    }
}
