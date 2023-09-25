using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Fixing_InstructorProgramaAnalitico_Links : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstructorInstructorProgramaAnalitico");

            migrationBuilder.DropTable(
                name: "InstructorProgramaAnaliticoProgramaAnaliticoPdf");

            migrationBuilder.RenameColumn(
                name: "ProgramaAnaliticoId",
                table: "InstructorProgramaAnalitico",
                newName: "ProgramaAnaliticoPdfId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorProgramaAnalitico_ProgramaAnaliticoPdfId",
                table: "InstructorProgramaAnalitico",
                column: "ProgramaAnaliticoPdfId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorProgramaAnalitico_Instructor_InstructorId",
                table: "InstructorProgramaAnalitico",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorProgramaAnalitico_ProgramaAnaliticoPdf_ProgramaAnaliticoPdfId",
                table: "InstructorProgramaAnalitico",
                column: "ProgramaAnaliticoPdfId",
                principalTable: "ProgramaAnaliticoPdf",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstructorProgramaAnalitico_Instructor_InstructorId",
                table: "InstructorProgramaAnalitico");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorProgramaAnalitico_ProgramaAnaliticoPdf_ProgramaAnaliticoPdfId",
                table: "InstructorProgramaAnalitico");

            migrationBuilder.DropIndex(
                name: "IX_InstructorProgramaAnalitico_ProgramaAnaliticoPdfId",
                table: "InstructorProgramaAnalitico");

            migrationBuilder.RenameColumn(
                name: "ProgramaAnaliticoPdfId",
                table: "InstructorProgramaAnalitico",
                newName: "ProgramaAnaliticoId");

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
    }
}
