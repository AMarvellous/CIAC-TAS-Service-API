using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;

namespace CIAC_TAS_Service.Services
{
    public interface IPreguntaAsaOpcionService
    {
        Task<List<PreguntaAsaOpcion>> GetPreguntaAsaOpcionsAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreatePreguntaAsaOpcionAsync(PreguntaAsaOpcion preguntaAsaOpcion);
        Task<PreguntaAsaOpcion> GetPreguntaAsaOpcionByIdAsync(int id);
        Task<bool> UpdatePreguntaAsaOpcionAsync(PreguntaAsaOpcion preguntaAsaOpcion);
        Task<bool> DeletePreguntaAsaOpcionAsync(int id);
    }
}
