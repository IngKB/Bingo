using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Bingo.Infraestructura.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    JugadorID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Casilla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Marcado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    coordenada_posX = table.Column<int>(type: "int", nullable: true),
                    coordenada_posY = table.Column<int>(type: "int", nullable: true),
                    CartonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casilla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Casilla_Cartones_CartonId",
                        column: x => x.CartonId,
                        principalTable: "Cartones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casilla_CartonId",
                table: "Casilla",
                column: "CartonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casilla");

            migrationBuilder.DropTable(
                name: "Cartones");
        }
    }
}
