using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Adding_TipoAsistenciaEstudianteHeader_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoAsistenciaEstudianteHeaderId",
                table: "AsistenciaEstudianteHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoAsistenciaEstudianteHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoAsistenciaEstudianteHeader", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TipoAsistenciaEstudianteHeader",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Regular" });

            migrationBuilder.InsertData(
                table: "TipoAsistenciaEstudianteHeader",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "Tutorial" });

            migrationBuilder.CreateIndex(
                name: "IX_AsistenciaEstudianteHeader_TipoAsistenciaEstudianteHeaderId",
                table: "AsistenciaEstudianteHeader",
                column: "TipoAsistenciaEstudianteHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudianteHeader_TipoAsistenciaEstudianteHeader_TipoAsistenciaEstudianteHeaderId",
                table: "AsistenciaEstudianteHeader",
                column: "TipoAsistenciaEstudianteHeaderId",
                principalTable: "TipoAsistenciaEstudianteHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudianteHeader_TipoAsistenciaEstudianteHeader_TipoAsistenciaEstudianteHeaderId",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropTable(
                name: "TipoAsistenciaEstudianteHeader");

            migrationBuilder.DropIndex(
                name: "IX_AsistenciaEstudianteHeader_TipoAsistenciaEstudianteHeaderId",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropColumn(
                name: "TipoAsistenciaEstudianteHeaderId",
                table: "AsistenciaEstudianteHeader");
        }
    }
}
