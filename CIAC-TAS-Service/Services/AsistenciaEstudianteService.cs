using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class AsistenciaEstudianteService : IAsistenciaEstudianteService
    {
        private readonly DataContext _dataContext;

        public AsistenciaEstudianteService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<AsistenciaEstudiante>> GetAsistenciaEstudiantesAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.AsistenciaEstudiante
                .Include(x => x.Estudiante)
                .Include(x => x.TipoAsistencia)
                .AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<AsistenciaEstudiante> GetAsistenciaEstudianteByIdAsync(int id)
        {
            return await _dataContext.AsistenciaEstudiante
                .Include(x => x.Estudiante)
                .Include(x => x.TipoAsistencia)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateAsistenciaEstudianteAsync(AsistenciaEstudiante asistenciaEstudiante)
        {
            await _dataContext.AsistenciaEstudiante.AddAsync(asistenciaEstudiante);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateAsistenciaEstudianteAsync(AsistenciaEstudiante asistenciaEstudiante)
        {
            _dataContext.AsistenciaEstudiante.Update(asistenciaEstudiante);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteAsistenciaEstudianteAsync(int asistenciaEstudianteId)
        {
            var asistenciaEstudiante = await GetAsistenciaEstudianteByIdAsync(asistenciaEstudianteId);

            if (asistenciaEstudiante == null)
            {
                return false;
            }

            _dataContext.AsistenciaEstudiante.Remove(asistenciaEstudiante);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CreateAsistenciaEstudianteBatchAsync(List<AsistenciaEstudiante> asistenciaEstudiante)
        {
            await _dataContext.AsistenciaEstudiante.AddRangeAsync(asistenciaEstudiante);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
    }
}
