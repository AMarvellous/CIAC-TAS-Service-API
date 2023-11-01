using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Edit_RegistroNotaEstudiante_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaDominio",
                table: "RegistroNotaEstudiante");

            migrationBuilder.RenameColumn(
                name: "NotaProgreso",
                table: "RegistroNotaEstudiante",
                newName: "Nota");

            migrationBuilder.AddColumn<bool>(
                name: "TipoDominio",
                table: "RegistroNotaEstudiante",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDominio",
                table: "RegistroNotaEstudiante");

            migrationBuilder.RenameColumn(
                name: "Nota",
                table: "RegistroNotaEstudiante",
                newName: "NotaProgreso");

            migrationBuilder.AddColumn<double>(
                name: "NotaDominio",
                table: "RegistroNotaEstudiante",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
