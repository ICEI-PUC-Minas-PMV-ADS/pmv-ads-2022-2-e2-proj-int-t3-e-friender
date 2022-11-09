using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Efriender.Migrations
{
    public partial class EditJogo2Nullabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JogoSecundario",
                table: "Usuário",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuário",
                keyColumn: "JogoSecundario",
                keyValue: null,
                column: "JogoSecundario",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "JogoSecundario",
                table: "Usuário",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
