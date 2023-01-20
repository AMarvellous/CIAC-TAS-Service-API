﻿namespace CIAC_TAS_Service.Contracts.V1
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
        }
    }
}
