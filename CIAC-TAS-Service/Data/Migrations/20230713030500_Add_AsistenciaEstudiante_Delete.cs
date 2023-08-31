using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Add_AsistenciaEstudiante_Delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudiante_TipoAsistencia_TipoAsistenciaId",
                table: "AsistenciaEstudiante");

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudiante_TipoAsistencia_TipoAsistenciaId",
                table: "AsistenciaEstudiante",
                column: "TipoAsistenciaId",
                principalTable: "TipoAsistencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudiante_TipoAsistencia_TipoAsistenciaId",
                table: "AsistenciaEstudiante");

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudiante_TipoAsistencia_TipoAsistenciaId",
                table: "AsistenciaEstudiante",
                column: "TipoAsistenciaId",
                principalTable: "TipoAsistencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
