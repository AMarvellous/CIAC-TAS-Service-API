using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Removing_TipoDominio_From_RegistroNotaEstudiante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDominio",
                table: "RegistroNotaEstudiante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TipoDominio",
                table: "RegistroNotaEstudiante",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
