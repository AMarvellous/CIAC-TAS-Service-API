using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IAsistenciaEstudianteService
    {
        Task<List<AsistenciaEstudiante>> GetAsistenciaEstudiantesAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateAsistenciaEstudianteAsync(AsistenciaEstudiante asistenciaEstudiante);
        Task<AsistenciaEstudiante> GetAsistenciaEstudianteByIdAsync(int id);
        Task<bool> UpdateAsistenciaEstudianteAsync(AsistenciaEstudiante asistenciaEstudiante);
        Task<bool> DeleteAsistenciaEstudianteAsync(int id);
    }
}
