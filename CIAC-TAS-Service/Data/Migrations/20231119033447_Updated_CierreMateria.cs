using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Updated_CierreMateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CierreMateria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AsistenciaEstudianteHeaderId = table.Column<int>(type: "int", nullable: false),
                    RegistroNotaHeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CierreMateria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CierreMateria_AsistenciaEstudianteHeader_AsistenciaEstudianteHeaderId",
                        column: x => x.AsistenciaEstudianteHeaderId,
                        principalTable: "AsistenciaEstudianteHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CierreMateria_RegistroNotaHeader_RegistroNotaHeaderId",
                        column: x => x.RegistroNotaHeaderId,
                        principalTable: "RegistroNotaHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CierreMateria_AsistenciaEstudianteHeaderId",
                table: "CierreMateria",
                column: "AsistenciaEstudianteHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_CierreMateria_RegistroNotaHeaderId",
                table: "CierreMateria",
                column: "RegistroNotaHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CierreMateria");
        }
    }
}
