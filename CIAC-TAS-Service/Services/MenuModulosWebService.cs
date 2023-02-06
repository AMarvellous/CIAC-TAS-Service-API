using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Menu;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class MenuModulosWebService : IMenuModulosWebService
    {
        private readonly DataContext _dataContext;
        
        public MenuModulosWebService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<MenuModuloWeb>> GetMenuModulosWebsAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.MenuModulosWeb.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<MenuModuloWeb> GetMenuModulosWebByIdAsync(int id)
        {
            return await _dataContext.MenuModulosWeb.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateMenuModulosWebAsync(MenuModuloWeb menuModulosWeb)
        {
            await _dataContext.MenuModulosWeb.AddAsync(menuModulosWeb);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateMenuModulosWebAsync(MenuModuloWeb menuModulosWeb)
        {
            _dataContext.MenuModulosWeb.Update(menuModulosWeb);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteMenuModulosWebAsync(int menuModulosWebId)
        {
            var menuModulosWeb = await GetMenuModulosWebByIdAsync(menuModulosWebId);

            if (menuModulosWeb == null)
            {
                return false;
            }

            _dataContext.MenuModulosWeb.Remove(menuModulosWeb);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CheckModuloExists(int moduloId)
        {
            return await _dataContext.MenuModulosWeb.SingleOrDefaultAsync(x => x.Id == moduloId) != null;
        }

        public async Task<List<MenuModuloWeb>> GetMenuModulosWebsByRoleNameAsync(string roleName, PaginationFilter paginationFilter = null)
        {
            var role = await _dataContext.Roles.SingleOrDefaultAsync(x => x.Name == roleName);
            
            if (role == null)
            {
                return new List<MenuModuloWeb>();
            }

            var queryable = _dataContext.MenuModulosWeb.Include(sub => sub.MenuSubModulosWeb).AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.Where(x => x.RoleId == role.Id).ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Where(x => x.RoleId == role.Id).Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }
    }
}
