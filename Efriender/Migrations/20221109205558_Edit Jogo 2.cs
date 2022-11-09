using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Efriender.Migrations
{
    public partial class EditJogo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JogoSecond",
                table: "Usuário");

            migrationBuilder.AddColumn<string>(
                name: "JogoSecundario",
                table: "Usuário",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JogoSecundario",
                table: "Usuário");

            migrationBuilder.AddColumn<int>(
                name: "JogoSecond",
                table: "Usuário",
                type: "int",
                nullable: true);
        }
    }
}
