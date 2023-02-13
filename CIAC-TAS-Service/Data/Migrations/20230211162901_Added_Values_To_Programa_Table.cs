using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Added_Values_To_Programa_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Programa",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "TMA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Programa",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
