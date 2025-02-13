using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class InhabilitacionEstudianteService : IInhabilitacionEstudianteService
    {
        private readonly DataContext _dataContext;

        public InhabilitacionEstudianteService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<InhabilitacionEstudiante>> GetInhabilitacionEstudiantesAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.InhabilitacionEstudiante
                .Include(x => x.Estudiante)
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

        public async Task<InhabilitacionEstudiante> GetInhabilitacionEstudianteByIdAsync(int id)
        {
            return await _dataContext.InhabilitacionEstudiante
                .Include(x => x.Estudiante)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateInhabilitacionEstudianteAsync(InhabilitacionEstudiante inhabilitacionEstudiante)
        {
            await _dataContext.InhabilitacionEstudiante.AddAsync(inhabilitacionEstudiante);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateInhabilitacionEstudianteAsync(InhabilitacionEstudiante inhabilitacionEstudiante)
        {
            _dataContext.InhabilitacionEstudiante.Update(inhabilitacionEstudiante);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteInhabilitacionEstudianteAsync(int inhabilitacionEstudianteId)
        {
            var inhabilitacionEstudiante = await GetInhabilitacionEstudianteByIdAsync(inhabilitacionEstudianteId);

            if (inhabilitacionEstudiante == null)
            {
                return false;
            }

            _dataContext.InhabilitacionEstudiante.Remove(inhabilitacionEstudiante);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<InhabilitacionEstudiante> GetInhabilitacionEstudianteByEstudianteIdAsync(int estudianteId)
        {
            return await _dataContext.InhabilitacionEstudiante
                .Include(x => x.Estudiante)
                .SingleOrDefaultAsync(x => x.EstudianteId == estudianteId);
        }
    }
}
