using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IModuloService
    {
        Task<List<Modulo>> GetModulosAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateModuloAsync(Modulo modulo);
        Task<Modulo> GetModuloByIdAsync(int id);
        Task<bool> UpdateModuloAsync(Modulo modulo);
        Task<bool> DeleteModuloAsync(int id);
    }
}
