using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuProjetoAgora.Migrations
{
    public partial class ExibicaoPagina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Exibicao",
                table: "Pagina",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exibicao",
                table: "Pagina");
        }
    }
}
