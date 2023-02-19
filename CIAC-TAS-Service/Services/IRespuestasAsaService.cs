using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;

namespace CIAC_TAS_Service.Services
{
    public interface IRespuestasAsaService
    {
        Task<List<RespuestasAsa>> GetRespuestasAsasByUserIdAsync(string userId, PaginationFilter paginationFilter = null);
        Task<bool> CreateRespuestasAsaAsync(RespuestasAsa respuestasAsa);
        Task<RespuestasAsa> GetRespuestasAsaByIdAsync(int id);
        Task<bool> UpdateRespuestasAsaAsync(RespuestasAsa respuestasAsa);
        Task<bool> DeleteRespuestasAsaAsync(int id);
        Task<bool> CreateRespuestasAsaBatchAsync(List<RespuestasAsa> respuestasAsa);

        Task<bool> GetUserIdHasRespuestasAsaAsync(string userId, PaginationFilter paginationFilter = null);
		Task<RespuestasAsa> GetFirstRespuestasAsaByUserIdAsync(string userId);
        Task<bool> DeleteRespuestasAsaBatchByUserIdAsync(string userId);

    }
}
