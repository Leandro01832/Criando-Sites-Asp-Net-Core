using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuProjetoAgora.Migrations
{
    public partial class RemoveEstiloFormulario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstiloFormulario",
                table: "Elemento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EstiloFormulario",
                table: "Elemento",
                nullable: true);
        }
    }
}
