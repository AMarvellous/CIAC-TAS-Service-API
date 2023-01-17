using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Adding_Estudiante_Details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsa_ImagenAsa_ImagenAsaId",
                table: "PreguntaAsa");

            migrationBuilder.DropIndex(
                name: "IX_PreguntaAsa_ImagenAsaId",
                table: "PreguntaAsa");

            migrationBuilder.DropColumn(
                name: "ImagenAsaId",
                table: "PreguntaAsa");

            migrationBuilder.RenameColumn(
                name: "RutaImagen",
                table: "ImagenAsa",
                newName: "Ruta");

            migrationBuilder.AddColumn<string>(
                name: "CarnetIdentidad",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CelularMadre",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CelularPadre",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CelularTutor",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoSeguro",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoTas",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Domicilio",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EstadoCivil",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ExamenPsicofisiologico",
                table: "Estudiante",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ExperienciaPrevia",
                table: "Estudiante",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FamiliarTutor",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Estudiante",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Estudiante",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSeguro",
                table: "Estudiante",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "InstruccionPrevia",
                table: "Estudiante",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LugarNacimiento",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidad",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreMadre",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombrePadre",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreTutor",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Estudiante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "VacunaAntitetanica",
                table: "Estudiante",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PreguntaAsaImagenAsa",
                columns: table => new
                {
                    PreguntaAsaId = table.Column<int>(type: "int", nullable: false),
                    ImagenAsaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntaAsaImagenAsa", x => new { x.PreguntaAsaId, x.ImagenAsaId });
                    table.ForeignKey(
                        name: "FK_PreguntaAsaImagenAsa_ImagenAsa_ImagenAsaId",
                        column: x => x.ImagenAsaId,
                        principalTable: "ImagenAsa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreguntaAsaImagenAsa_PreguntaAsa_PreguntaAsaId",
                        column: x => x.PreguntaAsaId,
                        principalTable: "PreguntaAsa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Programa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstudiantePrograma",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    ProgramaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiantePrograma", x => new { x.EstudianteId, x.ProgramaId });
                    table.ForeignKey(
                        name: "FK_EstudiantePrograma_Estudiante_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudiantePrograma_Programa_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantePrograma_ProgramaId",
                table: "EstudiantePrograma",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaAsaImagenAsa_ImagenAsaId",
                table: "PreguntaAsaImagenAsa",
                column: "ImagenAsaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudiantePrograma");

            migrationBuilder.DropTable(
                name: "PreguntaAsaImagenAsa");

            migrationBuilder.DropTable(
                name: "Programa");

            migrationBuilder.DropColumn(
                name: "CarnetIdentidad",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "CelularMadre",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "CelularPadre",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "CelularTutor",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "CodigoSeguro",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "CodigoTas",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "Domicilio",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "EstadoCivil",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "ExamenPsicofisiologico",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "ExperienciaPrevia",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "FamiliarTutor",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "FechaSeguro",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "InstruccionPrevia",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "LugarNacimiento",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "Nacionalidad",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "NombreMadre",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "NombrePadre",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "NombreTutor",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "VacunaAntitetanica",
                table: "Estudiante");

            migrationBuilder.RenameColumn(
                name: "Ruta",
                table: "ImagenAsa",
                newName: "RutaImagen");

            migrationBuilder.AddColumn<int>(
                name: "ImagenAsaId",
                table: "PreguntaAsa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreguntaAsa_ImagenAsaId",
                table: "PreguntaAsa",
                column: "ImagenAsaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsa_ImagenAsa_ImagenAsaId",
                table: "PreguntaAsa",
                column: "ImagenAsaId",
                principalTable: "ImagenAsa",
                principalColumn: "Id");
        }
    }
}
