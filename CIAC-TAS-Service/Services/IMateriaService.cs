using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IMateriaService
    {
        Task<List<Materia>> GetMateriasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateMateriaAsync(Materia materia);
        Task<Materia> GetMateriaByIdAsync(int id);
        Task<bool> UpdateMateriaAsync(Materia materia);
        Task<bool> DeleteMateriaAsync(int id);
    }
}
