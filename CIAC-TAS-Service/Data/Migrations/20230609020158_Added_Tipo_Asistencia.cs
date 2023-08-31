using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Added_Tipo_Asistencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoAsistenciaId",
                table: "AsistenciaEstudiante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoAsistencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAsistencia", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TipoAsistencia",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Presente" });

            migrationBuilder.InsertData(
                table: "TipoAsistencia",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "Justificada" });

            migrationBuilder.InsertData(
                table: "TipoAsistencia",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 3, "Injustificada" });

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaEstudiante_TipoAsistenciaId",
                table: "AsistenciaEstudiante",
                column: "TipoAsistenciaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudiante_TipoAsistencia_TipoAsistenciaId",
                table: "AsistenciaEstudiante",
                column: "TipoAsistenciaId",
                principalTable: "TipoAsistencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudiante_TipoAsistencia_TipoAsistenciaId",
                table: "AsistenciaEstudiante");

            migrationBuilder.DropTable(
                name: "TipoAsistencia");

            migrationBuilder.DropIndex(
                name: "IX_AsistenciaEstudiante_TipoAsistenciaId",
                table: "AsistenciaEstudiante");

            migrationBuilder.DropColumn(
                name: "TipoAsistenciaId",
                table: "AsistenciaEstudiante");
        }
    }
}
