using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class EstadoPreguntaAsaService : IEstadoPreguntaAsaService
    {
        private readonly DataContext _dataContext;

        public EstadoPreguntaAsaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<EstadoPreguntaAsa>> GetEstadoPreguntaAsasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.EstadoPreguntaAsa.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<EstadoPreguntaAsa> GetEstadoPreguntaAsaByIdAsync(int id)
        {
            return await _dataContext.EstadoPreguntaAsa.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateEstadoPreguntaAsaAsync(EstadoPreguntaAsa estadoPreguntaAsa)
        {
            await _dataContext.EstadoPreguntaAsa.AddAsync(estadoPreguntaAsa);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateEstadoPreguntaAsaAsync(EstadoPreguntaAsa estadoPreguntaAsa)
        {
            _dataContext.EstadoPreguntaAsa.Update(estadoPreguntaAsa);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteEstadoPreguntaAsaAsync(int estadoPreguntaAsaId)
        {
            var estadoPreguntaAsa = await GetEstadoPreguntaAsaByIdAsync(estadoPreguntaAsaId);

            if (estadoPreguntaAsa == null)
            {
                return false;
            }

            _dataContext.EstadoPreguntaAsa.Remove(estadoPreguntaAsa);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CheckEstadoPreguntaAsaExists(int estadoPreguntaAsaId)
        {
            return await _dataContext.EstadoPreguntaAsa.SingleOrDefaultAsync(x => x.Id == estadoPreguntaAsaId) != null;
        }
    }
}
