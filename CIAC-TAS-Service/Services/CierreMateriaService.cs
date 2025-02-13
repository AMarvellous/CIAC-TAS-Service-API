using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class CierreMateriaService : ICierreMateriaService
    {
        private readonly DataContext _dataContext;

        public CierreMateriaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<CierreMateria>> GetCierreMateriasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.CierreMateria
                .Include(x => x.Grupo)
                .Include(x => x.Materia)
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

        public async Task<CierreMateria> GetCierreMateriaByIdAsync(int id)
        {
            return await _dataContext.CierreMateria
                .Include(x => x.Grupo)
                .Include(x => x.Materia)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateCierreMateriaAsync(CierreMateria cierreMateria)
        {
            await _dataContext.CierreMateria.AddAsync(cierreMateria);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateCierreMateriaAsync(CierreMateria cierreMateria)
        {
            _dataContext.CierreMateria.Update(cierreMateria);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteCierreMateriaAsync(int cierreMateriaId)
        {
            var cierreMateria = await GetCierreMateriaByIdAsync(cierreMateriaId);

            if (cierreMateria == null)
            {
                return false;
            }

            _dataContext.CierreMateria.Remove(cierreMateria);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<CierreMateria> GetByGrupoIdMateriaId(int grupoId, int materiaId)
        {
            return await _dataContext.CierreMateria
                .Include(x => x.Grupo)
                .Include(x => x.Materia)
                .SingleOrDefaultAsync(x => x.GrupoId == grupoId && x.MateriaId == materiaId);
        }
    }
}
