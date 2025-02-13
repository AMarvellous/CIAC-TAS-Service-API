namespace CIAC_TAS_Service.Contracts.V1
{
    public static class ApiRoute
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = $"{Root}/{Version}";
        public static class Posts
        {
            public const string GetAll = $"{Base}/posts";
            public const string Get = Base + "/posts/{postId}";
            public const string Create = $"{Base}/posts";
            public const string Update = Base + "/posts/{postId}";
            public const string Delete = Base + "/posts/{postId}";
        }

        public static class Identity
        {
            public const string Login = $"{Base}/identity/login";
            public const string Register = $"{Base}/identity/register";
            public const string Refresh = $"{Base}/identity/refresh";
            public const string GetRolesNames = Base + "/identity/roles/names";
            public const string GetRolesUserName = Base + "/identity/roles/{userName}";
            public const string GetUsers = Base + "/identity/users/";
			public const string GetUsersByRoleName = Base + "/identity/users/roleName/{roleName}";
			public const string GetUserByName = Base + "/identity/users/{userName}";
            public const string GetAsignToRole = Base + "/identity/user/role";
            public const string PatchUserPassword = Base + "/identity/password/user/{userName}";
            public const string PatchUserPasswordUserOwns = Base + "/identity/password/userOwns/user/{userName}";
        }

        public static class Tags
        {
            public const string GetAll = $"{Base}/tags";
        }

        public static class Grupos
        {
            public const string GetAll = $"{Base}/grupos";
            public const string Get = Base + "/grupos/{grupoId}";
            public const string Create = $"{Base}/grupos";
            public const string Update = Base + "/grupos/{grupoId}";
            public const string Delete = Base + "/grupos/{grupoId}";
			public const string GetAllNotAssignedEstudents = $"{Base}/grupos/NoAssigned/Estudents";
            public const string GetAllGruposAssignedByInstructor = Base + "/instructorMateria/assigned/grupos/{instructorId}";
        }

        public static class GrupoPreguntaAsas
        {
            public const string GetAll = $"{Base}/grupoPreguntaAsas";
            public const string Get = Base + "/grupoPreguntaAsas/{grupoPreguntaAsaId}";
            public const string Create = $"{Base}/grupoPreguntaAsas";
            public const string Update = Base + "/grupoPreguntaAsas/{grupoPreguntaAsaId}";
            public const string Delete = Base + "/grupoPreguntaAsas/{grupoPreguntaAsaId}";
        }

        public static class Programas
        {
            public const string GetAll = $"{Base}/programas";
            public const string Get = Base + "/programas/{programaId}";
            public const string Create = $"{Base}/programas";
            public const string Update = Base + "/programas/{programaId}";
            public const string Delete = Base + "/programas/{programaId}";
        }

        public static class ImagenAsas
        {
            public const string GetAll = $"{Base}/imagenAsas";
            public const string Get = Base + "/imagenAsas/{imagenAsaId}";
            public const string Create = $"{Base}/imagenAsas";
            public const string Update = Base + "/imagenAsas/{imagenAsaId}";
            public const string Delete = Base + "/imagenAsas/{imagenAsaId}";
        }

        public static class EstadoPreguntaAsas
        {
            public const string GetAll = $"{Base}/estadoPreguntaAsas";
            public const string Get = Base + "/estadoPreguntaAsas/{estadoPreguntaAsaId}";
            public const string Create = $"{Base}/estadoPreguntaAsas";
            public const string Update = Base + "/estadoPreguntaAsas/{estadoPreguntaAsaId}";
            public const string Delete = Base + "/estadoPreguntaAsas/{estadoPreguntaAsaId}";
        }

        public static class ConfiguracionPreguntaAsas
        {
            public const string GetAll = $"{Base}/configuracionPreguntaAsas";
            public const string Get = Base + "/configuracionPreguntaAsas/{configuracionPreguntaAsaId}";
            public const string Create = $"{Base}/configuracionPreguntaAsas";
            public const string Update = Base + "/configuracionPreguntaAsas/{configuracionPreguntaAsaId}";
            public const string Delete = Base + "/configuracionPreguntaAsas/{configuracionPreguntaAsaId}";
        }

        public static class Estudiantes
        {
            public const string GetAll = $"{Base}/estudiantes";
            public const string Get = Base + "/estudiantes/{estudianteId}";
            public const string Create = $"{Base}/estudiantes";
            public const string Update = Base + "/estudiantes/{estudianteId}";
            public const string Delete = Base + "/estudiantes/{estudianteId}";
            public const string GetByUserId = Base + "/estudiantes/userId/{userId}";
            public const string GetAllNotAssignedToGrupo = Base + "/estudiantes/noAssigned/grupo/{grupoId}";
            public const string GetAllNotAssignedAsistenciaEstudiante = Base + "/estudiantes/noAssigned/estudianteMateria/{materiaId}/{grupoId}/{asistenciaEstudianteHeaderId}";
            public const string GetAllNotAssignedToRegistroNotaEstudianteHeader = Base + "/estudiantes/noAssigned/registroNotaEstudianteHeader/registroNotaHeader/{registroNotaHeaderId}";
            public const string GetAllNotAssignedInhabilitacionEstudiante = Base + "/estudiantes/noAssigned/inhabilitacion";
        }

        public static class EstudianteGrupos
        {
            public const string GetAll = $"{Base}/estudianteGrupos";
            public const string Get = Base + "/estudianteGrupos/{estudianteId}/{grupoId}";
            public const string Create = $"{Base}/estudianteGrupos";
            public const string Delete = Base + "/estudianteGrupos/{estudianteId}/{grupoId}";
            public const string GetHeaders = $"{Base}/estudianteGrupos/grupo/headers";
            public const string CreateBatch = $"{Base}/estudianteGrupos/batch";
            public const string GetAllByGrupoId = Base + "/estudianteGrupos/grupo/{grupoId}";
        }

        public static class EstudianteProgramas
        {
            public const string GetAll = $"{Base}/estudianteProgramas";
            public const string Get = Base + "/estudianteProgramas/{estudianteId}/{programaId}";
            public const string Create = $"{Base}/estudianteProgramas";
            public const string Delete = Base + "/estudianteProgramas/{estudianteId}/{programaId}";
        }

        public static class MenuModulosWebs
        {
            public const string GetAll = $"{Base}/menuModulosWebs";
            public const string Get = Base + "/menuModulosWebs/{menuModulosWebId}";
            public const string Create = $"{Base}/menuModulosWebs";
            public const string Update = Base + "/menuModulosWebs/{menuModulosWebId}";
            public const string Delete = Base + "/menuModulosWebs/{menuModulosWebId}";
            public const string GetByRoleName = Base + "/ menuModulosWebs/{roleName}";
        }

        public static class MenuSubModulosWebs
        {
            public const string GetAll = $"{Base}/menuSubModulosWebs";
            public const string Get = Base + "/menuSubModulosWebs/{menuSubModulosWebId}";
            public const string Create = $"{Base}/menuSubModulosWebs";
            public const string Update = Base + "/menuSubModulosWebs/{menuSubModulosWebId}";
            public const string Delete = Base + "/menuSubModulosWebs/{menuSubModulosWebId}";
        }

        public static class PreguntaAsas
        {
            public const string GetAll = $"{Base}/preguntaAsas";
            public const string Get = Base + "/preguntaAsas/{preguntaAsaId}";
            public const string Create = $"{Base}/preguntaAsas";
            public const string Update = Base + "/preguntaAsas/{preguntaAsaId}";
            public const string Delete = Base + "/preguntaAsas/{preguntaAsaId}";
            public const string GetRandomPreguntasAsa = $"{Base}/preguntaAsas/random";
            public const string GetByNumeroPregunta = Base + "/preguntaAsas/numeroPregunta/{numeroPregunta}";
        }

        public static class PreguntaAsaImagenAsas
        {
            public const string GetAll = $"{Base}/preguntaAsaImagenAsas";
            public const string Get = Base + "/preguntaAsaImagenAsas/{preguntaAsaId}/{imagenAsaId}";
            public const string Create = $"{Base}/preguntaAsaImagenAsas";
            public const string Update = Base + "/preguntaAsaImagenAsas/{preguntaAsaId}/{imagenAsaId}";
            public const string Delete = Base + "/preguntaAsaImagenAsas/{preguntaAsaId}/{imagenAsaId}";
        }

        public static class PreguntaAsaOpciones
        {
            public const string GetAll = $"{Base}/preguntaAsaOpciones";
            public const string Get = Base + "/preguntaAsaOpciones/{preguntaAsaOpcionId}";
            public const string Create = $"{Base}/preguntaAsaOpciones";
            public const string Update = Base + "/preguntaAsaOpciones/{preguntaAsaOpcionId}";
            public const string Delete = Base + "/preguntaAsaOpciones/{preguntaAsaOpcionId}";
        }

        public static class RespuestasAsas
        {
            public const string GetAllByUserId = Base + "/respuestasAsas/userId/{userId}";
            public const string Get = Base + "/respuestasAsas/{respuestasAsaId}";
            public const string Create = $"{Base}/respuestasAsas";
            public const string Update = Base + "/respuestasAsas/{respuestasAsaId}";
            public const string Delete = Base + "/respuestasAsas/{respuestasAsaId}";
            public const string CreateBatch = $"{Base}/respuestasAsas/batch";
            public const string Patch = Base + "/respuestasAsas/{respuestasAsaId}";
            public const string GetUserIdHasRespuestasAsa = Base + "/respuestasAsas/hasRespuestasAsa/{userId}";
			public const string GetFirstByUserId = Base + "/respuestasAsas/first/userId/{userId}";
            public const string ProcessRespuestasAsa = Base + "/respuestasAsas/process/consolidado/{userId}";
        }

        public static class RespuestasAsasConsolidado
        {
            public const string GetAllByUserId = Base + "/respuestasAsasConsolidado/{userId}";
            public const string CreateBatch = $"{Base}/respuestasAsasConsolidado/batch";
			public const string GetAllByUserIdAndLote = Base + "/respuestasAsasConsolidado/userId/{userId}/loteRespuestas/{loteRespuestasId}";
			public const string GetAllHeadersByUserId = Base + "/respuestasAsasConsolidado/headers/userId/{userId}";
            public const string UserHasAnswersInConsolidadoByConfiguracionId = Base + "/respuestasAsasConsolidado/configuracionId/{configuracionId}/userId/{userId}";
        }

		public static class ExamenGenerados
		{
			public const string GetAll = $"{Base}/examenGenerados";
			public const string Get = Base + "/examenGenerados/{examenGeneradoId}";
			public const string Create = $"{Base}/examenGenerados";
			public const string Update = Base + "/examenGenerados/{examenGeneradoId}";
			public const string Delete = Base + "/examenGenerados/{examenGeneradoId}";
			public const string CreatePreguntasExamenGenerado = Base + "/examenGenerado/preguntas/grupo/{grupoId}";
            public const string GetExamenByGrupoGuid = Base + "/examenGenerados/grupo/{grupoId}/guid/{guid}";
            public const string GetExamenHeaders = Base + "/examenGenerados/headers";
        }

        public static class Instructores
        {
            public const string GetAll = $"{Base}/instructores";
            public const string Get = Base + "/instructores/{instructorId}";
            public const string Create = $"{Base}/instructores";
            public const string Update = Base + "/instructores/{instructorId}";
            public const string Delete = Base + "/instructores/{instructorId}";
            public const string GetByUserId = Base + "/instructores/user/{userId}";
        }

        public static class Administrativos
        {
            public const string GetAll = $"{Base}/administrativos";
            public const string Get = Base + "/administrativos/{administrativoId}";
            public const string Create = $"{Base}/administrativos";
            public const string Update = Base + "/administrativos/{administrativoId}";
            public const string Delete = Base + "/administrativos/{administrativoId}";
        }

        public static class Materias
        {
            public const string GetAll = $"{Base}/materias";
            public const string Get = Base + "/materias/{materiaId}";
            public const string Create = $"{Base}/materias";
            public const string Update = Base + "/materias/{materiaId}";
            public const string Delete = Base + "/materias/{materiaId}";
            public const string GetAllNotAssignedMaterias = Base + "/materias/NoAssigned/{estudianteId}/{grupoId}";
            public const string GetAllMateriasAssignedByInstructorGrupo = Base + "/materias/assigned/instructor/grupo/{instructorId}/{grupoId}";
        }

        public static class Modulos
        {
            public const string GetAll = $"{Base}/modulos";
            public const string Get = Base + "/modulos/{moduloId}";
            public const string Create = $"{Base}/modulos";
            public const string Update = Base + "/modulos/{moduloId}";
            public const string Delete = Base + "/modulos/{moduloId}";
        }

        public static class ModuloMaterias
        {
            public const string GetAll = $"{Base}/moduloMaterias";
            public const string Get = Base + "/moduloMaterias/{moduloId}/{materiaId}";
            public const string Create = $"{Base}/moduloMaterias";
            public const string Delete = Base + "/moduloMaterias/{moduloId}/{materiaId}";
            public const string GetModuloByMateria = Base + "/moduloMaterias/{materiaId}";
        }

        public static class AsistenciaEstudianteHeaders
        {
            public const string GetAll = $"{Base}/asistenciaEstudianteHeaders";
            public const string Get = Base + "/asistenciaEstudianteHeaders/{asistenciaEstudianteHeaderId}";
            public const string Create = $"{Base}/asistenciaEstudianteHeaders";
            public const string Update = Base + "/asistenciaEstudianteHeaders/{asistenciaEstudianteHeaderId}";
            public const string Delete = Base + "/asistenciaEstudianteHeaders/{asistenciaEstudianteHeaderId}";
            public const string GetAllHeadersByGrupoAndMateriaId = Base + "/asistenciaEstudianteHeaders/grupo/{grupoId}/materia/{materiaId}";
            public const string GetAllHeadersByGrupoMateriaAndEstudianteId = Base + "/asistenciaEstudianteHeaders/grupo/{grupoId}/materia/{materiaId}/estudiante/{estudianteId}";
        }

        public static class AsistenciaEstudiantes
        {
            public const string GetAll = $"{Base}/asistenciaEstudiantes";
            public const string Get = Base + "/asistenciaEstudiantes/{asistenciaEstudianteId}";
            public const string Create = $"{Base}/asistenciaEstudiantes";
            public const string Update = Base + "/asistenciaEstudiantes/{asistenciaEstudianteId}";
            public const string Delete = Base + "/asistenciaEstudiantes/{asistenciaEstudianteId}";
            public const string CreateBatch = $"{Base}/asistenciaEstudiantes/batch";
            public const string PatchTipoAsistenciaId = Base + "/asistenciaEstudiantes/{asistenciaEstudianteId}";
        }

        public static class EstudianteMaterias
        {
            public const string GetAll = $"{Base}/estudianteMaterias";
            public const string Get = Base + "/estudianteMaterias/{estudianteId}/{grupoId}/{materiaId}";
            public const string Create = $"{Base}/estudianteMaterias";
            public const string Delete = Base + "/estudianteMaterias/{estudianteId}/{grupoId}/{materiaId}";
            public const string GetAllByEstudianteGrupo = Base + "/estudianteMaterias/{estudianteId}/{grupoId}";
            public const string CreateAsignAllMaterias = Base + "/estudianteMaterias/allMaterias/{estudianteId}/{grupoId}";
            public const string GetAllByMateriaGrupo = Base + "/estudianteMaterias/materiaGrupo/{materiaId}/{grupoId}";
            public const string GetAllByEstudianteId = Base + "/estudianteMaterias/estudianteId/{estudianteId}";
            public const string Update = Base + "/estudianteMaterias/{estudianteId}/{grupoId}/{materiaId}";
        }

        public static class TipoAsistencias
        {
            public const string GetAll = $"{Base}/tipoAsistencias";
            public const string Get = Base + "/tipoAsistencias/{tipoAsistenciaId}";
            public const string Create = $"{Base}/tipoAsistencias";
            public const string Update = Base + "/tipoAsistencias/{tipoAsistenciaId}";
            public const string Delete = Base + "/tipoAsistencias/{tipoAsistenciaId}";
        }

        public static class ProgramaAnaliticoPdfs
        {
            public const string GetAll = $"{Base}/programaAnaliticoPdfs";
            public const string Get = Base + "/programaAnaliticoPdfs/{programaAnaliticoPdfId}";
            public const string Create = $"{Base}/programaAnaliticoPdfs";
            public const string Update = Base + "/programaAnaliticoPdfs/{programaAnaliticoPdfId}";
            public const string Delete = Base + "/programaAnaliticoPdfs/{programaAnaliticoPdfId}";
            public const string GetAllNotAssignedInstructor = Base + "/programaAnaliticoPdfs/NoAssigned/Instructor/{instructorId}";
        }

        public static class InstructorMaterias
        {
            public const string GetAll = $"{Base}/instructorMaterias";
            public const string Get = Base + "/instructorMaterias/{instructorId}/{materiaId}/{grupoId}";
            public const string Create = $"{Base}/instructorMaterias";
            public const string Delete = Base + "/instructorMaterias/{instructorId}/{materiaId}/{grupoId}";
            public const string GetAllByInstructorId = Base + "/instructorMaterias/instructorId/{instructorId}";
        }

        public static class InstructorProgramaAnaliticos
        {
            public const string GetAll = $"{Base}/instructorProgramaAnaliticos";
            public const string Get = Base + "/instructorProgramaAnaliticos/{instructorId}/{programaAnaliticoPdfId}";
            public const string Create = $"{Base}/instructorProgramaAnaliticos";
            public const string Delete = Base + "/instructorProgramaAnaliticos/{instructorId}/{programaAnaliticoPdfId}";
            public const string GetAllByInstructorId = Base + "/instructorProgramaAnaliticos/instructor/{instructorId}";
        }

        public static class RegistroNotaHeaders
        {
            public const string GetAll = $"{Base}/registroNotaHeaders";
            public const string Get = Base + "/registroNotaHeaders/{registroNotaHeaderId}";
            public const string Create = $"{Base}/registroNotaHeaders";
            public const string Update = Base + "/registroNotaHeaders/{registroNotaHeaderId}";
            public const string Delete = Base + "/registroNotaHeaders/{registroNotaHeaderId}";
            public const string GetAllHeadersByGrupoAndMateriaId = Base + "/registroNotaHeaders/grupo/{grupoId}/materia/{materiaId}";
            public const string CreateRegistroNotaEstudianteHeader = $"{Base}/registroNotaHeaders/registroNotaEstudianteHeader";
        }

        public static class RegistroNotaEstudianteHeaders
        {
            public const string GetAll = $"{Base}/registroNotaEstudianteHeaders";
            public const string Get = Base + "/registroNotaEstudianteHeaders/{registroNotaEstudianteHeaderId}";
            public const string Create = $"{Base}/registroNotaEstudianteHeaders";
            public const string Update = Base + "/registroNotaEstudianteHeaders/{registroNotaEstudianteHeaderId}";
            public const string Delete = Base + "/registroNotaEstudianteHeaders/{registroNotaEstudianteHeaderId}";
            public const string GetAllByRegistroNotaHeaderId = Base + "/registroNotaEstudianteHeaders/registroNotaHeader/{registroNotaHeaderId}";
            public const string DeleteRegistroNotaEstudianteHeaderAndChildren = Base + "/registroNotaEstudianteHeaders/children/{registroNotaEstudianteHeaderId}";
        }

        public static class RegistroNotaEstudiantes
        {
            public const string GetAll = $"{Base}/registroNotaEstudiantes";
            public const string Get = Base + "/registroNotaEstudiantes/{registroNotaEstudianteId}";
            public const string Create = $"{Base}/registroNotaEstudiantes";
            public const string Update = Base + "/registroNotaEstudiantes/{registroNotaEstudianteId}";
            public const string Delete = Base + "/registroNotaEstudiantes/{registroNotaEstudianteId}";
            public const string GetAllByRegistroNotaEstudianteHeaderId = Base + "/registroNotaEstudiantes/RegistroNotaEstudianteHeader/{registroNotaEstudianteHeaderId}";
        }

        public static class TipoRegistroNotaEstudiantes
        {
            public const string GetAll = $"{Base}/tipoRegistroNotaEstudiantes";
            public const string Get = Base + "/tipoRegistroNotaEstudiantes/{tipoRegistroNotaEstudianteId}";
            public const string Create = $"{Base}/tipoRegistroNotaEstudiantes";
            public const string Update = Base + "/tipoRegistroNotaEstudiantes/{tipoRegistroNotaEstudianteId}";
            public const string Delete = Base + "/tipoRegistroNotaEstudiantes/{tipoRegistroNotaEstudianteId}";
        }

        public static class TipoRegistroNotaHeaders
        {
            public const string GetAll = $"{Base}/tipoRegistroNotaHeaders";
            public const string Get = Base + "/tipoRegistroNotaHeaders/{tipoRegistroNotaHeaderId}";
            public const string Create = $"{Base}/tipoRegistroNotaHeaders";
            public const string Update = Base + "/tipoRegistroNotaHeaders/{tipoRegistroNotaHeaderId}";
            public const string Delete = Base + "/tipoRegistroNotaHeaders/{tipoRegistroNotaHeaderId}";
        }

        public static class InhabilitacionEstudiantes
        {
            public const string GetAll = $"{Base}/inhabilitacionEstudiantes";
            public const string Get = Base + "/inhabilitacionEstudiantes/{inhabilitacionEstudianteId}";
            public const string Create = $"{Base}/inhabilitacionEstudiantes";
            public const string Update = Base + "/inhabilitacionEstudiantes/{inhabilitacionEstudianteId}";
            public const string Delete = Base + "/inhabilitacionEstudiantes/{inhabilitacionEstudianteId}";
            public const string GetByEstudianteId = Base + "/inhabilitacionEstudiantes/estudiante/{estudianteId}";
        }

        public static class CierreMaterias
        {
            public const string GetAll = $"{Base}/cierreMaterias";
            public const string Get = Base + "/cierreMaterias/{cierreMateriaId}";
            public const string Create = $"{Base}/cierreMaterias";
            //public const string Update = Base + "/cierreMaterias/{cierreMateriaId}";
            public const string Delete = Base + "/cierreMaterias/{cierreMateriaId}";
            public const string CreateAllByMateriaIdAndGrupoId = $"{Base}/cierreMaterias/all/materia/grupo";
            public const string GetByGrupoIdMateriaId = Base + "/cierreMaterias/grupo/{grupoId}/materia/{materiaId}";
        }

        public static class TipoAsistenciaEstudianteHeaders
        {
            public const string GetAll = $"{Base}/tipoAsistenciaEstudianteHeaders";
            public const string Get = Base + "/tipoAsistenciaEstudianteHeaders/{tipoAsistenciaEstudianteHeaderId}";
            public const string Create = $"{Base}/tipoAsistenciaEstudianteHeaders";
            public const string Update = Base + "/tipoAsistenciaEstudianteHeaders/{tipoAsistenciaEstudianteHeaderId}";
            public const string Delete = Base + "/tipoAsistenciaEstudianteHeaders/{tipoAsistenciaEstudianteHeaderId}";
        }
    }
}
