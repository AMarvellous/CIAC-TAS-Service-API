using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class TipoAsistenciaService : ITipoAsistenciaService
    {
        private readonly DataContext _dataContext;

        public TipoAsistenciaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TipoAsistencia>> GetTipoAsistenciasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.TipoAsistencia.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<TipoAsistencia> GetTipoAsistenciaByIdAsync(int id)
        {
            return await _dataContext.TipoAsistencia.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateTipoAsistenciaAsync(TipoAsistencia tipoAsistencia)
        {
            await _dataContext.TipoAsistencia.AddAsync(tipoAsistencia);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateTipoAsistenciaAsync(TipoAsistencia tipoAsistencia)
        {
            _dataContext.TipoAsistencia.Update(tipoAsistencia);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteTipoAsistenciaAsync(int tipoAsistenciaId)
        {
            var tipoAsistencia = await GetTipoAsistenciaByIdAsync(tipoAsistenciaId);

            if (tipoAsistencia == null)
            {
                return false;
            }

            _dataContext.TipoAsistencia.Remove(tipoAsistencia);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
