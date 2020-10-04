using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuProjetoAgora.Migrations
{
    public partial class NomeElemento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Elemento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Elemento");
        }
    }
}
