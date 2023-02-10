using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Updating_RespuestasAsaConsolidado_Table_RespuestaCorrecta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "RespuestaCorrecta",
                table: "RespuestasAsaConsolidado",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RespuestaCorrecta",
                table: "RespuestasAsaConsolidado",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
