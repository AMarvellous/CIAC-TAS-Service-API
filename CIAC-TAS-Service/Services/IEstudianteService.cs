using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Estudiante;

namespace CIAC_TAS_Service.Services
{
    public interface IEstudianteService
    {
        Task<List<Estudiante>> GetEstudiantesAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateEstudianteAsync(Estudiante estudiante);
        Task<Estudiante> GetEstudianteByIdAsync(int id);
        Task<Estudiante> GetEstudianteByUserIdAsync(string userId);
        Task<bool> UpdateEstudianteAsync(Estudiante estudiante);
        Task<bool> DeleteEstudianteAsync(int id);
        Task<bool> CheckUserIdIsAssignedAsync(string userId);
        Task<bool> CheckUserIdIsAssignableToThisEstudianteAsync(int estudianteId, string proposedUserId);
        Task<List<Estudiante>> GetAllNotAssignedToGrupoAsync(int grupoId, PaginationFilter paginationFilter = null);
    }
}
