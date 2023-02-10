using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;

namespace CIAC_TAS_Service.Services
{
    public interface IConfiguracionPreguntaAsaService
    {
        Task<List<ConfiguracionPreguntaAsa>> GetConfiguracionPreguntaAsasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateConfiguracionPreguntaAsaAsync(ConfiguracionPreguntaAsa configuracionPreguntaAsa);
        Task<ConfiguracionPreguntaAsa> GetConfiguracionPreguntaAsaByIdAsync(int id);
        Task<bool> UpdateConfiguracionPreguntaAsaAsync(ConfiguracionPreguntaAsa configuracionPreguntaAsa);
        Task<bool> DeleteConfiguracionPreguntaAsaAsync(int id);
        Task<bool> CheckConfiguracionPreguntaAsaExistsAsync(int id);
    }
}
