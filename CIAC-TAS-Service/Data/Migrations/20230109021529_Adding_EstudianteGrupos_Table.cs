using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Adding_EstudianteGrupos_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_Grupo_GrupoId",
                table: "Estudiante");

            migrationBuilder.DropIndex(
                name: "IX_Estudiante_GrupoId",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Estudiante");

            migrationBuilder.CreateTable(
                name: "EstudianteGrupos",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    GrupoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudianteGrupos", x => new { x.EstudianteId, x.GrupoId });
                    table.ForeignKey(
                        name: "FK_EstudianteGrupos_Estudiante_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudianteGrupos_Grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteGrupos_GrupoId",
                table: "EstudianteGrupos",
                column: "GrupoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudianteGrupos");

            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "Estudiante",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_GrupoId",
                table: "Estudiante",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_Grupo_GrupoId",
                table: "Estudiante",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id");
        }
    }
}
