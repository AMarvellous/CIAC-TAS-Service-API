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
        }

        public static class EstudianteGrupos
        {
            public const string GetAll = $"{Base}/estudianteGrupos";
            public const string Get = Base + "/estudianteGrupos/{estudianteId}/{grupoId}";
            public const string Create = $"{Base}/estudianteGrupos";
            public const string Delete = Base + "/estudianteGrupos/{estudianteId}/{grupoId}";
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
    }
}
