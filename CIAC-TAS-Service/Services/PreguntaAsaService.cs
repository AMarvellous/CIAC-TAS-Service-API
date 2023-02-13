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
            var queryable = _dataContext.PreguntaAsa
                .Include(x => x.GrupoPreguntaAsa)
                .AsQueryable();
                //.Include(x => x.EstadoPreguntaAsa);

            if (paginationFilter == null)
            {
                return await queryable
                    .ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable
                .Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<PreguntaAsa> GetPreguntaAsaByIdAsync(int id)
        {
            return await _dataContext.PreguntaAsa
                .Include(x => x.GrupoPreguntaAsa)
                .Include(x => x.EstadoPreguntaAsa)
                .Include(x => x.PreguntaAsaOpciones)
                .SingleOrDefaultAsync(x => x.Id == id);
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

        public async Task<List<PreguntaAsa>> GetRandomGeneratedPreguntasAsaAsync(int numeroPreguntas, int preguntaIni, int preguntaFin, List<int> grupoPreguntaAsaIds, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.PreguntaAsa
                .Where(x => x.EstadoPreguntaAsaId != 2) // Avoid estado Inactive
                .Include(x => x.GrupoPreguntaAsa)
                .AsQueryable();

            if (grupoPreguntaAsaIds.Count() > 0)
            {
                queryable = queryable.Where(x => grupoPreguntaAsaIds.Contains(x.GrupoPreguntaAsaId));
            }

            if (preguntaIni > 0)
            {
                queryable = queryable.Where(x => x.NumeroPregunta >= preguntaIni);
            }

            if (preguntaFin > 0)
            {
                queryable = queryable.Where(x => x.NumeroPregunta <= preguntaFin);
            }

            if (numeroPreguntas > 0)
            {
                Random random = new Random();
                queryable = queryable.OrderByDescending(x => Guid.NewGuid()).Take(numeroPreguntas);
            }


            if (paginationFilter == null)
            {
                return await queryable
                    .ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable
                .Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }
    }
}
