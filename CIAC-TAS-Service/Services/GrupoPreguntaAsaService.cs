using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class GrupoPreguntaAsaService : IGrupoPreguntaAsaService
    {
        private readonly DataContext _dataContext;

        public GrupoPreguntaAsaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<GrupoPreguntaAsa>> GetGrupoPreguntaAsasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.GrupoPreguntaAsa.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<GrupoPreguntaAsa> GetGrupoPreguntaAsaByIdAsync(int id)
        {
            return await _dataContext.GrupoPreguntaAsa.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateGrupoPreguntaAsaAsync(GrupoPreguntaAsa grupoPreguntaAsa)
        {
            await _dataContext.GrupoPreguntaAsa.AddAsync(grupoPreguntaAsa);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateGrupoPreguntaAsaAsync(GrupoPreguntaAsa grupoPreguntaAsa)
        {
            _dataContext.GrupoPreguntaAsa.Update(grupoPreguntaAsa);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteGrupoPreguntaAsaAsync(int grupoPreguntaAsaId)
        {
            var grupoPreguntaAsa = await GetGrupoPreguntaAsaByIdAsync(grupoPreguntaAsaId);

            if (grupoPreguntaAsa == null)
            {
                return false;
            }

            _dataContext.GrupoPreguntaAsa.Remove(grupoPreguntaAsa);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
