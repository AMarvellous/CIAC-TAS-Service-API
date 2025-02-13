using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class TipoAsistenciaEstudianteHeaderService : ITipoAsistenciaEstudianteHeaderService
    {
        private readonly DataContext _dataContext;

        public TipoAsistenciaEstudianteHeaderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TipoAsistenciaEstudianteHeader>> GetTipoAsistenciaEstudianteHeadersAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.TipoAsistenciaEstudianteHeader.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<TipoAsistenciaEstudianteHeader> GetTipoAsistenciaEstudianteHeaderByIdAsync(int id)
        {
            return await _dataContext.TipoAsistenciaEstudianteHeader.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateTipoAsistenciaEstudianteHeaderAsync(TipoAsistenciaEstudianteHeader tipoAsistenciaEstudianteHeader)
        {
            await _dataContext.TipoAsistenciaEstudianteHeader.AddAsync(tipoAsistenciaEstudianteHeader);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateTipoAsistenciaEstudianteHeaderAsync(TipoAsistenciaEstudianteHeader tipoAsistenciaEstudianteHeader)
        {
            _dataContext.TipoAsistenciaEstudianteHeader.Update(tipoAsistenciaEstudianteHeader);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteTipoAsistenciaEstudianteHeaderAsync(int tipoAsistenciaEstudianteHeaderId)
        {
            var tipoAsistenciaEstudianteHeader = await GetTipoAsistenciaEstudianteHeaderByIdAsync(tipoAsistenciaEstudianteHeaderId);

            if (tipoAsistenciaEstudianteHeader == null)
            {
                return false;
            }

            _dataContext.TipoAsistenciaEstudianteHeader.Remove(tipoAsistenciaEstudianteHeader);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
