using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Added_UserId_To_Estudiante_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Estudiante",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_UserId",
                table: "Estudiante",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_AspNetUsers_UserId",
                table: "Estudiante",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_AspNetUsers_UserId",
                table: "Estudiante");

            migrationBuilder.DropIndex(
                name: "IX_Estudiante_UserId",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Estudiante");
        }
    }
}
