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
    }
}
