using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.InstructorDomain;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class InstructorMateriaService : IInstructorMateriaService
    {
        private readonly DataContext _dataContext;

        public InstructorMateriaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<InstructorMateria>> GetInstructorMateriasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.InstructorMateria.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<InstructorMateria> GetInstructorMateriaByIdAsync(int instructorId, int materiaId, int grupoId)
        {
            return await _dataContext
                .InstructorMateria
                .SingleOrDefaultAsync(x => x.InstructorId == instructorId && x.MateriaId == materiaId && x.GrupoId == grupoId);
        }

        public async Task<bool> CreateInstructorMateriaAsync(InstructorMateria instructorMateria)
        {
            await _dataContext.InstructorMateria.AddAsync(instructorMateria);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateInstructorMateriaAsync(InstructorMateria instructorMateria)
        {
            _dataContext.InstructorMateria.Update(instructorMateria);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteInstructorMateriaAsync(int instructorId, int materiaId, int grupoId)
        {
            var instructorMateria = await GetInstructorMateriaByIdAsync(instructorId, materiaId, grupoId);

            if (instructorMateria == null)
            {
                return false;
            }

            _dataContext.InstructorMateria.Remove(instructorMateria);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<List<InstructorMateria>> GetInstructorMateriasByInstructorIdAsync(int instructorId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext
                .InstructorMateria
                .Include(x => x.Instructor)
                .Include(x => x.Materia)
                .Include(x => x.Grupo)
                .Where(x => x.InstructorId == instructorId)
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
    }
}
