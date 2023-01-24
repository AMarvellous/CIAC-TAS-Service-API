using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Adding_Index_PreguntaAsa_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PreguntaAsa_EstadoPreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.DropIndex(
                name: "IX_PreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaAsa_EstadoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "EstadoPreguntaAsaId");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "GrupoPreguntaAsaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PreguntaAsa_EstadoPreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.DropIndex(
                name: "IX_PreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaAsa_EstadoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "EstadoPreguntaAsaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "GrupoPreguntaAsaId",
                unique: true);
        }
    }
}
