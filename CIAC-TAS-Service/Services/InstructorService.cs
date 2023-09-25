using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly DataContext _dataContext;

        public InstructorService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Instructor>> GetInstructorsAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.Instructor.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<Instructor> GetInstructorByIdAsync(int id)
        {
            return await _dataContext.Instructor.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateInstructorAsync(Instructor instructor)
        {
            await _dataContext.Instructor.AddAsync(instructor);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateInstructorAsync(Instructor instructor)
        {
            _dataContext.Instructor.Update(instructor);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteInstructorAsync(int instructorId)
        {
            var instructor = await GetInstructorByIdAsync(instructorId);

            if (instructor == null)
            {
                return false;
            }

            _dataContext.Instructor.Remove(instructor);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CheckUserIdIsAssignedAsync(string userId)
        {
            var user = await _dataContext.Instructor.AsNoTracking()
                .SingleOrDefaultAsync(x => x.UserId == userId);

            return user != null;
        }

        public async Task<bool> CheckUserIdIsAssignableToThisInstructorAsync(int instructorId, string proposedUserId)
        {
            var instructor = await _dataContext.Instructor.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == instructorId);

            if (proposedUserId == instructor.UserId)
            {
                return true;
            }

            return !await CheckUserIdIsAssignedAsync(proposedUserId);
        }

        public async Task<Instructor> GetInstructorByUserIdAsync(string userId)
        {
            return await _dataContext.Instructor.SingleOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
