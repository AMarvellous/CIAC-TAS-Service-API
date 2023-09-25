using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;
using CIAC_TAS_Service.Domain.Estudiante;

namespace CIAC_TAS_Service.Services
{
    public class ProgramaAnaliticoPdfService : IProgramaAnaliticoPdfService
    {
        private readonly DataContext _dataContext;

        public ProgramaAnaliticoPdfService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ProgramaAnaliticoPdf>> GetProgramaAnaliticoPdfsAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext
                .ProgramaAnaliticoPdf
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

        public async Task<ProgramaAnaliticoPdf> GetProgramaAnaliticoPdfByIdAsync(int id)
        {
            return await _dataContext.ProgramaAnaliticoPdf.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateProgramaAnaliticoPdfAsync(ProgramaAnaliticoPdf programaAnaliticoPdf)
        {
            await _dataContext.ProgramaAnaliticoPdf.AddAsync(programaAnaliticoPdf);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateProgramaAnaliticoPdfAsync(ProgramaAnaliticoPdf programaAnaliticoPdf)
        {
            _dataContext.ProgramaAnaliticoPdf.Update(programaAnaliticoPdf);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteProgramaAnaliticoPdfAsync(int programaAnaliticoPdfId)
        {
            var programaAnaliticoPdf = await GetProgramaAnaliticoPdfByIdAsync(programaAnaliticoPdfId);

            if (programaAnaliticoPdf == null)
            {
                return false;
            }

            _dataContext.ProgramaAnaliticoPdf.Remove(programaAnaliticoPdf);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<List<ProgramaAnaliticoPdf>> GetAllNotAssignedInstructorAsync(int instructorId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.ProgramaAnaliticoPdf
                .Where(p => !_dataContext.InstructorProgramaAnalitico
                    .Where(x => x.InstructorId == instructorId)
                    .Select(ipa => ipa.ProgramaAnaliticoPdfId)
                    .Contains(p.Id))
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
    }
}
