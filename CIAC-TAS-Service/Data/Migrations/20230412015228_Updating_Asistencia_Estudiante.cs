using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Updating_Asistencia_Estudiante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AsistenciaEstudianteHeaderId",
                table: "AsistenciaEstudiante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaEstudiante_AsistenciaEstudianteHeaderId",
                table: "AsistenciaEstudiante",
                column: "AsistenciaEstudianteHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudiante_AsistenciaEstudianteHeader_AsistenciaEstudianteHeaderId",
                table: "AsistenciaEstudiante",
                column: "AsistenciaEstudianteHeaderId",
                principalTable: "AsistenciaEstudianteHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudiante_AsistenciaEstudianteHeader_AsistenciaEstudianteHeaderId",
                table: "AsistenciaEstudiante");

            migrationBuilder.DropIndex(
                name: "IX_AsistenciaEstudiante_AsistenciaEstudianteHeaderId",
                table: "AsistenciaEstudiante");

            migrationBuilder.DropColumn(
                name: "AsistenciaEstudianteHeaderId",
                table: "AsistenciaEstudiante");
        }
    }
}
