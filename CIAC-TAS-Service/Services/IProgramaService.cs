using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.General;

namespace CIAC_TAS_Service.Services
{
    public interface IProgramaService
    {
        Task<List<Programa>> GetProgramasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateProgramaAsync(Programa programa);
        Task<Programa> GetProgramaByIdAsync(int id);
        Task<bool> UpdateProgramaAsync(Programa programa);
        Task<bool> DeleteProgramaAsync(int id);
    }
}
