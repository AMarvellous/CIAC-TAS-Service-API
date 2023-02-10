using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Added_RespuestasAsaConsolidado_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "respuestasAsaConsolidado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoteRespuestasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConfiguracionId = table.Column<int>(type: "int", nullable: true),
                    NumeroPregunta = table.Column<int>(type: "int", nullable: false),
                    PreguntaTexto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaLote = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opcion = table.Column<int>(type: "int", nullable: true),
                    RespuestaTexto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespuestaCorrecta = table.Column<int>(type: "int", nullable: false),
                    EsExamen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_respuestasAsaConsolidado", x => new { x.Id, x.LoteRespuestasId });
                    table.ForeignKey(
                        name: "FK_respuestasAsaConsolidado_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_respuestasAsaConsolidado_ConfiguracionPreguntaAsa_ConfiguracionId",
                        column: x => x.ConfiguracionId,
                        principalTable: "ConfiguracionPreguntaAsa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_respuestasAsaConsolidado_ConfiguracionId",
                table: "respuestasAsaConsolidado",
                column: "ConfiguracionId");

            migrationBuilder.CreateIndex(
                name: "IX_respuestasAsaConsolidado_UserId",
                table: "respuestasAsaConsolidado",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "respuestasAsaConsolidado");
        }
    }
}
