using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface ITipoRegistroNotaEstudianteService
    {
        Task<List<TipoRegistroNotaEstudiante>> GetTipoRegistroNotaEstudiantesAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateTipoRegistroNotaEstudianteAsync(TipoRegistroNotaEstudiante tipoRegistroNotaEstudiante);
        Task<TipoRegistroNotaEstudiante> GetTipoRegistroNotaEstudianteByIdAsync(int id);
        Task<bool> UpdateTipoRegistroNotaEstudianteAsync(TipoRegistroNotaEstudiante tipoRegistroNotaEstudiante);
        Task<bool> DeleteTipoRegistroNotaEstudianteAsync(int id);
    }
}
