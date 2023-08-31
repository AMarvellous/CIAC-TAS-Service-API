using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface ITipoAsistenciaService
    {
        Task<List<TipoAsistencia>> GetTipoAsistenciasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateTipoAsistenciaAsync(TipoAsistencia tipoAsistencia);
        Task<TipoAsistencia> GetTipoAsistenciaByIdAsync(int id);
        Task<bool> UpdateTipoAsistenciaAsync(TipoAsistencia tipoAsistencia);
        Task<bool> DeleteTipoAsistenciaAsync(int id);
    }
}
