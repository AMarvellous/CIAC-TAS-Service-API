using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Modifying_Examen_Generado_Table_V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamenGeneradoPregunta",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropIndex(
                name: "IX_ExamenGeneradoPregunta_ExamenGeneradoId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamenGeneradoPregunta",
                table: "ExamenGeneradoPregunta",
                columns: new[] { "ExamenGeneradoId", "PreguntaAsaId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamenGeneradoPregunta",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ExamenGeneradoPregunta",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamenGeneradoPregunta",
                table: "ExamenGeneradoPregunta",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenGeneradoPregunta_ExamenGeneradoId",
                table: "ExamenGeneradoPregunta",
                column: "ExamenGeneradoId");
        }
    }
}
