using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Reverting_Respuestas_Asa_to_PreguntaASA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsa_RespuestasAsas_PreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.DropIndex(
                name: "IX_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.DropColumn(
                name: "PreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestasAsas_PreguntaAsaId",
                table: "RespuestasAsas",
                column: "PreguntaAsaId");

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsas_PreguntaAsa_PreguntaAsaId",
                table: "RespuestasAsas",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsas_PreguntaAsa_PreguntaAsaId",
                table: "RespuestasAsas");

            migrationBuilder.DropIndex(
                name: "IX_RespuestasAsas_PreguntaAsaId",
                table: "RespuestasAsas");

            migrationBuilder.AddColumn<int>(
                name: "PreguntaAsaId",
                table: "PreguntaAsa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsa",
                column: "PreguntaAsaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsa_RespuestasAsas_PreguntaAsaId",
                table: "PreguntaAsa",
                column: "PreguntaAsaId",
                principalTable: "RespuestasAsas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
