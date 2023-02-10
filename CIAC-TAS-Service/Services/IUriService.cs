using CIAC_TAS_Service.Contracts.V1.Requests.Queries;

namespace CIAC_TAS_Service.Services
{
    public interface IUriService
    {
        Uri GetPostUri(string postId);

        Uri GetAllPostUri(PaginationQuery pagination = null);

        Uri GetGrupoUri(string grupoId);

        Uri GetGrupoPreguntaAsaUri(string grupoPreguntaAsaId);
        Uri GetProgramaUri(string programaId);
        Uri GetImagenAsaUri(string imagenAsaId);
        Uri GetEstadoPreguntaAsaUri(string estadoPreguntaAsaId);
        Uri GetConfiguracionPreguntaAsaUri(string configuracionPreguntaAsaId);
        Uri GetEstudianteUri(string estudianteId);
        Uri GetEstudianteGrupoUri(string estudianteId, string grupoId);
        Uri GetEstudianteProgramaUri(string estudianteId, string programaId);
        Uri GetMenuModulosWebUri(string menuModulosWebId);
        Uri GetMenuSubModulosWebUri(string menuSubModulosWebId);
        Uri GetPreguntaAsaUri(string preguntaAsaId);
        Uri GetPreguntaAsaImagenAsaUri(string preguntaAsaId, string imagenAsaId);
        Uri GetPreguntaAsaOpcionUri(string preguntaAsaOpcionId);
        Uri GetRespuestasAsaUri(string respuestasAsaId);
        Uri GetRespuestasAsaConsolidadoUri(string userId);
    }
}
