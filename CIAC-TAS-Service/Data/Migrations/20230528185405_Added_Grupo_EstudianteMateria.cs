using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Added_Grupo_EstudianteMateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EstudianteMateria",
                table: "EstudianteMateria");

            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "EstudianteMateria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstudianteMateria",
                table: "EstudianteMateria",
                columns: new[] { "EstudianteId", "GrupoId", "MateriaId" });

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteMateria_GrupoId",
                table: "EstudianteMateria",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstudianteMateria_Grupo_GrupoId",
                table: "EstudianteMateria",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstudianteMateria_Grupo_GrupoId",
                table: "EstudianteMateria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstudianteMateria",
                table: "EstudianteMateria");

            migrationBuilder.DropIndex(
                name: "IX_EstudianteMateria_GrupoId",
                table: "EstudianteMateria");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "EstudianteMateria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstudianteMateria",
                table: "EstudianteMateria",
                columns: new[] { "EstudianteId", "MateriaId" });
        }
    }
}
