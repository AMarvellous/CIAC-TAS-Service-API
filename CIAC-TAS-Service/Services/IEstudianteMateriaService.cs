using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IEstudianteMateriaService
    {
        Task<List<EstudianteMateria>> GetEstudianteMateriasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateEstudianteMateriaAsync(EstudianteMateria estudianteMateria);
        Task<EstudianteMateria> GetEstudianteMateriaByIdAsync(int estudianteId, int grupoId, int materiaId);
        Task<bool> DeleteEstudianteMateriaAsync(int estudianteId, int grupoId, int materiaId);
    }
}
