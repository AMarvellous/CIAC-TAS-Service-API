using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Fixing_PreguntaAsaOpcion_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsaOpcion_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaOpcion");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsaOpcion_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaOpcion",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsaOpcion_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaOpcion");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsaOpcion_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaOpcion",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
