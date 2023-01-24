using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Renaming_Some_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstudianteGrupos_Estudiante_EstudianteId",
                table: "EstudianteGrupos");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudianteGrupos_Grupo_GrupoId",
                table: "EstudianteGrupos");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantePrograma_Programas_ProgramaId",
                table: "EstudiantePrograma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programas",
                table: "Programas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstudianteGrupos",
                table: "EstudianteGrupos");

            migrationBuilder.RenameTable(
                name: "Programas",
                newName: "Programa");

            migrationBuilder.RenameTable(
                name: "EstudianteGrupos",
                newName: "EstudianteGrupo");

            migrationBuilder.RenameIndex(
                name: "IX_EstudianteGrupos_GrupoId",
                table: "EstudianteGrupo",
                newName: "IX_EstudianteGrupo_GrupoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programa",
                table: "Programa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstudianteGrupo",
                table: "EstudianteGrupo",
                columns: new[] { "EstudianteId", "GrupoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EstudianteGrupo_Estudiante_EstudianteId",
                table: "EstudianteGrupo",
                column: "EstudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudianteGrupo_Grupo_GrupoId",
                table: "EstudianteGrupo",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantePrograma_Programa_ProgramaId",
                table: "EstudiantePrograma",
                column: "ProgramaId",
                principalTable: "Programa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstudianteGrupo_Estudiante_EstudianteId",
                table: "EstudianteGrupo");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudianteGrupo_Grupo_GrupoId",
                table: "EstudianteGrupo");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantePrograma_Programa_ProgramaId",
                table: "EstudiantePrograma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programa",
                table: "Programa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstudianteGrupo",
                table: "EstudianteGrupo");

            migrationBuilder.RenameTable(
                name: "Programa",
                newName: "Programas");

            migrationBuilder.RenameTable(
                name: "EstudianteGrupo",
                newName: "EstudianteGrupos");

            migrationBuilder.RenameIndex(
                name: "IX_EstudianteGrupo_GrupoId",
                table: "EstudianteGrupos",
                newName: "IX_EstudianteGrupos_GrupoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programas",
                table: "Programas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstudianteGrupos",
                table: "EstudianteGrupos",
                columns: new[] { "EstudianteId", "GrupoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EstudianteGrupos_Estudiante_EstudianteId",
                table: "EstudianteGrupos",
                column: "EstudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudianteGrupos_Grupo_GrupoId",
                table: "EstudianteGrupos",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantePrograma_Programas_ProgramaId",
                table: "EstudiantePrograma",
                column: "ProgramaId",
                principalTable: "Programas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
