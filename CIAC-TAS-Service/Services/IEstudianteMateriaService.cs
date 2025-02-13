using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Contracts.V1.Requests;

namespace CIAC_TAS_Service.Services
{
    public interface IEstudianteMateriaService
    {
        Task<List<EstudianteMateria>> GetEstudianteMateriasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateEstudianteMateriaAsync(EstudianteMateria estudianteMateria);
        Task<EstudianteMateria> GetEstudianteMateriaByIdAsync(int estudianteId, int grupoId, int materiaId);
        Task<bool> DeleteEstudianteMateriaAsync(int estudianteId, int grupoId, int materiaId);
        Task<List<EstudianteMateria>> GetAllByEstudianteGrupoAsync(int estudianteId, int grupoId, PaginationFilter paginationFilter = null);
        Task<bool> CreateAsignAllMaterias(int estudianteId, int grupoId);
        Task<List<EstudianteMateria>> GetAllByMateriaGrupoAsync(int materiaId, int grupoId, PaginationFilter paginationFilter = null);
        Task<List<EstudianteMateria>> GetAllByEstudianteIdAsync(int estudianteId, PaginationFilter paginationFilter = null);
        Task<bool> UpdateEstudianteMateriaAsync(EstudianteMateria estudianteMateria);
    }
}
