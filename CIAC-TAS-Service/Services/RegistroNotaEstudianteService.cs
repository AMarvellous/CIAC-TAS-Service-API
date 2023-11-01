using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class RegistroNotaEstudianteService : IRegistroNotaEstudianteService
    {
        private readonly DataContext _dataContext;

        public RegistroNotaEstudianteService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<RegistroNotaEstudiante>> GetRegistroNotaEstudiantesAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.RegistroNotaEstudiante
                .Include(x => x.RegistroNotaEstudianteHeader)
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

        public async Task<RegistroNotaEstudiante> GetRegistroNotaEstudianteByIdAsync(int id)
        {
            return await _dataContext.RegistroNotaEstudiante
                .Include(x => x.RegistroNotaEstudianteHeader)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateRegistroNotaEstudianteAsync(RegistroNotaEstudiante registroNotaEstudiante)
        {
            await _dataContext.RegistroNotaEstudiante.AddAsync(registroNotaEstudiante);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateRegistroNotaEstudianteAsync(RegistroNotaEstudiante registroNotaEstudiante)
        {
            _dataContext.RegistroNotaEstudiante.Update(registroNotaEstudiante);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteRegistroNotaEstudianteAsync(int registroNotaEstudianteId)
        {
            var registroNotaEstudiante = await GetRegistroNotaEstudianteByIdAsync(registroNotaEstudianteId);

            if (registroNotaEstudiante == null)
            {
                return false;
            }

            _dataContext.RegistroNotaEstudiante.Remove(registroNotaEstudiante);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<List<RegistroNotaEstudiante>> GetRegistroNotaEstudiantesByRegistroNotaEstudianteHeaderIdAsync(int registroNotaEstudianteHeaderId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.RegistroNotaEstudiante
                .Where(x => x.RegistroNotaEstudianteHeaderId == registroNotaEstudianteHeaderId)
                .Include(x => x.RegistroNotaEstudianteHeader)
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
    }
}
