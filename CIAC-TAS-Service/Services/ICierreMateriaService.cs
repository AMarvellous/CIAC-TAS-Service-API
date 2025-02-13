using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface ICierreMateriaService
    {
        Task<List<CierreMateria>> GetCierreMateriasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateCierreMateriaAsync(CierreMateria cierreMateria);
        Task<CierreMateria> GetCierreMateriaByIdAsync(int id);
        Task<bool> UpdateCierreMateriaAsync(CierreMateria cierreMateria);
        Task<bool> DeleteCierreMateriaAsync(int id);
        Task<CierreMateria> GetByGrupoIdMateriaId(int grupoId, int materiaId);
    }
}
