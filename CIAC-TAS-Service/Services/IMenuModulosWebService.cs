using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Menu;

namespace CIAC_TAS_Service.Services
{
    public interface IMenuModulosWebService
    {
        Task<List<MenuModuloWeb>> GetMenuModulosWebsAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateMenuModulosWebAsync(MenuModuloWeb menuModulosWeb);
        Task<MenuModuloWeb> GetMenuModulosWebByIdAsync(int id);
        Task<bool> UpdateMenuModulosWebAsync(MenuModuloWeb menuModulosWeb);
        Task<bool> DeleteMenuModulosWebAsync(int id);
        Task<bool> CheckModuloExists(int moduloId);
    }
}
