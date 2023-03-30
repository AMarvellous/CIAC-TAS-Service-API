using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Modifying_Examen_Generado_Table_V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamenGeneradoPregunta_ExamenGenerado_ExamenGeneradoId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamenGeneradoPregunta_PreguntaAsa_PreguntaAsaId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamenGeneradoPregunta",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.AlterColumn<int>(
                name: "PreguntaAsaId",
                table: "ExamenGeneradoPregunta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ExamenGeneradoPregunta",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

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

            migrationBuilder.AddColumn<int>(
                name: "ExamenGeneradoPreguntaId",
                table: "ExamenGenerado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamenGeneradoPregunta",
                table: "ExamenGeneradoPregunta",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ExamenGeneradoPregunta_PreguntaAsa_PreguntaAsaId",
                table: "ExamenGeneradoPregunta",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamenGenerado_ExamenGeneradoPregunta_ExamenGeneradoPreguntaId",
                table: "ExamenGenerado");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamenGeneradoPregunta_PreguntaAsa_PreguntaAsaId",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamenGeneradoPregunta",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropIndex(
                name: "IX_ExamenGenerado_ExamenGeneradoPreguntaId",
                table: "ExamenGenerado");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropColumn(
                name: "NumeroPregunta",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropColumn(
                name: "PreguntaTexto",
                table: "ExamenGeneradoPregunta");

            migrationBuilder.DropColumn(
                name: "ExamenGeneradoPreguntaId",
                table: "ExamenGenerado");

            migrationBuilder.AlterColumn<int>(
                name: "PreguntaAsaId",
                table: "ExamenGeneradoPregunta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamenGeneradoPregunta",
                table: "ExamenGeneradoPregunta",
                columns: new[] { "ExamenGeneradoId", "PreguntaAsaId" });

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
