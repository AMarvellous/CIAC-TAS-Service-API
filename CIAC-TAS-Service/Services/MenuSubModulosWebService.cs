using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class MenuSubModulosWebService : IMenuSubModulosWebService
    {
        private readonly DataContext _dataContext;

        public MenuSubModulosWebService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<MenuSubModuloWeb>> GetMenuSubModulosWebsAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.MenuSubModulosWeb.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<MenuSubModuloWeb> GetMenuSubModulosWebByIdAsync(int id)
        {
            return await _dataContext.MenuSubModulosWeb.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateMenuSubModulosWebAsync(MenuSubModuloWeb menuSubModulosWeb)
        {
            await _dataContext.MenuSubModulosWeb.AddAsync(menuSubModulosWeb);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateMenuSubModulosWebAsync(MenuSubModuloWeb menuSubModulosWeb)
        {
            _dataContext.MenuSubModulosWeb.Update(menuSubModulosWeb);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteMenuSubModulosWebAsync(int menuSubModulosWebId)
        {
            var menuSubModulosWeb = await GetMenuSubModulosWebByIdAsync(menuSubModulosWebId);

            if (menuSubModulosWeb == null)
            {
                return false;
            }

            _dataContext.MenuSubModulosWeb.Remove(menuSubModulosWeb);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
