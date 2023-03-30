using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Modifying_Examen_Generado_Table_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreguntaId",
                table: "ExamenGeneradoPregunta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreguntaId",
                table: "ExamenGeneradoPregunta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
