using CIAC_TAS_Service.Domain.InstructorDomain;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IInstructorProgramaAnaliticoService
    {
        Task<List<InstructorProgramaAnalitico>> GetInstructorProgramaAnaliticosAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateInstructorProgramaAnaliticoAsync(InstructorProgramaAnalitico instructorProgramaAnalitico);
        Task<InstructorProgramaAnalitico> GetInstructorProgramaAnaliticoByIdAsync(int instructorId, int programaAnaliticoId);
        Task<bool> UpdateInstructorProgramaAnaliticoAsync(InstructorProgramaAnalitico instructorProgramaAnalitico);
        Task<bool> DeleteInstructorProgramaAnaliticoAsync(int instructorId, int programaAnaliticoId);
        Task<List<InstructorProgramaAnalitico>> GetInstructorProgramaAnaliticosByInstructorIdAsync(int instructorId, PaginationFilter paginationFilter = null);
    }
}
