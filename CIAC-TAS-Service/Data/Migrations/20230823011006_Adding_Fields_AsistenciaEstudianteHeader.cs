using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Adding_Fields_AsistenciaEstudianteHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraFin",
                table: "AsistenciaEstudianteHeader",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraInicio",
                table: "AsistenciaEstudianteHeader",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "Tema",
                table: "AsistenciaEstudianteHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TotalHorasPracticas",
                table: "AsistenciaEstudianteHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalHorasTeoricas",
                table: "AsistenciaEstudianteHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraFin",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropColumn(
                name: "HoraInicio",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropColumn(
                name: "Tema",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropColumn(
                name: "TotalHorasPracticas",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropColumn(
                name: "TotalHorasTeoricas",
                table: "AsistenciaEstudianteHeader");
        }
    }
}
