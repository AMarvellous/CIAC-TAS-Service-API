using CIAC_TAS_Service.Domain.InstructorDomain;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IInstructorMateriaService
    {
        Task<List<InstructorMateria>> GetInstructorMateriasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateInstructorMateriaAsync(InstructorMateria instructorMateria);
        Task<InstructorMateria> GetInstructorMateriaByIdAsync(int instructorId, int materiaId, int grupoId);
        Task<bool> UpdateInstructorMateriaAsync(InstructorMateria instructorMateria);
        Task<bool> DeleteInstructorMateriaAsync(int instructorId, int materiaId, int grupoId);
        Task<List<InstructorMateria>> GetInstructorMateriasByInstructorIdAsync(int instructorId, PaginationFilter paginationFilter = null);
    }
}
