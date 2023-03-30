using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Update_ExamenGeneradoPregunta_Adding_PreguntaAsa_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreguntaAsaId",
                table: "ExamenGeneradoPregunta",
                newName: "PreguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenGeneradoPregunta_PreguntaId",
                table: "ExamenGeneradoPregunta",
                column: "PreguntaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamenGeneradoPregunta_PreguntaAsa_PreguntaId",
                table: "ExamenGeneradoPregunta",
                column: "PreguntaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamenGeneradoPregunta_PreguntaAsa_PreguntaId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropIndex(
                name: "IX_ExamenGeneradoPregunta_PreguntaId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.RenameColumn(
                name: "PreguntaId",
                table: "ExamenGeneradoPregunta",
                newName: "PreguntaAsaId");
        }
    }
}
