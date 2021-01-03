using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuProjetoAgora.Migrations
{
    public partial class RemoveIsUniqueProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Elemento_Codigo",
                table: "Elemento");

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Elemento",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Elemento",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Elemento_Codigo",
                table: "Elemento",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");
        }
    }
}
