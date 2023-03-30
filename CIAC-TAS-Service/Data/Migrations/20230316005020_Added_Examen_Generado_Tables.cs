using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Added_Examen_Generado_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamenGenerado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreguntaAsaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenGenerado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamenGenerado_Grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamenGenerado_PreguntaAsa_PreguntaAsaId",
                        column: x => x.PreguntaAsaId,
                        principalTable: "PreguntaAsa",
                        principalColumn: "Id");
                });

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
                name: "IX_ExamenGenerado_GrupoId",
                table: "ExamenGenerado",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenGenerado_PreguntaAsaId",
                table: "ExamenGenerado",
                column: "PreguntaAsaId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenGeneradoPregunta_ExamenGeneradoId",
                table: "ExamenGeneradoPregunta",
                column: "ExamenGeneradoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamenGeneradoPregunta_PreguntaId",
                table: "ExamenGeneradoPregunta",
                column: "PreguntaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamenGeneradoPregunta");

            migrationBuilder.DropTable(
                name: "ExamenGenerado");
        }
    }
}
