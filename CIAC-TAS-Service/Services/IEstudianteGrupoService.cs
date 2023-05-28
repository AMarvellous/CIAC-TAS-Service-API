using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Domain.Estudiante;

namespace CIAC_TAS_Service.Services
{
    public interface IEstudianteGrupoService
    {
        Task<List<EstudianteGrupo>> GetEstudianteGruposAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateEstudianteGrupoAsync(EstudianteGrupo estudianteGrupo);
        Task<EstudianteGrupo> GetEstudianteGrupoByIdAsync(int estuadianteId, int grupoId);
        Task<bool> DeleteEstudianteGrupoAsync(int estuadianteId, int grupoId);
        Task<List<EstudianteGrupo>> GetEstudianteGruposHeadersAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateEstudianteGrupoBatchAsync(List<EstudianteGrupo> estudiantesGrupo);
        Task<List<EstudianteGrupo>> GetEstudianteGruposByGrupoIdAsync(int grupoId, PaginationFilter paginationFilter = null);
    }
}
