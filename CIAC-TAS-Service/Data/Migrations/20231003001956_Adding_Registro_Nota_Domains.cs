using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Adding_Registro_Nota_Domains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistroNotaHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramaId = table.Column<int>(type: "int", nullable: false),
                    GrupoId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroNotaHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroNotaHeader_Grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistroNotaHeader_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistroNotaHeader_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistroNotaHeader_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistroNotaHeader_Programa_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistroNotaEstudianteHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    RegistroNotaHeaderId = table.Column<int>(type: "int", nullable: false),
                    PorcentajeProgresoTotal = table.Column<int>(type: "int", nullable: false),
                    PorcentajeDominioTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroNotaEstudianteHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroNotaEstudianteHeader_RegistroNotaHeader_RegistroNotaHeaderId",
                        column: x => x.RegistroNotaHeaderId,
                        principalTable: "RegistroNotaHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistroNotaEstudiante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistroNotaEstudianteHeaderId = table.Column<int>(type: "int", nullable: false),
                    NotaProgreso = table.Column<double>(type: "float", nullable: false),
                    NotaDominio = table.Column<double>(type: "float", nullable: false),
                    AplicaRecuperatorio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroNotaEstudiante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroNotaEstudiante_RegistroNotaEstudianteHeader_RegistroNotaEstudianteHeaderId",
                        column: x => x.RegistroNotaEstudianteHeaderId,
                        principalTable: "RegistroNotaEstudianteHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroNotaEstudiante_RegistroNotaEstudianteHeaderId",
                table: "RegistroNotaEstudiante",
                column: "RegistroNotaEstudianteHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroNotaEstudianteHeader_RegistroNotaHeaderId",
                table: "RegistroNotaEstudianteHeader",
                column: "RegistroNotaHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroNotaHeader_GrupoId",
                table: "RegistroNotaHeader",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroNotaHeader_InstructorId",
                table: "RegistroNotaHeader",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroNotaHeader_MateriaId",
                table: "RegistroNotaHeader",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroNotaHeader_ModuloId",
                table: "RegistroNotaHeader",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroNotaHeader_ProgramaId",
                table: "RegistroNotaHeader",
                column: "ProgramaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroNotaEstudiante");

            migrationBuilder.DropTable(
                name: "RegistroNotaEstudianteHeader");

            migrationBuilder.DropTable(
                name: "RegistroNotaHeader");
        }
    }
}
