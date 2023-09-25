using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.InstructorDomain;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class InstructorProgramaAnaliticoService : IInstructorProgramaAnaliticoService
    {
        private readonly DataContext _dataContext;

        public InstructorProgramaAnaliticoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<InstructorProgramaAnalitico>> GetInstructorProgramaAnaliticosAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.InstructorProgramaAnalitico.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<InstructorProgramaAnalitico> GetInstructorProgramaAnaliticoByIdAsync(int instructorId, int programaAnaliticoId)
        {
            return await _dataContext
                .InstructorProgramaAnalitico
                .Include(x => x.Instructor)
                .Include(x => x.ProgramaAnaliticoPdf)
                .ThenInclude(x => x.Materia)
                .SingleOrDefaultAsync(x => x.InstructorId == instructorId && x.ProgramaAnaliticoPdfId == programaAnaliticoId);
        }

        public async Task<bool> CreateInstructorProgramaAnaliticoAsync(InstructorProgramaAnalitico instructorProgramaAnalitico)
        {
            await _dataContext.InstructorProgramaAnalitico.AddAsync(instructorProgramaAnalitico);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateInstructorProgramaAnaliticoAsync(InstructorProgramaAnalitico instructorProgramaAnalitico)
        {
            _dataContext.InstructorProgramaAnalitico.Update(instructorProgramaAnalitico);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteInstructorProgramaAnaliticoAsync(int instructorId, int programaAnaliticoId)
        {
            var instructorProgramaAnalitico = await GetInstructorProgramaAnaliticoByIdAsync(instructorId, programaAnaliticoId);

            if (instructorProgramaAnalitico == null)
            {
                return false;
            }

            _dataContext.InstructorProgramaAnalitico.Remove(instructorProgramaAnalitico);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<List<InstructorProgramaAnalitico>> GetInstructorProgramaAnaliticosByInstructorIdAsync(int instructorId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext
                .InstructorProgramaAnalitico
                .Include(x => x.Instructor)
                .Include(x => x.ProgramaAnaliticoPdf)
                .ThenInclude(x => x.Materia)
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
