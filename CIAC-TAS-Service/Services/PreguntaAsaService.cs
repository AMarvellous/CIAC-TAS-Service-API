using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class PreguntaAsaService : IPreguntaAsaService
    {
        private readonly DataContext _dataContext;

        public PreguntaAsaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<PreguntaAsa>> GetPreguntaAsasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.PreguntaAsa.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<PreguntaAsa> GetPreguntaAsaByIdAsync(int id)
        {
            return await _dataContext.PreguntaAsa.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreatePreguntaAsaAsync(PreguntaAsa preguntaAsa)
        {
            await _dataContext.PreguntaAsa.AddAsync(preguntaAsa);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdatePreguntaAsaAsync(PreguntaAsa preguntaAsa)
        {
            _dataContext.PreguntaAsa.Update(preguntaAsa);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeletePreguntaAsaAsync(int preguntaAsaId)
        {
            var preguntaAsa = await GetPreguntaAsaByIdAsync(preguntaAsaId);

            if (preguntaAsa == null)
            {
                return false;
            }

            _dataContext.PreguntaAsa.Remove(preguntaAsa);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CheckExistsPreguntaAsaAsync(int preguntaAsaId)
        {
            return await _dataContext.PreguntaAsa.SingleOrDefaultAsync(x => x.Id == preguntaAsaId) != null;
        }
    }
}
