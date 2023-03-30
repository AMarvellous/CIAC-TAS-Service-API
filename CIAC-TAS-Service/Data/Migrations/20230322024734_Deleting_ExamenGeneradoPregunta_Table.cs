using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Deleting_ExamenGeneradoPregunta_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamenGeneradoPregunta");

            migrationBuilder.AddColumn<Guid>(
                name: "ExamenGeneradoGuid",
                table: "ExamenGenerado",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "NumeroOpcion",
                table: "ExamenGenerado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumeroPregunta",
                table: "ExamenGenerado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OpcionTexto",
                table: "ExamenGenerado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreguntaTexto",
                table: "ExamenGenerado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamenGeneradoGuid",
                table: "ExamenGenerado");

            migrationBuilder.DropColumn(
                name: "NumeroOpcion",
                table: "ExamenGenerado");

            migrationBuilder.DropColumn(
                name: "NumeroPregunta",
                table: "ExamenGenerado");

            migrationBuilder.DropColumn(
                name: "OpcionTexto",
                table: "ExamenGenerado");

            migrationBuilder.DropColumn(
                name: "PreguntaTexto",
                table: "ExamenGenerado");

            migrationBuilder.CreateTable(
                name: "ExamenGeneradoPregunta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamenGeneradoId = table.Column<int>(type: "int", nullable: false),
                    PreguntaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenGeneradoPregunta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamenGeneradoPregunta_ExamenGenerado_ExamenGeneradoId",
                        column: x => x.ExamenGeneradoId,
                        principalTable: "ExamenGenerado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamenGeneradoPregunta_PreguntaAsa_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "PreguntaAsa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamenGeneradoPregunta_ExamenGeneradoId",
                table: "ExamenGeneradoPregunta",
                column: "ExamenGeneradoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenGeneradoPregunta_PreguntaId",
                table: "ExamenGeneradoPregunta",
                column: "PreguntaId");
        }
    }
}
