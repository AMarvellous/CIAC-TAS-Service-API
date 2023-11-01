using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IRegistroNotaEstudianteHeaderService
    {
        Task<List<RegistroNotaEstudianteHeader>> GetRegistroNotaEstudianteHeadersAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateRegistroNotaEstudianteHeaderAsync(RegistroNotaEstudianteHeader registroNotaEstudianteHeader);
        Task<RegistroNotaEstudianteHeader> GetRegistroNotaEstudianteHeaderByIdAsync(int id);
        Task<bool> UpdateRegistroNotaEstudianteHeaderAsync(RegistroNotaEstudianteHeader registroNotaEstudianteHeader);
        Task<bool> DeleteRegistroNotaEstudianteHeaderAsync(int id);
        Task<List<RegistroNotaEstudianteHeader>> GetRegistroNotaEstudianteHeadersByRegistroNotaHeaderIdAsync(int registroNotaHeaderId, PaginationFilter paginationFilter = null);
    }
}
