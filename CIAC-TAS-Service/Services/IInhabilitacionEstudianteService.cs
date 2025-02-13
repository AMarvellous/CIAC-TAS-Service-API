using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IInhabilitacionEstudianteService
    {
        Task<List<InhabilitacionEstudiante>> GetInhabilitacionEstudiantesAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateInhabilitacionEstudianteAsync(InhabilitacionEstudiante inhabilitacionEstudiante);
        Task<InhabilitacionEstudiante> GetInhabilitacionEstudianteByIdAsync(int id);
        Task<bool> UpdateInhabilitacionEstudianteAsync(InhabilitacionEstudiante inhabilitacionEstudiante);
        Task<bool> DeleteInhabilitacionEstudianteAsync(int id);
        Task<InhabilitacionEstudiante> GetInhabilitacionEstudianteByEstudianteIdAsync(int estudianteId);
    }
}
