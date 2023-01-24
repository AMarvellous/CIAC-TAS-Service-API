using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class PreguntaAsaImagenAsaService : IPreguntaAsaImagenAsaService
    {
        private readonly DataContext _dataContext;

        public PreguntaAsaImagenAsaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<PreguntaAsaImagenAsa>> GetPreguntaAsaImagenAsasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.PreguntaAsaImagenAsa.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<PreguntaAsaImagenAsa> GetPreguntaAsaImagenAsaByIdAsync(int preguntaAsaId, int imagenAsaId)
        {
            return await _dataContext.PreguntaAsaImagenAsa.SingleOrDefaultAsync(x => x.PreguntaAsaId == preguntaAsaId && x.ImagenAsaId == imagenAsaId);
        }

        public async Task<bool> CreatePreguntaAsaImagenAsaAsync(PreguntaAsaImagenAsa preguntaAsaImagenAsa)
        {
            await _dataContext.PreguntaAsaImagenAsa.AddAsync(preguntaAsaImagenAsa);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> DeletePreguntaAsaImagenAsaAsync(int preguntaAsaId, int imagenAsaId)
        {
            var preguntaAsaImagenAsa = await GetPreguntaAsaImagenAsaByIdAsync(preguntaAsaId, imagenAsaId);

            if (preguntaAsaImagenAsa == null)
            {
                return false;
            }

            _dataContext.PreguntaAsaImagenAsa.Remove(preguntaAsaImagenAsa);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CheckPreguntaAsaImagenAsaExistsAsync(int preguntaAsaId, int imagenAsaId)
        {
            return await _dataContext.PreguntaAsaImagenAsa
                .SingleOrDefaultAsync(x => x.PreguntaAsaId == preguntaAsaId && x.ImagenAsaId == imagenAsaId) != null;
        }
    }
}
