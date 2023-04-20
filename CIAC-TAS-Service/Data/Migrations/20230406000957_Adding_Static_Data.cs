using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Adding_Static_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Materia",
                columns: new[] { "Id", "MateriaCodigo", "Nombre" },
                values: new object[,]
                {
                    { 1, "1.1", "Requerimientos, Leyes y Reglamentos de Aviación Civil" },
                    { 2, "2.1", "Matemáticas" },
                    { 3, "2.2", "Física" },
                    { 4, "2.3", "Química" },
                    { 5, "2.4", "Dibujo Técnico" },
                    { 6, "2.5", "Control de vuelo y aerodinámica en ala fija y helicóptero" },
                    { 7, "2.6", "Peso y balance" },
                    { 8, "2.7", "Lineas de fluidos y terminales" },
                    { 9, "3.1", "Materiales y Procesos" },
                    { 10, "3.2", "Electricidad básica" },
                    { 11, "3.3", "Soldadura" },
                    { 12, "3.4", "Corrosión" },
                    { 13, "3.5", "Operación y servicio en tierra" },
                    { 14, "3.6", "Ensayos no destructivos" },
                    { 15, "3.7", "Estructuras I" },
                    { 16, "3.8", "Sistema de tren de aterrizaje" },
                    { 17, "3.9", "Sistema hidráulico y neumático" },
                    { 18, "3.10", "Sistema de control atmosférico (cabina)" },
                    { 19, "3.11", "Sistema de combustible" },
                    { 20, "3.12", "Sistema de control de lluvia y hielo" },
                    { 21, "3.13", "Sistema de protección de fuego" },
                    { 22, "3.14", "Estructuras II" },
                    { 23, "4.1", "Motores recíprocos" },
                    { 24, "4.2", "Hélices" },
                    { 25, "4.3", "Motores a turbina" },
                    { 26, "4.4", "Sistema de combustible" },
                    { 27, "5.1", "Materiales y prácticas de mantenimiento" },
                    { 28, "5.2", "Fundamentos de Electricidad y Electrónica" },
                    { 29, "5.3", "Técnicas digitales, computadoras y dispositivos asociados" },
                    { 30, "5.4", "Sistemas eléctricos de aeronaves" },
                    { 31, "5.5", "Sistemas de instrumentos de aeronaves" },
                    { 32, "6.1", "Sistemas automáticos de control de vuelo (AFCS): Ala Fija y Rotatoria" },
                    { 33, "6.2", "Sistemas de navegación Inercial de aeronaves (INS)" },
                    { 34, "6.3", "Sistemas de radio y radio navegación de aeronaves" },
                    { 35, "7.1", "Actuación humana" },
                    { 36, "8.1", "Prácticas de habilidades de mantenimiento: Célula" },
                    { 37, "9.1", "Prácticas de habilidades de mantenimiento: Sistema Motopropulsor" },
                    { 38, "10.1", "Prácticas de habilidades de mantenimiento: Aviónica, Electricidad, instrumentos, radio y vuelo automático." },
                    { 39, "11.1", "Prácticas aplicadas a las operaciones de mantenimiento de Línea" },
                    { 40, "11.2", "Prácticas aplicadas a las operaciones de producción de Base" },
                    { 41, "12.1", "Inglés" }
                });

            migrationBuilder.InsertData(
                table: "Modulo",
                columns: new[] { "Id", "ModuloCodigo", "Nombre" },
                values: new object[] { 1, "1", "Modulo 1" });

            migrationBuilder.InsertData(
                table: "Modulo",
                columns: new[] { "Id", "ModuloCodigo", "Nombre" },
                values: new object[,]
                {
                    { 2, "2", "Modulo 2" },
                    { 3, "3", "Modulo 3" },
                    { 4, "4", "Modulo 4" },
                    { 5, "5", "Modulo 5" },
                    { 6, "6", "Modulo 6" },
                    { 7, "7", "Modulo 7" },
                    { 8, "8", "Modulo 8" },
                    { 9, "9", "Modulo 9" },
                    { 10, "10", "Modulo 10" },
                    { 11, "11", "Modulo 11" },
                    { 12, "12", "Modulo 12" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Modulo",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
