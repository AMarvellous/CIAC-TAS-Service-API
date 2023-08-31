using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly DataContext _dataContext;

        public MateriaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Materia>> GetMateriasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.Materia.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<Materia> GetMateriaByIdAsync(int id)
        {
            return await _dataContext.Materia.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateMateriaAsync(Materia materia)
        {
            await _dataContext.Materia.AddAsync(materia);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateMateriaAsync(Materia materia)
        {
            _dataContext.Materia.Update(materia);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteMateriaAsync(int materiaId)
        {
            var materia = await GetMateriaByIdAsync(materiaId);

            if (materia == null)
            {
                return false;
            }

            _dataContext.Materia.Remove(materia);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<List<Materia>> GetAllNotAssignedMateriasAsync(int estudianteId, int grupoId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.Materia
                .Where(g => !_dataContext.EstudianteMateria
                    .Where(x => x.EstudianteId == estudianteId && x.GrupoId == grupoId) 
                    .Select(eg => eg.MateriaId)
                        .Contains(g.Id)
                ).AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }
    }
}
