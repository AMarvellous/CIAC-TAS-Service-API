using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Updating_index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AsistenciaEstudiante_TipoAsistenciaId",
                table: "AsistenciaEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaEstudiante_TipoAsistenciaId",
                table: "AsistenciaEstudiante",
                column: "TipoAsistenciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AsistenciaEstudiante_TipoAsistenciaId",
                table: "AsistenciaEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaEstudiante_TipoAsistenciaId",
                table: "AsistenciaEstudiante",
                column: "TipoAsistenciaId",
                unique: true);
        }
    }
}
