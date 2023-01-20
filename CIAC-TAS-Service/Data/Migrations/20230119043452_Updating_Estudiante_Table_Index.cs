using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Updating_Estudiante_Table_Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estudiante_UserId",
                table: "Estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_UserId",
                table: "Estudiante",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Estudiante_UserId",
                table: "Estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_UserId",
                table: "Estudiante",
                column: "UserId");
        }
    }
}
