using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Adding_RespuestasAsa_Table_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RespuestasAsas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConfiguracionId = table.Column<int>(type: "int", nullable: true),
                    PreguntaAsaId = table.Column<int>(type: "int", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpcionSeleccionadaId = table.Column<int>(type: "int", nullable: true),
                    EsExamen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestasAsas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespuestasAsas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespuestasAsas_ConfiguracionPreguntaAsa_ConfiguracionId",
                        column: x => x.ConfiguracionId,
                        principalTable: "ConfiguracionPreguntaAsa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RespuestasAsas_PreguntaAsa_PreguntaAsaId",
                        column: x => x.PreguntaAsaId,
                        principalTable: "PreguntaAsa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespuestasAsas_PreguntaAsaOpcion_OpcionSeleccionadaId",
                        column: x => x.OpcionSeleccionadaId,
                        principalTable: "PreguntaAsaOpcion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RespuestasAsas_ConfiguracionId",
                table: "RespuestasAsas",
                column: "ConfiguracionId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestasAsas_OpcionSeleccionadaId",
                table: "RespuestasAsas",
                column: "OpcionSeleccionadaId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestasAsas_PreguntaAsaId",
                table: "RespuestasAsas",
                column: "PreguntaAsaId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestasAsas_UserId",
                table: "RespuestasAsas",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RespuestasAsas");
        }
    }
}
