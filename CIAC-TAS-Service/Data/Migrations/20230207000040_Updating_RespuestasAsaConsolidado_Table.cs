using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Updating_RespuestasAsaConsolidado_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_respuestasAsaConsolidado_AspNetUsers_UserId",
                table: "respuestasAsaConsolidado");

            migrationBuilder.DropForeignKey(
                name: "FK_respuestasAsaConsolidado_ConfiguracionPreguntaAsa_ConfiguracionId",
                table: "respuestasAsaConsolidado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_respuestasAsaConsolidado",
                table: "respuestasAsaConsolidado");

            migrationBuilder.RenameTable(
                name: "respuestasAsaConsolidado",
                newName: "RespuestasAsaConsolidado");

            migrationBuilder.RenameIndex(
                name: "IX_respuestasAsaConsolidado_UserId",
                table: "RespuestasAsaConsolidado",
                newName: "IX_RespuestasAsaConsolidado_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_respuestasAsaConsolidado_ConfiguracionId",
                table: "RespuestasAsaConsolidado",
                newName: "IX_RespuestasAsaConsolidado_ConfiguracionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RespuestasAsaConsolidado",
                table: "RespuestasAsaConsolidado",
                columns: new[] { "Id", "LoteRespuestasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsaConsolidado_AspNetUsers_UserId",
                table: "RespuestasAsaConsolidado",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsaConsolidado_ConfiguracionPreguntaAsa_ConfiguracionId",
                table: "RespuestasAsaConsolidado",
                column: "ConfiguracionId",
                principalTable: "ConfiguracionPreguntaAsa",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsaConsolidado_AspNetUsers_UserId",
                table: "RespuestasAsaConsolidado");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsaConsolidado_ConfiguracionPreguntaAsa_ConfiguracionId",
                table: "RespuestasAsaConsolidado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RespuestasAsaConsolidado",
                table: "RespuestasAsaConsolidado");

            migrationBuilder.RenameTable(
                name: "RespuestasAsaConsolidado",
                newName: "respuestasAsaConsolidado");

            migrationBuilder.RenameIndex(
                name: "IX_RespuestasAsaConsolidado_UserId",
                table: "respuestasAsaConsolidado",
                newName: "IX_respuestasAsaConsolidado_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RespuestasAsaConsolidado_ConfiguracionId",
                table: "respuestasAsaConsolidado",
                newName: "IX_respuestasAsaConsolidado_ConfiguracionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_respuestasAsaConsolidado",
                table: "respuestasAsaConsolidado",
                columns: new[] { "Id", "LoteRespuestasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_respuestasAsaConsolidado_AspNetUsers_UserId",
                table: "respuestasAsaConsolidado",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_respuestasAsaConsolidado_ConfiguracionPreguntaAsa_ConfiguracionId",
                table: "respuestasAsaConsolidado",
                column: "ConfiguracionId",
                principalTable: "ConfiguracionPreguntaAsa",
                principalColumn: "Id");
        }
    }
}
