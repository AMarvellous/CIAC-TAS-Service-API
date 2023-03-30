using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Update_ExamenGeneradoPregunta_Table_V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamenGeneradoPregunta_ExamenGenerado_ExamenGeneradoId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamenGeneradoPregunta_PreguntaAsa_PreguntaAsaId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropIndex(
                name: "IX_ExamenGeneradoPregunta_ExamenGeneradoId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropIndex(
                name: "IX_ExamenGeneradoPregunta_PreguntaAsaId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropColumn(
                name: "NumeroPregunta",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropColumn(
                name: "PreguntaTexto",
                table: "ExamenGeneradoPregunta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroPregunta",
                table: "ExamenGeneradoPregunta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PreguntaTexto",
                table: "ExamenGeneradoPregunta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenGeneradoPregunta_ExamenGeneradoId",
                table: "ExamenGeneradoPregunta",
                column: "ExamenGeneradoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenGeneradoPregunta_PreguntaAsaId",
                table: "ExamenGeneradoPregunta",
                column: "PreguntaAsaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamenGeneradoPregunta_ExamenGenerado_ExamenGeneradoId",
                table: "ExamenGeneradoPregunta",
                column: "ExamenGeneradoId",
                principalTable: "ExamenGenerado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamenGeneradoPregunta_PreguntaAsa_PreguntaAsaId",
                table: "ExamenGeneradoPregunta",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
