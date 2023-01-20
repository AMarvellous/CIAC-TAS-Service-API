using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Modifying_PK_For_ConfiguracionPreguntaAsa_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfiguracionPreguntaAsa",
                table: "ConfiguracionPreguntaAsa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfiguracionPreguntaAsa",
                table: "ConfiguracionPreguntaAsa",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfiguracionPreguntaAsa",
                table: "ConfiguracionPreguntaAsa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfiguracionPreguntaAsa",
                table: "ConfiguracionPreguntaAsa",
                columns: new[] { "Id", "GrupoId" });
        }
    }
}
