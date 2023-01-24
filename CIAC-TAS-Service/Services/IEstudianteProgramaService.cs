using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Estudiante;

namespace CIAC_TAS_Service.Services
{
    public interface IEstudianteProgramaService
    {
        Task<List<EstudiantePrograma>> GetEstudianteProgramasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateEstudianteProgramaAsync(EstudiantePrograma estudiantePrograma);
        Task<EstudiantePrograma> GetEstudianteProgramaByIdAsync(int estudianteId, int programaId);
        Task<bool> DeleteEstudianteProgramaAsync(int estudianteId, int programaId);
    }
}
