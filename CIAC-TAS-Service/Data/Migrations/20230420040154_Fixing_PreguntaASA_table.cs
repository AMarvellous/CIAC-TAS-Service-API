using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Fixing_PreguntaASA_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsa_GrupoPreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsa_GrupoPreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "GrupoPreguntaAsaId",
                principalTable: "GrupoPreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsa_GrupoPreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsa_GrupoPreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "GrupoPreguntaAsaId",
                principalTable: "GrupoPreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
