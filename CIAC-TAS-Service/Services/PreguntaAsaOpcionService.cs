using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class PreguntaAsaOpcionService : IPreguntaAsaOpcionService
    {
        private readonly DataContext _dataContext;

        public PreguntaAsaOpcionService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<PreguntaAsaOpcion>> GetPreguntaAsaOpcionsAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.PreguntaAsaOpcion.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<PreguntaAsaOpcion> GetPreguntaAsaOpcionByIdAsync(int id)
        {
            return await _dataContext.PreguntaAsaOpcion.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreatePreguntaAsaOpcionAsync(PreguntaAsaOpcion preguntaAsaOpcion)
        {
            await _dataContext.PreguntaAsaOpcion.AddAsync(preguntaAsaOpcion);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdatePreguntaAsaOpcionAsync(PreguntaAsaOpcion preguntaAsaOpcion)
        {
            _dataContext.PreguntaAsaOpcion.Update(preguntaAsaOpcion);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeletePreguntaAsaOpcionAsync(int preguntaAsaOpcionId)
        {
            var preguntaAsaOpcion = await GetPreguntaAsaOpcionByIdAsync(preguntaAsaOpcionId);

            if (preguntaAsaOpcion == null)
            {
                return false;
            }

            _dataContext.PreguntaAsaOpcion.Remove(preguntaAsaOpcion);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CheckPreguntaAsaOpcionExistsAsync(int id)
        {
            return await _dataContext.PreguntaAsaOpcion.SingleOrDefaultAsync(x => x.Id == id) != null;
        }
    }
}
