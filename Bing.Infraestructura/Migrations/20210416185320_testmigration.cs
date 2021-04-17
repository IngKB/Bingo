using Microsoft.EntityFrameworkCore.Migrations;

namespace Bingo.Infraestructura.Migrations
{
    public partial class testmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codigo",
                table: "Cartones");

            migrationBuilder.CreateTable(
                name: "Casilla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Marcado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    coordenada_posX = table.Column<int>(type: "int", nullable: true),
                    coordenada_posY = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casilla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Casilla_Cartones_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Cartones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casilla_OwnerId",
                table: "Casilla",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casilla");

            migrationBuilder.AddColumn<string>(
                name: "codigo",
                table: "Cartones",
                type: "text",
                nullable: true);
        }
    }
}
