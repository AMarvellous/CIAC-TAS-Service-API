using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Modifying_Examen_Generado_Table_V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamenGenerado_ExamenGeneradoPregunta_ExamenGeneradoPreguntaId",
                table: "ExamenGenerado");

            migrationBuilder.DropIndex(
                name: "IX_ExamenGenerado_ExamenGeneradoPreguntaId",
                table: "ExamenGenerado");

            migrationBuilder.DropColumn(
                name: "ExamenGeneradoPreguntaId",
                table: "ExamenGenerado");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenGeneradoPregunta_ExamenGeneradoId",
                table: "ExamenGeneradoPregunta",
                column: "ExamenGeneradoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamenGeneradoPregunta_ExamenGenerado_ExamenGeneradoId",
                table: "ExamenGeneradoPregunta",
                column: "ExamenGeneradoId",
                principalTable: "ExamenGenerado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamenGeneradoPregunta_ExamenGenerado_ExamenGeneradoId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropIndex(
                name: "IX_ExamenGeneradoPregunta_ExamenGeneradoId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.AddColumn<int>(
                name: "ExamenGeneradoPreguntaId",
                table: "ExamenGenerado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExamenGenerado_ExamenGeneradoPreguntaId",
                table: "ExamenGenerado",
                column: "ExamenGeneradoPreguntaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamenGenerado_ExamenGeneradoPregunta_ExamenGeneradoPreguntaId",
                table: "ExamenGenerado",
                column: "ExamenGeneradoPreguntaId",
                principalTable: "ExamenGeneradoPregunta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
