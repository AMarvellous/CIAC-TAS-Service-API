using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IProgramaAnaliticoPdfService
    {
        Task<List<ProgramaAnaliticoPdf>> GetProgramaAnaliticoPdfsAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateProgramaAnaliticoPdfAsync(ProgramaAnaliticoPdf programaAnaliticoPdf);
        Task<ProgramaAnaliticoPdf> GetProgramaAnaliticoPdfByIdAsync(int id);
        Task<bool> UpdateProgramaAnaliticoPdfAsync(ProgramaAnaliticoPdf programaAnaliticoPdf);
        Task<bool> DeleteProgramaAnaliticoPdfAsync(int id);
        Task<List<ProgramaAnaliticoPdf>> GetAllNotAssignedInstructorAsync(int instructorId, PaginationFilter paginationFilter = null);
    }
}
