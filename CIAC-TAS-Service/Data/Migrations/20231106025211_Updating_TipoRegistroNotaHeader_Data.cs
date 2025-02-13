using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Updating_TipoRegistroNotaHeader_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TipoRegistroNotaHeader",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "Tutorial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TipoRegistroNotaHeader",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "Recuperatorio");
        }
    }
}
