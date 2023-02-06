using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Add_HasData_For_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EstadoPreguntaAsa",
                columns: new[] { "Id", "Estado" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 2, "I" }
                });

            migrationBuilder.InsertData(
                table: "GrupoPreguntaAsa",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "AIRFRAME" },
                    { 2, "GENERAL" },
                    { 3, "POWERPLANT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EstadoPreguntaAsa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EstadoPreguntaAsa",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GrupoPreguntaAsa",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GrupoPreguntaAsa",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GrupoPreguntaAsa",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
