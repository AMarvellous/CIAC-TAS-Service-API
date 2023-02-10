using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class RespuestasAsaConsolidadoService : IRespuestasAsaConsolidadoService
    {
        private readonly DataContext _dataContext;

        public RespuestasAsaConsolidadoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }                

        public async Task<List<RespuestasAsaConsolidado>> GetRespuestasAsasConsolidadoByUserIdAsync(string userId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.RespuestasAsaConsolidado
                .Where(x => x.UserId == userId)
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

        public async Task<bool> CreateRespuestasAsaBatchAsync(List<RespuestasAsaConsolidado> respuestasAsaConsolidado)
        {
            await _dataContext.RespuestasAsaConsolidado.AddRangeAsync(respuestasAsaConsolidado);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
    }
}
