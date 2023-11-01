using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class RegistroNotaEstudianteHeaderService : IRegistroNotaEstudianteHeaderService
    {
        private readonly DataContext _dataContext;

        public RegistroNotaEstudianteHeaderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<RegistroNotaEstudianteHeader>> GetRegistroNotaEstudianteHeadersAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.RegistroNotaEstudianteHeader
                .Include(x => x.Estudiante)
                .Include(x => x.RegistroNotaHeader)
                .Include(x => x.RegistroNotaEstudiantes)
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

        public async Task<RegistroNotaEstudianteHeader> GetRegistroNotaEstudianteHeaderByIdAsync(int id)
        {
            return await _dataContext.RegistroNotaEstudianteHeader
                .Include(x => x.Estudiante)
                .Include(x => x.RegistroNotaHeader)
                .Include(x => x.RegistroNotaEstudiantes)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateRegistroNotaEstudianteHeaderAsync(RegistroNotaEstudianteHeader registroNotaEstudianteHeader)
        {
            await _dataContext.RegistroNotaEstudianteHeader.AddAsync(registroNotaEstudianteHeader);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateRegistroNotaEstudianteHeaderAsync(RegistroNotaEstudianteHeader registroNotaEstudianteHeader)
        {
            _dataContext.RegistroNotaEstudianteHeader.Update(registroNotaEstudianteHeader);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteRegistroNotaEstudianteHeaderAsync(int registroNotaEstudianteHeaderId)
        {
            var registroNotaEstudianteHeader = await GetRegistroNotaEstudianteHeaderByIdAsync(registroNotaEstudianteHeaderId);

            if (registroNotaEstudianteHeader == null)
            {
                return false;
            }

            _dataContext.RegistroNotaEstudianteHeader.Remove(registroNotaEstudianteHeader);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<List<RegistroNotaEstudianteHeader>> GetRegistroNotaEstudianteHeadersByRegistroNotaHeaderIdAsync(int registroNotaHeaderId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.RegistroNotaEstudianteHeader
                .Where(x => x.RegistroNotaHeaderId == registroNotaHeaderId)
                .Include(x => x.Estudiante)
                .Include(x => x.RegistroNotaHeader)
                .Include(x => x.RegistroNotaEstudiantes)
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
