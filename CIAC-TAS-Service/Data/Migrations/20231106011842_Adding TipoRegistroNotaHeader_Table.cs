using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class AddingTipoRegistroNotaHeader_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoRegistroNotaHeaderId",
                table: "RegistroNotaHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoRegistroNotaHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRegistroNotaHeader", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TipoRegistroNotaHeader",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Regular" });

            migrationBuilder.InsertData(
                table: "TipoRegistroNotaHeader",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "Recuperatorio" });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroNotaHeader_TipoRegistroNotaHeaderId",
                table: "RegistroNotaHeader",
                column: "TipoRegistroNotaHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroNotaHeader_TipoRegistroNotaHeader_TipoRegistroNotaHeaderId",
                table: "RegistroNotaHeader",
                column: "TipoRegistroNotaHeaderId",
                principalTable: "TipoRegistroNotaHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroNotaHeader_TipoRegistroNotaHeader_TipoRegistroNotaHeaderId",
                table: "RegistroNotaHeader");

            migrationBuilder.DropTable(
                name: "TipoRegistroNotaHeader");

            migrationBuilder.DropIndex(
                name: "IX_RegistroNotaHeader_TipoRegistroNotaHeaderId",
                table: "RegistroNotaHeader");

            migrationBuilder.DropColumn(
                name: "TipoRegistroNotaHeaderId",
                table: "RegistroNotaHeader");
        }
    }
}
