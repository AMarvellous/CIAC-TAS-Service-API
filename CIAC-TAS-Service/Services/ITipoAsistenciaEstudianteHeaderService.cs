using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface ITipoAsistenciaEstudianteHeaderService
    {
        Task<List<TipoAsistenciaEstudianteHeader>> GetTipoAsistenciaEstudianteHeadersAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateTipoAsistenciaEstudianteHeaderAsync(TipoAsistenciaEstudianteHeader tipoAsistenciaEstudianteHeader);
        Task<TipoAsistenciaEstudianteHeader> GetTipoAsistenciaEstudianteHeaderByIdAsync(int id);
        Task<bool> UpdateTipoAsistenciaEstudianteHeaderAsync(TipoAsistenciaEstudianteHeader tipoAsistenciaEstudianteHeader);
        Task<bool> DeleteTipoAsistenciaEstudianteHeaderAsync(int id);
    }
}
