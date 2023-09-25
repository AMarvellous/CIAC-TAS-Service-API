using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class ReAdd_on_cascade_preguntaasa_and_opcion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsa_GrupoPreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsaOpcion_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaOpcion");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsa_GrupoPreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "GrupoPreguntaAsaId",
                principalTable: "GrupoPreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsaOpcion_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaOpcion",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsa_GrupoPreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsaOpcion_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaOpcion");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsa_GrupoPreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "GrupoPreguntaAsaId",
                principalTable: "GrupoPreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsaOpcion_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaOpcion",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
