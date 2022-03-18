using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class Inicio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Layout",
                table: "Pagina",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Layout",
                table: "Pagina");
        }
    }
}
