using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Estudiante;

namespace CIAC_TAS_Service.Services
{
    public interface IEstudianteGrupoService
    {
        Task<List<EstudianteGrupo>> GetEstudianteGruposAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateEstudianteGrupoAsync(EstudianteGrupo estudianteGrupo);
        Task<EstudianteGrupo> GetEstudianteGrupoByIdAsync(int estuadianteId, int grupoId);
        Task<bool> DeleteEstudianteGrupoAsync(int estuadianteId, int grupoId);
    }
}
