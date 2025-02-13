using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class AddingTipoRegistroNotaEstudiante_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AplicaRecuperatorio",
                table: "RegistroNotaEstudiante");

            migrationBuilder.AddColumn<int>(
                name: "TipoRegistroNotaEstudianteId",
                table: "RegistroNotaEstudiante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoRegistroNotaEstudiante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRegistroNotaEstudiante", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TipoRegistroNotaEstudiante",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Progreso" });

            migrationBuilder.InsertData(
                table: "TipoRegistroNotaEstudiante",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "Dominio" });

            migrationBuilder.InsertData(
                table: "TipoRegistroNotaEstudiante",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 3, "Recuperatorio" });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroNotaEstudiante_TipoRegistroNotaEstudianteId",
                table: "RegistroNotaEstudiante",
                column: "TipoRegistroNotaEstudianteId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroNotaEstudiante_TipoRegistroNotaEstudiante_TipoRegistroNotaEstudianteId",
                table: "RegistroNotaEstudiante",
                column: "TipoRegistroNotaEstudianteId",
                principalTable: "TipoRegistroNotaEstudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroNotaEstudiante_TipoRegistroNotaEstudiante_TipoRegistroNotaEstudianteId",
                table: "RegistroNotaEstudiante");

            migrationBuilder.DropTable(
                name: "TipoRegistroNotaEstudiante");

            migrationBuilder.DropIndex(
                name: "IX_RegistroNotaEstudiante_TipoRegistroNotaEstudianteId",
                table: "RegistroNotaEstudiante");

            migrationBuilder.DropColumn(
                name: "TipoRegistroNotaEstudianteId",
                table: "RegistroNotaEstudiante");

            migrationBuilder.AddColumn<bool>(
                name: "AplicaRecuperatorio",
                table: "RegistroNotaEstudiante",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
