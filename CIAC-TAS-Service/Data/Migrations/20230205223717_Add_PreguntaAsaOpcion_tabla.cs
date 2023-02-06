using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Add_PreguntaAsaOpcion_tabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ruta",
                table: "PreguntaAsa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PreguntaAsaOpcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opcion = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RespuestaValida = table.Column<bool>(type: "bit", nullable: false),
                    PreguntaAsaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntaAsaOpcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreguntaAsaOpcion_PreguntaAsa_PreguntaAsaId",
                        column: x => x.PreguntaAsaId,
                        principalTable: "PreguntaAsa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaAsaOpcion_PreguntaAsaId",
                table: "PreguntaAsaOpcion",
                column: "PreguntaAsaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreguntaAsaOpcion");

            migrationBuilder.DropColumn(
                name: "Ruta",
                table: "PreguntaAsa");
        }
    }
}
