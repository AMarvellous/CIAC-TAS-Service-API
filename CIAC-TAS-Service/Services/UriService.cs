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
    }
}
