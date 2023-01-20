using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Added_Programa_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantePrograma_Programa_ProgramaId",
                table: "EstudiantePrograma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programa",
                table: "Programa");

            migrationBuilder.RenameTable(
                name: "Programa",
                newName: "Programas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programas",
                table: "Programas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantePrograma_Programas_ProgramaId",
                table: "EstudiantePrograma",
                column: "ProgramaId",
                principalTable: "Programas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantePrograma_Programas_ProgramaId",
                table: "EstudiantePrograma");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Programas",
                table: "Programas");

            migrationBuilder.RenameTable(
                name: "Programas",
                newName: "Programa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programa",
                table: "Programa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantePrograma_Programa_ProgramaId",
                table: "EstudiantePrograma",
                column: "ProgramaId",
                principalTable: "Programa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
