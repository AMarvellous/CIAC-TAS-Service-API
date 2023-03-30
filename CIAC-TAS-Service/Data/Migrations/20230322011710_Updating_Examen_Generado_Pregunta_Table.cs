using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Updating_Examen_Generado_Pregunta_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreguntaAsaId",
                table: "ExamenGeneradoPregunta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExamenGeneradoPregunta_PreguntaAsaId",
                table: "ExamenGeneradoPregunta",
                column: "PreguntaAsaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamenGeneradoPregunta_PreguntaAsa_PreguntaAsaId",
                table: "ExamenGeneradoPregunta",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamenGeneradoPregunta_PreguntaAsa_PreguntaAsaId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropIndex(
                name: "IX_ExamenGeneradoPregunta_PreguntaAsaId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropColumn(
                name: "PreguntaAsaId",
                table: "ExamenGeneradoPregunta");
        }
    }
}
