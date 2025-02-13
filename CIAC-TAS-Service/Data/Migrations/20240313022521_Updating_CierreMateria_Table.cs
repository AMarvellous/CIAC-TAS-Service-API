using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Updating_CierreMateria_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CierreMateria_AsistenciaEstudianteHeader_AsistenciaEstudianteHeaderId",
                table: "CierreMateria");

            migrationBuilder.DropForeignKey(
                name: "FK_CierreMateria_RegistroNotaHeader_RegistroNotaHeaderId",
                table: "CierreMateria");

            migrationBuilder.DropIndex(
                name: "IX_CierreMateria_AsistenciaEstudianteHeaderId",
                table: "CierreMateria");

            migrationBuilder.DropIndex(
                name: "IX_CierreMateria_RegistroNotaHeaderId",
                table: "CierreMateria");

            migrationBuilder.DropColumn(
                name: "AsistenciaEstudianteHeaderId",
                table: "CierreMateria");

            migrationBuilder.DropColumn(
                name: "RegistroNotaHeaderId",
                table: "CierreMateria");

            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "CierreMateria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MateriaId",
                table: "CierreMateria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CierreMateria_GrupoId",
                table: "CierreMateria",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_CierreMateria_MateriaId",
                table: "CierreMateria",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CierreMateria_Grupo_GrupoId",
                table: "CierreMateria",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CierreMateria_Materia_MateriaId",
                table: "CierreMateria",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CierreMateria_Grupo_GrupoId",
                table: "CierreMateria");

            migrationBuilder.DropForeignKey(
                name: "FK_CierreMateria_Materia_MateriaId",
                table: "CierreMateria");

            migrationBuilder.DropIndex(
                name: "IX_CierreMateria_GrupoId",
                table: "CierreMateria");

            migrationBuilder.DropIndex(
                name: "IX_CierreMateria_MateriaId",
                table: "CierreMateria");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "CierreMateria");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "CierreMateria");

            migrationBuilder.AddColumn<int>(
                name: "AsistenciaEstudianteHeaderId",
                table: "CierreMateria",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegistroNotaHeaderId",
                table: "CierreMateria",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CierreMateria_AsistenciaEstudianteHeaderId",
                table: "CierreMateria",
                column: "AsistenciaEstudianteHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_CierreMateria_RegistroNotaHeaderId",
                table: "CierreMateria",
                column: "RegistroNotaHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CierreMateria_AsistenciaEstudianteHeader_AsistenciaEstudianteHeaderId",
                table: "CierreMateria",
                column: "AsistenciaEstudianteHeaderId",
                principalTable: "AsistenciaEstudianteHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CierreMateria_RegistroNotaHeader_RegistroNotaHeaderId",
                table: "CierreMateria",
                column: "RegistroNotaHeaderId",
                principalTable: "RegistroNotaHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
