using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class inicio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EscolherPosicao",
                table: "Div",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EscolherPosicao",
                table: "Div");
        }
    }
}
