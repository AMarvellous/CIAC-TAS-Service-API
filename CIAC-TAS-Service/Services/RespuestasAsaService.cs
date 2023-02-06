using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class RespuestasAsaService : IRespuestasAsaService
    {
        private readonly DataContext _dataContext;

        public RespuestasAsaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<RespuestasAsa>> GetRespuestasAsasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.RespuestasAsas.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<RespuestasAsa> GetRespuestasAsaByIdAsync(int id)
        {
            return await _dataContext.RespuestasAsas.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateRespuestasAsaAsync(RespuestasAsa respuestasAsa)
        {
            await _dataContext.RespuestasAsas.AddAsync(respuestasAsa);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateRespuestasAsaAsync(RespuestasAsa respuestasAsa)
        {
            _dataContext.RespuestasAsas.Update(respuestasAsa);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteRespuestasAsaAsync(int respuestasAsaId)
        {
            var respuestasAsa = await GetRespuestasAsaByIdAsync(respuestasAsaId);

            if (respuestasAsa == null)
            {
                return false;
            }

            _dataContext.RespuestasAsas.Remove(respuestasAsa);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
