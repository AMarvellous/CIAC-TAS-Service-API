using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class TipoRegistroNotaEstudianteService : ITipoRegistroNotaEstudianteService
    {
        private readonly DataContext _dataContext;

        public TipoRegistroNotaEstudianteService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TipoRegistroNotaEstudiante>> GetTipoRegistroNotaEstudiantesAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.TipoRegistroNotaEstudiante.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<TipoRegistroNotaEstudiante> GetTipoRegistroNotaEstudianteByIdAsync(int id)
        {
            return await _dataContext.TipoRegistroNotaEstudiante.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateTipoRegistroNotaEstudianteAsync(TipoRegistroNotaEstudiante tipoRegistroNotaEstudiante)
        {
            await _dataContext.TipoRegistroNotaEstudiante.AddAsync(tipoRegistroNotaEstudiante);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateTipoRegistroNotaEstudianteAsync(TipoRegistroNotaEstudiante tipoRegistroNotaEstudiante)
        {
            _dataContext.TipoRegistroNotaEstudiante.Update(tipoRegistroNotaEstudiante);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteTipoRegistroNotaEstudianteAsync(int tipoRegistroNotaEstudianteId)
        {
            var tipoRegistroNotaEstudiante = await GetTipoRegistroNotaEstudianteByIdAsync(tipoRegistroNotaEstudianteId);

            if (tipoRegistroNotaEstudiante == null)
            {
                return false;
            }

            _dataContext.TipoRegistroNotaEstudiante.Remove(tipoRegistroNotaEstudiante);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
