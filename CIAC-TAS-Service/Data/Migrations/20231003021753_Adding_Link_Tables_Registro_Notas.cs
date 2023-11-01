using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Adding_Link_Tables_Registro_Notas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RegistroNotaEstudianteHeader_EstudianteId",
                table: "RegistroNotaEstudianteHeader",
                column: "EstudianteId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroNotaEstudianteHeader_Estudiante_EstudianteId",
                table: "RegistroNotaEstudianteHeader",
                column: "EstudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroNotaEstudianteHeader_Estudiante_EstudianteId",
                table: "RegistroNotaEstudianteHeader");

            migrationBuilder.DropIndex(
                name: "IX_RegistroNotaEstudianteHeader_EstudianteId",
                table: "RegistroNotaEstudianteHeader");
        }
    }
}
