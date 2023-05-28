using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IAsistenciaEstudianteHeaderService
    {
        Task<List<AsistenciaEstudianteHeader>> GetAsistenciaEstudianteHeadersAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateAsistenciaEstudianteHeaderAsync(AsistenciaEstudianteHeader asistenciaEstudianteHeader);
        Task<AsistenciaEstudianteHeader> GetAsistenciaEstudianteHeaderByIdAsync(int id);
        Task<bool> UpdateAsistenciaEstudianteHeaderAsync(AsistenciaEstudianteHeader asistenciaEstudianteHeader);
        Task<bool> DeleteAsistenciaEstudianteHeaderAsync(int id);
        Task<List<AsistenciaEstudianteHeader>> GetAsistenciaEstudianteHeadersByGrupoIdMateriaIdAsync(int grupoId, int materiaId, PaginationFilter paginationFilter = null);
    }
}
