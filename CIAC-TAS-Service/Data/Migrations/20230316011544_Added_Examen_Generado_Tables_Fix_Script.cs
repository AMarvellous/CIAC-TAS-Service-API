using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Added_Examen_Generado_Tables_Fix_Script : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamenGenerado_PreguntaAsa_PreguntaAsaId",
                table: "ExamenGenerado");

            migrationBuilder.DropIndex(
                name: "IX_ExamenGenerado_PreguntaAsaId",
                table: "ExamenGenerado");

            migrationBuilder.DropColumn(
                name: "PreguntaAsaId",
                table: "ExamenGenerado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreguntaAsaId",
                table: "ExamenGenerado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamenGenerado_PreguntaAsaId",
                table: "ExamenGenerado",
                column: "PreguntaAsaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamenGenerado_PreguntaAsa_PreguntaAsaId",
                table: "ExamenGenerado",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id");
        }
    }
}
