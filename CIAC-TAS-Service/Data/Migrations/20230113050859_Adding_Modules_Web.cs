using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Adding_Modules_Web : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuModulosWeb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estilo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuModulosWeb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuModulosWeb_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuSubModulosWeb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pagina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estilo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSubModulosWeb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuSubModulosWeb_MenuModulosWeb_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "MenuModulosWeb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuModulosWeb_RoleId",
                table: "MenuModulosWeb",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSubModulosWeb_ModuloId",
                table: "MenuSubModulosWeb",
                column: "ModuloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuSubModulosWeb");

            migrationBuilder.DropTable(
                name: "MenuModulosWeb");
        }
    }
}
