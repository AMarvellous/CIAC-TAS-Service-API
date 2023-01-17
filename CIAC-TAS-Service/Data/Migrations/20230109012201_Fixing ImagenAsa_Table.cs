using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class FixingImagenAsa_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsa_ImagenAsa_ImagenAsaId",
                table: "PreguntaAsa");

            migrationBuilder.AlterColumn<int>(
                name: "ImagenAsaId",
                table: "PreguntaAsa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsa_ImagenAsa_ImagenAsaId",
                table: "PreguntaAsa",
                column: "ImagenAsaId",
                principalTable: "ImagenAsa",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsa_ImagenAsa_ImagenAsaId",
                table: "PreguntaAsa");

            migrationBuilder.AlterColumn<int>(
                name: "ImagenAsaId",
                table: "PreguntaAsa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsa_ImagenAsa_ImagenAsaId",
                table: "PreguntaAsa",
                column: "ImagenAsaId",
                principalTable: "ImagenAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
