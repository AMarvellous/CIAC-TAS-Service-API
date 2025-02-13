using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface ITipoRegistroNotaHeaderService
    {
        Task<List<TipoRegistroNotaHeader>> GetTipoRegistroNotaHeadersAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateTipoRegistroNotaHeaderAsync(TipoRegistroNotaHeader tipoRegistroNotaHeader);
        Task<TipoRegistroNotaHeader> GetTipoRegistroNotaHeaderByIdAsync(int id);
        Task<bool> UpdateTipoRegistroNotaHeaderAsync(TipoRegistroNotaHeader tipoRegistroNotaHeader);
        Task<bool> DeleteTipoRegistroNotaHeaderAsync(int id);
    }
}
