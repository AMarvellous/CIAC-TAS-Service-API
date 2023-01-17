using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Added_Preguntas_ASA_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoPreguntaAsa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPreguntaAsa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoPreguntaAsa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grupo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoPreguntaAsa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImagenAsa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutaImagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenAsa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreguntaAsa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroPregunta = table.Column<int>(type: "int", nullable: false),
                    Pregunta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrupoPreguntaAsaId = table.Column<int>(type: "int", nullable: false),
                    EstadoPreguntaAsaId = table.Column<int>(type: "int", nullable: false),
                    ImagenAsaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntaAsa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreguntaAsa_EstadoPreguntaAsa_EstadoPreguntaAsaId",
                        column: x => x.EstadoPreguntaAsaId,
                        principalTable: "EstadoPreguntaAsa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreguntaAsa_GrupoPreguntaAsa_GrupoPreguntaAsaId",
                        column: x => x.GrupoPreguntaAsaId,
                        principalTable: "GrupoPreguntaAsa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreguntaAsa_ImagenAsa_ImagenAsaId",
                        column: x => x.ImagenAsaId,
                        principalTable: "ImagenAsa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaAsa_EstadoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "EstadoPreguntaAsaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "GrupoPreguntaAsaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaAsa_ImagenAsaId",
                table: "PreguntaAsa",
                column: "ImagenAsaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreguntaAsa");

            migrationBuilder.DropTable(
                name: "EstadoPreguntaAsa");

            migrationBuilder.DropTable(
                name: "GrupoPreguntaAsa");

            migrationBuilder.DropTable(
                name: "ImagenAsa");
        }
    }
}
