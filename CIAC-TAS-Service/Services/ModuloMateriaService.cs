using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Services
{
    public class ModuloMateriaService : IModuloMateriaService
    {
        private readonly DataContext _dataContext;

        public ModuloMateriaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ModuloMateria>> GetModuloMateriasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.ModuloMateria
                .Include(x => x.Materia)
                .Include(x => x.Modulo)
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

        public async Task<ModuloMateria> GetModuloMateriaByIdAsync(int moduloId, int materiaId)
        {
            return await _dataContext.ModuloMateria
                .Include(x => x.Materia)
                .Include(x => x.Modulo)
                .SingleOrDefaultAsync(x => x.ModuloId == moduloId && x.MateriaId == materiaId);
        }

        public async Task<bool> CreateModuloMateriaAsync(ModuloMateria moduloMateria)
        {
            await _dataContext.ModuloMateria.AddAsync(moduloMateria);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> DeleteModuloMateriaAsync(int moduloId, int materiaId)
        {
            var moduloMateria = await GetModuloMateriaByIdAsync(moduloId, materiaId);

            if (moduloMateria == null)
            {
                return false;
            }

            _dataContext.ModuloMateria.Remove(moduloMateria);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<ModuloMateria> GetModuloMateriaByMateriaIdAsync(int materiaId)
        {
            return await _dataContext.ModuloMateria
                .Include(x => x.Materia)
                .Include(x => x.Modulo)
                .SingleOrDefaultAsync(x => x.MateriaId == materiaId);
        }
    }
}
