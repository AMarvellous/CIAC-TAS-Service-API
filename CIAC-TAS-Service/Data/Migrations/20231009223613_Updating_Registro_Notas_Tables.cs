using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Updating_Registro_Notas_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PorcentajeDominioTotal",
                table: "RegistroNotaEstudianteHeader");

            migrationBuilder.DropColumn(
                name: "PorcentajeProgresoTotal",
                table: "RegistroNotaEstudianteHeader");

            migrationBuilder.AddColumn<int>(
                name: "PorcentajeDominioTotal",
                table: "RegistroNotaHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PorcentajeProgresoTotal",
                table: "RegistroNotaHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PorcentajeDominioTotal",
                table: "RegistroNotaHeader");

            migrationBuilder.DropColumn(
                name: "PorcentajeProgresoTotal",
                table: "RegistroNotaHeader");

            migrationBuilder.AddColumn<int>(
                name: "PorcentajeDominioTotal",
                table: "RegistroNotaEstudianteHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PorcentajeProgresoTotal",
                table: "RegistroNotaEstudianteHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
