using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IRegistroNotaEstudianteService
    {
        Task<List<RegistroNotaEstudiante>> GetRegistroNotaEstudiantesAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateRegistroNotaEstudianteAsync(RegistroNotaEstudiante registroNotaEstudiante);
        Task<RegistroNotaEstudiante> GetRegistroNotaEstudianteByIdAsync(int id);
        Task<bool> UpdateRegistroNotaEstudianteAsync(RegistroNotaEstudiante registroNotaEstudiante);
        Task<bool> DeleteRegistroNotaEstudianteAsync(int id);
        Task<List<RegistroNotaEstudiante>> GetRegistroNotaEstudiantesByRegistroNotaEstudianteHeaderIdAsync(int registroNotaEstudianteHeaderId, PaginationFilter paginationFilter = null);
    }
}
