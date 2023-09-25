using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Added_InstructorProgramaAnalitico_Links : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_InstructorProgramaAnalitico_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramaAnaliticoPdf_InstructorProgramaAnalitico_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoPrograma~",
                table: "ProgramaAnaliticoPdf");

            migrationBuilder.DropIndex(
                name: "IX_ProgramaAnaliticoPdf_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "ProgramaAnaliticoPdf");

            migrationBuilder.DropIndex(
                name: "IX_Instructor_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "InstructorProgramaAnaliticoInstructorId",
                table: "ProgramaAnaliticoPdf");

            migrationBuilder.DropColumn(
                name: "InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "ProgramaAnaliticoPdf");

            migrationBuilder.DropColumn(
                name: "InstructorProgramaAnaliticoInstructorId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "Instructor");

            migrationBuilder.CreateTable(
                name: "InstructorInstructorProgramaAnalitico",
                columns: table => new
                {
                    InstructoresId = table.Column<int>(type: "int", nullable: false),
                    InstructorProgramaAnaliticosInstructorId = table.Column<int>(type: "int", nullable: false),
                    InstructorProgramaAnaliticosProgramaAnaliticoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorInstructorProgramaAnalitico", x => new { x.InstructoresId, x.InstructorProgramaAnaliticosInstructorId, x.InstructorProgramaAnaliticosProgramaAnaliticoId });
                    table.ForeignKey(
                        name: "FK_InstructorInstructorProgramaAnalitico_Instructor_InstructoresId",
                        column: x => x.InstructoresId,
                        principalTable: "Instructor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorInstructorProgramaAnalitico_InstructorProgramaAnalitico_InstructorProgramaAnaliticosInstructorId_InstructorProgram~",
                        columns: x => new { x.InstructorProgramaAnaliticosInstructorId, x.InstructorProgramaAnaliticosProgramaAnaliticoId },
                        principalTable: "InstructorProgramaAnalitico",
                        principalColumns: new[] { "InstructorId", "ProgramaAnaliticoId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorProgramaAnaliticoProgramaAnaliticoPdf",
                columns: table => new
                {
                    ProgramaAnaliticoPdfsId = table.Column<int>(type: "int", nullable: false),
                    InstructorProgramaAnaliticosInstructorId = table.Column<int>(type: "int", nullable: false),
                    InstructorProgramaAnaliticosProgramaAnaliticoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorProgramaAnaliticoProgramaAnaliticoPdf", x => new { x.ProgramaAnaliticoPdfsId, x.InstructorProgramaAnaliticosInstructorId, x.InstructorProgramaAnaliticosProgramaAnaliticoId });
                    table.ForeignKey(
                        name: "FK_InstructorProgramaAnaliticoProgramaAnaliticoPdf_InstructorProgramaAnalitico_InstructorProgramaAnaliticosInstructorId_Instruc~",
                        columns: x => new { x.InstructorProgramaAnaliticosInstructorId, x.InstructorProgramaAnaliticosProgramaAnaliticoId },
                        principalTable: "InstructorProgramaAnalitico",
                        principalColumns: new[] { "InstructorId", "ProgramaAnaliticoId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorProgramaAnaliticoProgramaAnaliticoPdf_ProgramaAnaliticoPdf_ProgramaAnaliticoPdfsId",
                        column: x => x.ProgramaAnaliticoPdfsId,
                        principalTable: "ProgramaAnaliticoPdf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorInstructorProgramaAnalitico_InstructorProgramaAnaliticosInstructorId_InstructorProgramaAnaliticosProgramaAnalitico~",
                table: "InstructorInstructorProgramaAnalitico",
                columns: new[] { "InstructorProgramaAnaliticosInstructorId", "InstructorProgramaAnaliticosProgramaAnaliticoId" });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorProgramaAnaliticoProgramaAnaliticoPdf_InstructorProgramaAnaliticosInstructorId_InstructorProgramaAnaliticosProgram~",
                table: "InstructorProgramaAnaliticoProgramaAnaliticoPdf",
                columns: new[] { "InstructorProgramaAnaliticosInstructorId", "InstructorProgramaAnaliticosProgramaAnaliticoId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorInstructorProgramaAnalitico");

            migrationBuilder.DropTable(
                name: "InstructorProgramaAnaliticoProgramaAnaliticoPdf");

            migrationBuilder.AddColumn<int>(
                name: "InstructorProgramaAnaliticoInstructorId",
                table: "ProgramaAnaliticoPdf",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "ProgramaAnaliticoPdf",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ProgramaAnaliticoPdf_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "ProgramaAnaliticoPdf",
                columns: new[] { "InstructorProgramaAnaliticoInstructorId", "InstructorProgramaAnaliticoProgramaAnaliticoId" });

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "Instructor",
                columns: new[] { "InstructorProgramaAnaliticoInstructorId", "InstructorProgramaAnaliticoProgramaAnaliticoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_InstructorProgramaAnalitico_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoProgramaAnaliticoId",
                table: "Instructor",
                columns: new[] { "InstructorProgramaAnaliticoInstructorId", "InstructorProgramaAnaliticoProgramaAnaliticoId" },
                principalTable: "InstructorProgramaAnalitico",
                principalColumns: new[] { "InstructorId", "ProgramaAnaliticoId" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramaAnaliticoPdf_InstructorProgramaAnalitico_InstructorProgramaAnaliticoInstructorId_InstructorProgramaAnaliticoPrograma~",
                table: "ProgramaAnaliticoPdf",
                columns: new[] { "InstructorProgramaAnaliticoInstructorId", "InstructorProgramaAnaliticoProgramaAnaliticoId" },
                principalTable: "InstructorProgramaAnalitico",
                principalColumns: new[] { "InstructorId", "ProgramaAnaliticoId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
