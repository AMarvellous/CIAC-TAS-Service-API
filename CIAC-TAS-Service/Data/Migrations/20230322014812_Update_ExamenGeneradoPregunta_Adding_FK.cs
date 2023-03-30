using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Update_ExamenGeneradoPregunta_Adding_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
