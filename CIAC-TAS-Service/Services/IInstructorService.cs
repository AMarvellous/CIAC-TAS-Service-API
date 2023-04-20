using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IInstructorService
    {
        Task<List<Instructor>> GetInstructorsAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateInstructorAsync(Instructor instructor);
        Task<Instructor> GetInstructorByIdAsync(int id);
        Task<bool> UpdateInstructorAsync(Instructor instructor);
        Task<bool> DeleteInstructorAsync(int id);
        Task<bool> CheckUserIdIsAssignedAsync(string userId);
        Task<bool> CheckUserIdIsAssignableToThisInstructorAsync(int instructorId, string proposedUserId);
    }
}
