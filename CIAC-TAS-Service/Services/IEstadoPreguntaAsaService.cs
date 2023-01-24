using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;

namespace CIAC_TAS_Service.Services
{
    public interface IEstadoPreguntaAsaService
    {
        Task<List<EstadoPreguntaAsa>> GetEstadoPreguntaAsasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateEstadoPreguntaAsaAsync(EstadoPreguntaAsa estadoPreguntaAsa);
        Task<EstadoPreguntaAsa> GetEstadoPreguntaAsaByIdAsync(int id);
        Task<bool> UpdateEstadoPreguntaAsaAsync(EstadoPreguntaAsa estadoPreguntaAsa);
        Task<bool> DeleteEstadoPreguntaAsaAsync(int id);
        Task<bool> CheckEstadoPreguntaAsaExists(int estadoPreguntaAsaId);
    }
}
