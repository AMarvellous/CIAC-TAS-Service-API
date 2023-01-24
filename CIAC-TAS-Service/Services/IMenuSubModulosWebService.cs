using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Menu;

namespace CIAC_TAS_Service.Services
{
    public interface IMenuSubModulosWebService
    {
        Task<List<MenuSubModuloWeb>> GetMenuSubModulosWebsAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateMenuSubModulosWebAsync(MenuSubModuloWeb menuSubModulosWeb);
        Task<MenuSubModuloWeb> GetMenuSubModulosWebByIdAsync(int id);
        Task<bool> UpdateMenuSubModulosWebAsync(MenuSubModuloWeb menuSubModulosWeb);
        Task<bool> DeleteMenuSubModulosWebAsync(int id);
    }
}
