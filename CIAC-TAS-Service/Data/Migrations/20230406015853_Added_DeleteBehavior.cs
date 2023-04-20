using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CIACTASService.Data.Migrations
{
    public partial class Added_DeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrativo_AspNetUsers_UserId",
                table: "Administrativo");

            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Grupo_GrupoId",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Instructor_InstructorId",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Materia_MateriaId",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Modulo_ModuloId",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Programa_ProgramaId",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracionPreguntaAsa_Grupo_GrupoId",
                table: "ConfiguracionPreguntaAsa");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_AspNetUsers_UserId",
                table: "Estudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudianteGrupo_Estudiante_EstudianteId",
                table: "EstudianteGrupo");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudianteGrupo_Grupo_GrupoId",
                table: "EstudianteGrupo");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantePrograma_Estudiante_EstudianteId",
                table: "EstudiantePrograma");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantePrograma_Programa_ProgramaId",
                table: "EstudiantePrograma");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamenGenerado_Grupo_GrupoId",
                table: "ExamenGenerado");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_AspNetUsers_UserId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuModulosWeb_AspNetRoles_RoleId",
                table: "MenuModulosWeb");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuSubModulosWeb_MenuModulosWeb_ModuloId",
                table: "MenuSubModulosWeb");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuloMateria_Materia_MateriaId",
                table: "ModuloMateria");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuloMateria_Modulo_ModuloId",
                table: "ModuloMateria");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsa_EstadoPreguntaAsa_EstadoPreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsa_GrupoPreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsaImagenAsa_ImagenAsa_ImagenAsaId",
                table: "PreguntaAsaImagenAsa");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsaImagenAsa_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaImagenAsa");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsaOpcion_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaOpcion");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsaConsolidado_AspNetUsers_UserId",
                table: "RespuestasAsaConsolidado");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsaConsolidado_ConfiguracionPreguntaAsa_ConfiguracionId",
                table: "RespuestasAsaConsolidado");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsas_AspNetUsers_UserId",
                table: "RespuestasAsas");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsas_ConfiguracionPreguntaAsa_ConfiguracionId",
                table: "RespuestasAsas");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsas_PreguntaAsa_PreguntaAsaId",
                table: "RespuestasAsas");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsas_PreguntaAsaOpcion_OpcionSeleccionadaId",
                table: "RespuestasAsas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrativo_AspNetUsers_UserId",
                table: "Administrativo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Grupo_GrupoId",
                table: "AsistenciaEstudianteHeader",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Instructor_InstructorId",
                table: "AsistenciaEstudianteHeader",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Materia_MateriaId",
                table: "AsistenciaEstudianteHeader",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Modulo_ModuloId",
                table: "AsistenciaEstudianteHeader",
                column: "ModuloId",
                principalTable: "Modulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Programa_ProgramaId",
                table: "AsistenciaEstudianteHeader",
                column: "ProgramaId",
                principalTable: "Programa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracionPreguntaAsa_Grupo_GrupoId",
                table: "ConfiguracionPreguntaAsa",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_AspNetUsers_UserId",
                table: "Estudiante",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudianteGrupo_Estudiante_EstudianteId",
                table: "EstudianteGrupo",
                column: "EstudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudianteGrupo_Grupo_GrupoId",
                table: "EstudianteGrupo",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantePrograma_Estudiante_EstudianteId",
                table: "EstudiantePrograma",
                column: "EstudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantePrograma_Programa_ProgramaId",
                table: "EstudiantePrograma",
                column: "ProgramaId",
                principalTable: "Programa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamenGenerado_Grupo_GrupoId",
                table: "ExamenGenerado",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_AspNetUsers_UserId",
                table: "Instructor",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModulosWeb_AspNetRoles_RoleId",
                table: "MenuModulosWeb",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuSubModulosWeb_MenuModulosWeb_ModuloId",
                table: "MenuSubModulosWeb",
                column: "ModuloId",
                principalTable: "MenuModulosWeb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuloMateria_Materia_MateriaId",
                table: "ModuloMateria",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuloMateria_Modulo_ModuloId",
                table: "ModuloMateria",
                column: "ModuloId",
                principalTable: "Modulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsa_EstadoPreguntaAsa_EstadoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "EstadoPreguntaAsaId",
                principalTable: "EstadoPreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsa_GrupoPreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "GrupoPreguntaAsaId",
                principalTable: "GrupoPreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsaImagenAsa_ImagenAsa_ImagenAsaId",
                table: "PreguntaAsaImagenAsa",
                column: "ImagenAsaId",
                principalTable: "ImagenAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsaImagenAsa_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaImagenAsa",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsaOpcion_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaOpcion",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsaConsolidado_AspNetUsers_UserId",
                table: "RespuestasAsaConsolidado",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsaConsolidado_ConfiguracionPreguntaAsa_ConfiguracionId",
                table: "RespuestasAsaConsolidado",
                column: "ConfiguracionId",
                principalTable: "ConfiguracionPreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsas_AspNetUsers_UserId",
                table: "RespuestasAsas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsas_ConfiguracionPreguntaAsa_ConfiguracionId",
                table: "RespuestasAsas",
                column: "ConfiguracionId",
                principalTable: "ConfiguracionPreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsas_PreguntaAsa_PreguntaAsaId",
                table: "RespuestasAsas",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsas_PreguntaAsaOpcion_OpcionSeleccionadaId",
                table: "RespuestasAsas",
                column: "OpcionSeleccionadaId",
                principalTable: "PreguntaAsaOpcion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrativo_AspNetUsers_UserId",
                table: "Administrativo");

            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Grupo_GrupoId",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Instructor_InstructorId",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Materia_MateriaId",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Modulo_ModuloId",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Programa_ProgramaId",
                table: "AsistenciaEstudianteHeader");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfiguracionPreguntaAsa_Grupo_GrupoId",
                table: "ConfiguracionPreguntaAsa");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_AspNetUsers_UserId",
                table: "Estudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudianteGrupo_Estudiante_EstudianteId",
                table: "EstudianteGrupo");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudianteGrupo_Grupo_GrupoId",
                table: "EstudianteGrupo");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantePrograma_Estudiante_EstudianteId",
                table: "EstudiantePrograma");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantePrograma_Programa_ProgramaId",
                table: "EstudiantePrograma");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamenGenerado_Grupo_GrupoId",
                table: "ExamenGenerado");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_AspNetUsers_UserId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuModulosWeb_AspNetRoles_RoleId",
                table: "MenuModulosWeb");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuSubModulosWeb_MenuModulosWeb_ModuloId",
                table: "MenuSubModulosWeb");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuloMateria_Materia_MateriaId",
                table: "ModuloMateria");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuloMateria_Modulo_ModuloId",
                table: "ModuloMateria");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsa_EstadoPreguntaAsa_EstadoPreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsa_GrupoPreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsaImagenAsa_ImagenAsa_ImagenAsaId",
                table: "PreguntaAsaImagenAsa");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsaImagenAsa_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaImagenAsa");

            migrationBuilder.DropForeignKey(
                name: "FK_PreguntaAsaOpcion_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaOpcion");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsaConsolidado_AspNetUsers_UserId",
                table: "RespuestasAsaConsolidado");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsaConsolidado_ConfiguracionPreguntaAsa_ConfiguracionId",
                table: "RespuestasAsaConsolidado");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsas_AspNetUsers_UserId",
                table: "RespuestasAsas");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsas_ConfiguracionPreguntaAsa_ConfiguracionId",
                table: "RespuestasAsas");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsas_PreguntaAsa_PreguntaAsaId",
                table: "RespuestasAsas");

            migrationBuilder.DropForeignKey(
                name: "FK_RespuestasAsas_PreguntaAsaOpcion_OpcionSeleccionadaId",
                table: "RespuestasAsas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrativo_AspNetUsers_UserId",
                table: "Administrativo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Grupo_GrupoId",
                table: "AsistenciaEstudianteHeader",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Instructor_InstructorId",
                table: "AsistenciaEstudianteHeader",
                column: "InstructorId",
                principalTable: "Instructor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Materia_MateriaId",
                table: "AsistenciaEstudianteHeader",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Modulo_ModuloId",
                table: "AsistenciaEstudianteHeader",
                column: "ModuloId",
                principalTable: "Modulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AsistenciaEstudianteHeader_Programa_ProgramaId",
                table: "AsistenciaEstudianteHeader",
                column: "ProgramaId",
                principalTable: "Programa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfiguracionPreguntaAsa_Grupo_GrupoId",
                table: "ConfiguracionPreguntaAsa",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_AspNetUsers_UserId",
                table: "Estudiante",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudianteGrupo_Estudiante_EstudianteId",
                table: "EstudianteGrupo",
                column: "EstudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudianteGrupo_Grupo_GrupoId",
                table: "EstudianteGrupo",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantePrograma_Estudiante_EstudianteId",
                table: "EstudiantePrograma",
                column: "EstudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantePrograma_Programa_ProgramaId",
                table: "EstudiantePrograma",
                column: "ProgramaId",
                principalTable: "Programa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamenGenerado_Grupo_GrupoId",
                table: "ExamenGenerado",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_AspNetUsers_UserId",
                table: "Instructor",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuModulosWeb_AspNetRoles_RoleId",
                table: "MenuModulosWeb",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuSubModulosWeb_MenuModulosWeb_ModuloId",
                table: "MenuSubModulosWeb",
                column: "ModuloId",
                principalTable: "MenuModulosWeb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuloMateria_Materia_MateriaId",
                table: "ModuloMateria",
                column: "MateriaId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuloMateria_Modulo_ModuloId",
                table: "ModuloMateria",
                column: "ModuloId",
                principalTable: "Modulo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsa_EstadoPreguntaAsa_EstadoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "EstadoPreguntaAsaId",
                principalTable: "EstadoPreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsa_GrupoPreguntaAsa_GrupoPreguntaAsaId",
                table: "PreguntaAsa",
                column: "GrupoPreguntaAsaId",
                principalTable: "GrupoPreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsaImagenAsa_ImagenAsa_ImagenAsaId",
                table: "PreguntaAsaImagenAsa",
                column: "ImagenAsaId",
                principalTable: "ImagenAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsaImagenAsa_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaImagenAsa",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PreguntaAsaOpcion_PreguntaAsa_PreguntaAsaId",
                table: "PreguntaAsaOpcion",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_AspNetUsers_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsaConsolidado_AspNetUsers_UserId",
                table: "RespuestasAsaConsolidado",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsaConsolidado_ConfiguracionPreguntaAsa_ConfiguracionId",
                table: "RespuestasAsaConsolidado",
                column: "ConfiguracionId",
                principalTable: "ConfiguracionPreguntaAsa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsas_AspNetUsers_UserId",
                table: "RespuestasAsas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsas_ConfiguracionPreguntaAsa_ConfiguracionId",
                table: "RespuestasAsas",
                column: "ConfiguracionId",
                principalTable: "ConfiguracionPreguntaAsa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsas_PreguntaAsa_PreguntaAsaId",
                table: "RespuestasAsas",
                column: "PreguntaAsaId",
                principalTable: "PreguntaAsa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RespuestasAsas_PreguntaAsaOpcion_OpcionSeleccionadaId",
                table: "RespuestasAsas",
                column: "OpcionSeleccionadaId",
                principalTable: "PreguntaAsaOpcion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Posts_PostId",
                table: "Tags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
