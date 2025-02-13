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

        public Uri GetRespuestasAsaConsolidadoUri(string userId)
        {
            return new Uri(_baseUri + ApiRoute.RespuestasAsasConsolidado.GetAllByUserId.Replace("{userId}", userId));
        }

		public Uri GetExamenGeneradoUri(string examenGeneradoId)
		{
			return new Uri(_baseUri + ApiRoute.ExamenGenerados.Get.Replace("{examenGeneradoId}", examenGeneradoId));
		}

        public Uri GetInstructorUri(string instructorId)
        {
            return new Uri(_baseUri + ApiRoute.Instructores.Get.Replace("{instructorId}", instructorId));
        }

        public Uri GetAdministrativoUri(string administrativoId)
        {
            return new Uri(_baseUri + ApiRoute.Administrativos.Get.Replace("{administrativoId}", administrativoId));
        }

        public Uri GetMateriaUri(string materiaId)
        {
            return new Uri(_baseUri + ApiRoute.Materias.Get.Replace("{materiaId}", materiaId));
        }

        public Uri GetModuloUri(string moduloId)
        {
            return new Uri(_baseUri + ApiRoute.Modulos.Get.Replace("{moduloId}", moduloId));
        }

        public Uri GetModuloMateriaUri(string moduloId, string materiaId)
        {
            return new Uri(_baseUri + ApiRoute.ModuloMaterias.Get.Replace("{moduloId}", moduloId).Replace("{materiaId}", materiaId));
        }

        public Uri GetAsistenciaEstudianteHeaderUri(string asistenciaEstudianteHeaderId)
        {
            return new Uri(_baseUri + ApiRoute.AsistenciaEstudianteHeaders.Get.Replace("{asistenciaEstudianteHeaderId}", asistenciaEstudianteHeaderId));
        }

        public Uri GetAsistenciaEstudianteUri(string asistenciaEstudianteId)
        {
            return new Uri(_baseUri + ApiRoute.AsistenciaEstudiantes.Get.Replace("{asistenciaEstudianteId}", asistenciaEstudianteId));
        }

        public Uri GetEstudianteMateriaUri(string estudianteId, string grupoId, string materiaId)
        {
            return new Uri(_baseUri + ApiRoute.EstudianteMaterias.Get
                .Replace("{estudianteId}", estudianteId)
                .Replace("{grupoId}", grupoId)
                .Replace("{materiaId}", materiaId));
        }

        public Uri GetTipoAsistenciaUri(string tipoAsistenciaId)
        {
            return new Uri(_baseUri + ApiRoute.TipoAsistencias.Get.Replace("{tipoAsistenciaId}", tipoAsistenciaId));
        }

        public Uri GetProgramaAnaliticoPdfUri(string programaAnaliticoPdfId)
        {
            return new Uri(_baseUri + ApiRoute.ProgramaAnaliticoPdfs.Get.Replace("{programaAnaliticoPdfId}", programaAnaliticoPdfId));
        }

        public Uri GetInstructorMateriaUri(string instructorId, string materiaId, string grupoId)
        {
            return new Uri(_baseUri + ApiRoute.InstructorMaterias.Get.Replace("{instructorId}", instructorId).Replace("{materiaId}", materiaId).Replace("{grupoId}", grupoId));
        }

        public Uri GetInstructorProgramaAnaliticoUri(string instructorId, string programaAnaliticoId)
        {
            return new Uri(_baseUri + ApiRoute.InstructorProgramaAnaliticos.Get.Replace("{instructorId}", instructorId).Replace("{programaAnaliticoPdfId}", programaAnaliticoId));
        }

        public Uri GetRegistroNotaHeaderUri(string registroNotaHeaderId)
        {
            return new Uri(_baseUri + ApiRoute.RegistroNotaHeaders.Get.Replace("{registroNotaHeaderId}", registroNotaHeaderId));
        }

        public Uri GetRegistroNotaEstudianteHeaderUri(string registroNotaEstudianteHeaderId)
        {
            return new Uri(_baseUri + ApiRoute.RegistroNotaEstudianteHeaders.Get.Replace("{registroNotaEstudianteHeaderId}", registroNotaEstudianteHeaderId));
        }

        public Uri GetRegistroNotaEstudianteUri(string registroNotaEstudianteId)
        {
            return new Uri(_baseUri + ApiRoute.RegistroNotaEstudiantes.Get.Replace("{registroNotaEstudianteId}", registroNotaEstudianteId));
        }

        public Uri GetTipoRegistroNotaEstudianteUri(string tipoRegistroNotaEstudianteId)
        {
            return new Uri(_baseUri + ApiRoute.TipoRegistroNotaEstudiantes.Get.Replace("{tipoRegistroNotaEstudianteId}", tipoRegistroNotaEstudianteId));
        }

        public Uri GetTipoRegistroNotaHeaderUri(string tipoRegistroNotaHeaderId)
        {
            return new Uri(_baseUri + ApiRoute.TipoRegistroNotaHeaders.Get.Replace("{tipoRegistroNotaHeaderId}", tipoRegistroNotaHeaderId));
        }

        public Uri GetInhabilitacionEstudianteUri(string inhabilitacionEstudianteId)
        {
            return new Uri(_baseUri + ApiRoute.InhabilitacionEstudiantes.Get.Replace("{inhabilitacionEstudianteId}", inhabilitacionEstudianteId));
        }

        public Uri GetCierreMateriaUri(string cierreMateriaId)
        {
            return new Uri(_baseUri + ApiRoute.CierreMaterias.Get.Replace("{cierreMateriaId}", cierreMateriaId));
        }

        public Uri GetTipoAsistenciaEstudianteHeaderUri(string tipoAsistenciaEstudianteHeaderId)
        {
            return new Uri(_baseUri + ApiRoute.TipoAsistenciaEstudianteHeaders.Get.Replace("{tipoAsistenciaEstudianteHeaderId}", tipoAsistenciaEstudianteHeaderId));
        }
    }
}
