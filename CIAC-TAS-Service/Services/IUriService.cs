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
    }
}
