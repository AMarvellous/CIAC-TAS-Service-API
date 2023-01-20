using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Modifying_FK_For_ConfiguracionPreguntaAsa_Table_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupo_ConfiguracionPreguntaAsa_GrupoId",
                table: "Grupo");

            migrationBuilder.DropIndex(
                name: "IX_Grupo_GrupoId",
                table: "Grupo");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Grupo");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracionPreguntaAsa_GrupoId",
                table: "ConfiguracionPreguntaAsa",
                column: "GrupoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracionPreguntaAsa_Grupo_GrupoId",
                table: "ConfiguracionPreguntaAsa",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracionPreguntaAsa_Grupo_GrupoId",
                table: "ConfiguracionPreguntaAsa");

            migrationBuilder.DropIndex(
                name: "IX_ConfiguracionPreguntaAsa_GrupoId",
                table: "ConfiguracionPreguntaAsa");

            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "Grupo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_GrupoId",
                table: "Grupo",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupo_ConfiguracionPreguntaAsa_GrupoId",
                table: "Grupo",
                column: "GrupoId",
                principalTable: "ConfiguracionPreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
