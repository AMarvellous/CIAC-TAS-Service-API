using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Added_ProgramaAnalitico_And_InstrMateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructorProgramaAnaliticoInstructorId",
                table: "Instructor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "Instructor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InstructorMateria",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    GrupoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorMateria", x => new { x.InstructorId, x.GrupoId, x.MateriaId });
                    table.ForeignKey(
                        name: "FK_InstructorMateria_Grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorMateria_Instructor_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorMateria_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorProgramaAnalitico",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false),
                    ProgramaAnaliticoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorProgramaAnalitico", x => new { x.InstructorId, x.ProgramaAnaliticoId });
                });

            migrationBuilder.CreateTable(
                name: "ProgramaAnaliticoPdf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutaPdf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false),
                    Gestion = table.Column<int>(type: "int", nullable: false),
                    InstructorProgramaAnaliticoInstructorId = table.Column<int>(type: "int", nullable: true),
                    InstructorProgramaAnaliticoProgramaAnaliticoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramaAnaliticoPdf", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramaAnaliticoPdf_InstructorProgramaAnalitico_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoPrograma~",
                        columns: x => new { x.InstructorProgramaAnaliticoInstructorId, x.InstructorProgramaAnaliticoProgramaAnaliticoId },
                        principalTable: "InstructorProgramaAnalitico",
                        principalColumns: new[] { "InstructorId", "ProgramaAnaliticoId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProgramaAnaliticoPdf_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "Instructor",
                columns: new[] { "InstructorProgramaAnaliticoInstructorId", "InstructorProgramaAnaliticoProgramaAnaliticoId" });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorMateria_GrupoId",
                table: "InstructorMateria",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorMateria_MateriaId",
                table: "InstructorMateria",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaAnaliticoPdf_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "ProgramaAnaliticoPdf",
                columns: new[] { "InstructorProgramaAnaliticoInstructorId", "InstructorProgramaAnaliticoProgramaAnaliticoId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaAnaliticoPdf_MateriaId",
                table: "ProgramaAnaliticoPdf",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_InstructorProgramaAnalitico_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "Instructor",
                columns: new[] { "InstructorProgramaAnaliticoInstructorId", "InstructorProgramaAnaliticoProgramaAnaliticoId" },
                principalTable: "InstructorProgramaAnalitico",
                principalColumns: new[] { "InstructorId", "ProgramaAnaliticoId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_InstructorProgramaAnalitico_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "Instructor");

            migrationBuilder.DropTable(
                name: "InstructorMateria");

            migrationBuilder.DropTable(
                name: "ProgramaAnaliticoPdf");

            migrationBuilder.DropTable(
                name: "InstructorProgramaAnalitico");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "InstructorProgramaAnaliticoInstructorId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "Instructor");
        }
    }
}
