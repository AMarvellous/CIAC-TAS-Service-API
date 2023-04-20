using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class AdministrativoService : IAdministrativoService
    {
        private readonly DataContext _dataContext;

        public AdministrativoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Administrativo>> GetAdministrativosAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.Administrativo.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<Administrativo> GetAdministrativoByIdAsync(int id)
        {
            return await _dataContext.Administrativo.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateAdministrativoAsync(Administrativo administrativo)
        {
            await _dataContext.Administrativo.AddAsync(administrativo);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateAdministrativoAsync(Administrativo administrativo)
        {
            _dataContext.Administrativo.Update(administrativo);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteAdministrativoAsync(int administrativoId)
        {
            var administrativo = await GetAdministrativoByIdAsync(administrativoId);

            if (administrativo == null)
            {
                return false;
            }

            _dataContext.Administrativo.Remove(administrativo);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CheckUserIdIsAssignedAsync(string userId)
        {
            var user = await _dataContext.Administrativo.AsNoTracking()
                .SingleOrDefaultAsync(x => x.UserId == userId);

            return user != null;
        }

        public async Task<bool> CheckUserIdIsAssignableToThisAdministrativoAsync(int administrativoId, string proposedUserId)
        {
            var administrativo = await _dataContext.Administrativo.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == administrativoId);

            if (proposedUserId == administrativo.UserId)
            {
                return true;
            }

            return !await CheckUserIdIsAssignedAsync(proposedUserId);
        }
    }
}
