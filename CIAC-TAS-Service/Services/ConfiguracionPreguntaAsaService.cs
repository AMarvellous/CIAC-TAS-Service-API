using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class ConfiguracionPreguntaAsaService : IConfiguracionPreguntaAsaService
    {
        private readonly DataContext _dataContext;

        public ConfiguracionPreguntaAsaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ConfiguracionPreguntaAsa>> GetConfiguracionPreguntaAsasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.ConfiguracionPreguntaAsa.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<ConfiguracionPreguntaAsa> GetConfiguracionPreguntaAsaByIdAsync(int id)
        {
            return await _dataContext.ConfiguracionPreguntaAsa.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateConfiguracionPreguntaAsaAsync(ConfiguracionPreguntaAsa configuracionPreguntaAsa)
        {
            await _dataContext.ConfiguracionPreguntaAsa.AddAsync(configuracionPreguntaAsa);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateConfiguracionPreguntaAsaAsync(ConfiguracionPreguntaAsa configuracionPreguntaAsa)
        {
            _dataContext.ConfiguracionPreguntaAsa.Update(configuracionPreguntaAsa);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteConfiguracionPreguntaAsaAsync(int configuracionPreguntaAsaId)
        {
            var configuracionPreguntaAsa = await GetConfiguracionPreguntaAsaByIdAsync(configuracionPreguntaAsaId);

            if (configuracionPreguntaAsa == null)
            {
                return false;
            }

            _dataContext.ConfiguracionPreguntaAsa.Remove(configuracionPreguntaAsa);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CheckConfiguracionPreguntaAsaExistsAsync(int id)
        {
            return await _dataContext.ConfiguracionPreguntaAsa.SingleOrDefaultAsync(x => x.Id == id) != null;
        }
    }
}
