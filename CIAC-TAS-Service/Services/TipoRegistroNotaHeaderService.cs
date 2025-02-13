using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class TipoRegistroNotaHeaderService : ITipoRegistroNotaHeaderService
    {
        private readonly DataContext _dataContext;

        public TipoRegistroNotaHeaderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TipoRegistroNotaHeader>> GetTipoRegistroNotaHeadersAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.TipoRegistroNotaHeader.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<TipoRegistroNotaHeader> GetTipoRegistroNotaHeaderByIdAsync(int id)
        {
            return await _dataContext.TipoRegistroNotaHeader.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateTipoRegistroNotaHeaderAsync(TipoRegistroNotaHeader tipoRegistroNotaHeader)
        {
            await _dataContext.TipoRegistroNotaHeader.AddAsync(tipoRegistroNotaHeader);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateTipoRegistroNotaHeaderAsync(TipoRegistroNotaHeader tipoRegistroNotaHeader)
        {
            _dataContext.TipoRegistroNotaHeader.Update(tipoRegistroNotaHeader);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteTipoRegistroNotaHeaderAsync(int tipoRegistroNotaHeaderId)
        {
            var tipoRegistroNotaHeader = await GetTipoRegistroNotaHeaderByIdAsync(tipoRegistroNotaHeaderId);

            if (tipoRegistroNotaHeader == null)
            {
                return false;
            }

            _dataContext.TipoRegistroNotaHeader.Remove(tipoRegistroNotaHeader);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
