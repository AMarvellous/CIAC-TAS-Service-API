using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IModuloMateriaService
    {
        Task<List<ModuloMateria>> GetModuloMateriasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateModuloMateriaAsync(ModuloMateria moduloMateria);
        Task<ModuloMateria> GetModuloMateriaByIdAsync(int moduloId, int materiaId);
        Task<bool> DeleteModuloMateriaAsync(int moduloId, int materiaId);
    }
}
