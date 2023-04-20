using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class ModuloService : IModuloService
    {
        private readonly DataContext _dataContext;

        public ModuloService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Modulo>> GetModulosAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.Modulo.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<Modulo> GetModuloByIdAsync(int id)
        {
            return await _dataContext.Modulo.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateModuloAsync(Modulo modulo)
        {
            await _dataContext.Modulo.AddAsync(modulo);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateModuloAsync(Modulo modulo)
        {
            _dataContext.Modulo.Update(modulo);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteModuloAsync(int moduloId)
        {
            var modulo = await GetModuloByIdAsync(moduloId);

            if (modulo == null)
            {
                return false;
            }

            _dataContext.Modulo.Remove(modulo);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
