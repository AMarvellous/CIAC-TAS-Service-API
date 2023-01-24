using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;

namespace CIAC_TAS_Service.Services
{
    public interface IPreguntaAsaService
    {
        Task<List<PreguntaAsa>> GetPreguntaAsasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreatePreguntaAsaAsync(PreguntaAsa preguntaAsa);
        Task<PreguntaAsa> GetPreguntaAsaByIdAsync(int id);
        Task<bool> UpdatePreguntaAsaAsync(PreguntaAsa preguntaAsa);
        Task<bool> DeletePreguntaAsaAsync(int id);
        Task<bool> CheckExistsPreguntaAsaAsync(int preguntaAsaId);
    }
}
