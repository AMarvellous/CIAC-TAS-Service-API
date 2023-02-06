using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using Microsoft.AspNetCore.WebUtilities;

namespace CIAC_TAS_Service.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetAllPostUri(PaginationQuery pagination = null)
        {
            var uri = new Uri(_baseUri);

            if (pagination == null)
            {
                return uri;
            }

            var modifiedUri = QueryHelpers.AddQueryString(uri.ToString(), "pageNumber", pagination.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", pagination.PageSize.ToString());

            return new Uri(modifiedUri);
        }

        public Uri GetPostUri(string postId)
        {
            return new Uri(_baseUri + ApiRoute.Posts.Get.Replace("{postId}", postId));          
        }

        public Uri GetGrupoUri(string grupoId)
        {
            return new Uri(_baseUri + ApiRoute.Grupos.Get.Replace("{grupoId}", grupoId));
        }

        public Uri GetGrupoPreguntaAsaUri(string grupoPreguntaAsaId)
        {
            return new Uri(_baseUri + ApiRoute.GrupoPreguntaAsas.Get.Replace("{grupoPreguntaAsaId}", grupoPreguntaAsaId));
        }

        public Uri GetProgramaUri(string programaId)
        {
            return new Uri(_baseUri + ApiRoute.Programas.Get.Replace("{programaId}", programaId));
        }

        public Uri GetImagenAsaUri(string imagenAsaId)
        {
            return new Uri(_baseUri + ApiRoute.ImagenAsas.Get.Replace("{imagenAsaId}", imagenAsaId));
        }

        public Uri GetEstadoPreguntaAsaUri(string estadoPreguntaAsaId)
        {
            return new Uri(_baseUri + ApiRoute.EstadoPreguntaAsas.Get.Replace("{estadoPreguntaAsaId}", estadoPreguntaAsaId));
        }

        public Uri GetConfiguracionPreguntaAsaUri(string configuracionPreguntaAsaId)
        {
            return new Uri(_baseUri + ApiRoute.ConfiguracionPreguntaAsas.Get.Replace("{configuracionPreguntaAsaId}", configuracionPreguntaAsaId));
        }

        public Uri GetEstudianteUri(string estudianteId)
        {
            return new Uri(_baseUri + ApiRoute.Estudiantes.Get.Replace("{estudianteId}", estudianteId));
        }

        public Uri GetEstudianteGrupoUri(string estudianteId, string grupoId)
        {
            return new Uri(_baseUri + ApiRoute.EstudianteGrupos.Get.Replace("{estudianteId}", estudianteId).Replace("{grupoId}", grupoId));
        }

        public Uri GetEstudianteProgramaUri(string estudianteId, string programaId)
        {
            return new Uri(_baseUri + ApiRoute.EstudianteProgramas.Get.Replace("{estudianteId}", estudianteId).Replace("{programaId}", programaId));
        }

        public Uri GetMenuModulosWebUri(string menuModulosWebId)
        {
            return new Uri(_baseUri + ApiRoute.MenuModulosWebs.Get.Replace("{menuModulosWebId}", menuModulosWebId));
        }

        public Uri GetMenuSubModulosWebUri(string menuSubModulosWebId)
        {
            return new Uri(_baseUri + ApiRoute.MenuSubModulosWebs.Get.Replace("{menuSubModulosWebId}", menuSubModulosWebId));
        }

        public Uri GetPreguntaAsaUri(string preguntaAsaId)
        {
            return new Uri(_baseUri + ApiRoute.PreguntaAsas.Get.Replace("{preguntaAsaId}", preguntaAsaId));
        }

        public Uri GetPreguntaAsaImagenAsaUri(string preguntaAsaId, string imagenAsaId)
        {
            return new Uri(_baseUri + ApiRoute.PreguntaAsaImagenAsas.Get.Replace("{preguntaAsaId}", preguntaAsaId).Replace("{ImagenAsaId}", imagenAsaId));
        }

        public Uri GetPreguntaAsaOpcionUri(string preguntaAsaOpcionId)
        {
            return new Uri(_baseUri + ApiRoute.PreguntaAsaOpciones.Get.Replace("{preguntaAsaOpcionId}", preguntaAsaOpcionId));
        }

        public Uri GetRespuestasAsaUri(string respuestasAsaId)
        {
            return new Uri(_baseUri + ApiRoute.RespuestasAsas.Get.Replace("{respuestasAsaId}", respuestasAsaId));
        }
    }
}
