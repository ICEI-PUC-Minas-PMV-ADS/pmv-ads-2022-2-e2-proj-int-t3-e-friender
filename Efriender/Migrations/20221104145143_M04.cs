using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Efriender.Migrations
{
    public partial class M04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combinaçoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Usuario1 = table.Column<int>(type: "int", nullable: false),
                    Id_Usuario2 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combinaçoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combinaçoes_Usuário_Id_Usuario1",
                        column: x => x.Id_Usuario1,
                        principalTable: "Usuário",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Combinaçoes_Usuário_Id_Usuario2",
                        column: x => x.Id_Usuario2,
                        principalTable: "Usuário",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Combinaçoes_Id_Usuario1",
                table: "Combinaçoes",
                column: "Id_Usuario1");

            migrationBuilder.CreateIndex(
                name: "IX_Combinaçoes_Id_Usuario2",
                table: "Combinaçoes",
                column: "Id_Usuario2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combinaçoes");
        }
    }
}
