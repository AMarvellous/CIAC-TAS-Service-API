using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.General;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class ProgramaService : IProgramaService
    {
        private readonly DataContext _dataContext;

        public ProgramaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Programa>> GetProgramasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.Programa.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<Programa> GetProgramaByIdAsync(int id)
        {
            return await _dataContext.Programa.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateProgramaAsync(Programa programa)
        {
            await _dataContext.Programa.AddAsync(programa);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateProgramaAsync(Programa programa)
        {
            _dataContext.Programa.Update(programa);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteProgramaAsync(int programaId)
        {
            var programa = await GetProgramaByIdAsync(programaId);

            if (programa == null)
            {
                return false;
            }

            _dataContext.Programa.Remove(programa);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
