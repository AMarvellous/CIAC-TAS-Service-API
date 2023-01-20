using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Modifying_FK_For_ConfiguracionPreguntaAsa_Table_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ConfiguracionPreguntaAsa_GrupoId",
                table: "ConfiguracionPreguntaAsa");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracionPreguntaAsa_GrupoId",
                table: "ConfiguracionPreguntaAsa",
                column: "GrupoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ConfiguracionPreguntaAsa_GrupoId",
                table: "ConfiguracionPreguntaAsa");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracionPreguntaAsa_GrupoId",
                table: "ConfiguracionPreguntaAsa",
                column: "GrupoId",
                unique: true);
        }
    }
}
