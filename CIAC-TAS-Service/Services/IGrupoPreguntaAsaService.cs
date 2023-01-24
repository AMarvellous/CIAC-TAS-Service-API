using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;

namespace CIAC_TAS_Service.Services
{
    public interface IGrupoPreguntaAsaService
    {
        Task<List<GrupoPreguntaAsa>> GetGrupoPreguntaAsasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateGrupoPreguntaAsaAsync(GrupoPreguntaAsa grupoPreguntaAsa);
        Task<GrupoPreguntaAsa> GetGrupoPreguntaAsaByIdAsync(int id);
        Task<bool> UpdateGrupoPreguntaAsaAsync(GrupoPreguntaAsa grupoPreguntaAsa);
        Task<bool> DeleteGrupoPreguntaAsaAsync(int id);
        Task<bool> CheckGrupoPreguntaAsaExists(int GrupoPreguntaAsaId);
    }
}
