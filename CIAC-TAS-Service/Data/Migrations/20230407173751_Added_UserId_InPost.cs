using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Added_UserId_InPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ModuloMateria",
                columns: new[] { "MateriaId", "ModuloId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 3 },
                    { 10, 3 },
                    { 11, 3 },
                    { 12, 3 },
                    { 13, 3 },
                    { 14, 3 },
                    { 15, 3 },
                    { 16, 3 },
                    { 17, 3 },
                    { 18, 3 },
                    { 19, 3 },
                    { 20, 3 },
                    { 21, 3 },
                    { 22, 3 },
                    { 23, 4 },
                    { 24, 4 },
                    { 25, 4 },
                    { 26, 4 },
                    { 27, 5 },
                    { 28, 5 },
                    { 29, 5 },
                    { 30, 5 },
                    { 31, 5 },
                    { 32, 6 },
                    { 33, 6 },
                    { 34, 6 },
                    { 35, 7 },
                    { 36, 8 },
                    { 37, 9 },
                    { 38, 10 },
                    { 39, 11 },
                    { 40, 11 },
                    { 41, 12 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 17, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 18, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 19, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 20, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 21, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 22, 3 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 23, 4 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 24, 4 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 25, 4 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 26, 4 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 27, 5 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 28, 5 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 29, 5 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 30, 5 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 31, 5 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 32, 6 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 33, 6 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 34, 6 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 35, 7 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 36, 8 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 37, 9 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 38, 10 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 39, 11 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 40, 11 });

            migrationBuilder.DeleteData(
                table: "ModuloMateria",
                keyColumns: new[] { "MateriaId", "ModuloId" },
                keyValues: new object[] { 41, 12 });
        }
    }
}
