using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;

namespace CIAC_TAS_Service.Services
{
    public interface IPreguntaAsaImagenAsaService
    {
        Task<List<PreguntaAsaImagenAsa>> GetPreguntaAsaImagenAsasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreatePreguntaAsaImagenAsaAsync(PreguntaAsaImagenAsa preguntaAsaImagenAsa);
        Task<PreguntaAsaImagenAsa> GetPreguntaAsaImagenAsaByIdAsync(int preguntaAsaId, int imagenAsaId);
        Task<bool> DeletePreguntaAsaImagenAsaAsync(int preguntaAsaId, int imagenAsaId);
        Task<bool> CheckPreguntaAsaImagenAsaExistsAsync(int preguntaAsaId, int imagenAsaId);
    }
}
