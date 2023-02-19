using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;

namespace CIAC_TAS_Service.Services
{
    public interface IRespuestasAsaConsolidadoService
    {
        Task<List<RespuestasAsaConsolidado>> GetRespuestasAsasConsolidadoByUserIdAsync(string userId, PaginationFilter paginationFilter = null);
		Task<List<RespuestasAsaConsolidado>> GetRespuestasAsasConsolidadoByUserIdLoteRespuestasIdAsync(Guid loteRespuestasId, string userId, PaginationFilter paginationFilter = null);
		Task<List<RespuestasAsaConsolidado>> GetRespuestasAsasConsolidadoHeadersByUserIdAsync(string userId, PaginationFilter paginationFilter = null);
		Task<bool> CreateRespuestasAsaBatchAsync(List<RespuestasAsaConsolidado> respuestasAsaConsolidado);
        Task<bool> ProcessRespuestasAsaAsync(string userId);

    }
}
