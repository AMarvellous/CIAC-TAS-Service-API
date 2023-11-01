using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IRegistroNotaHeaderService
    {
        Task<List<RegistroNotaHeader>> GetRegistroNotaHeadersAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateRegistroNotaHeaderAsync(RegistroNotaHeader registroNotaHeader);
        Task<RegistroNotaHeader> GetRegistroNotaHeaderByIdAsync(int id);
        Task<bool> UpdateRegistroNotaHeaderAsync(RegistroNotaHeader registroNotaHeader);
        Task<bool> DeleteRegistroNotaHeaderAsync(int id);
        Task<List<RegistroNotaHeader>> GetAsistenciaEstudianteHeadersByGrupoIdMateriaIdAsync(int grupoId, int materiaId, PaginationFilter paginationFilter = null);
        Task<bool> CreateRegistroNotaEstudianteHeaderAsync(RegistroNotaHeader registroNotaHeader);
    }
}
