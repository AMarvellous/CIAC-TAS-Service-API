using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
	public interface IExamenGeneradoService
	{
		Task<List<ExamenGenerado>> GetExamenGeneradosAsync(PaginationFilter paginationFilter = null);
		Task<bool> CreateExamenGeneradoAsync(ExamenGenerado examenGenerado);
		Task<ExamenGenerado> GetExamenGeneradoByIdAsync(int id);
		Task<bool> UpdateExamenGeneradoAsync(ExamenGenerado examenGenerado);
		Task<bool> DeleteExamenGeneradoAsync(int id);
		Task<List<ExamenGenerado>> CreateExamenGeneradoRandomAsync(int grupoId, int numeroPreguntas);
		Task<List<ExamenGenerado>> GetExamenGeneradosByGrupoGuidAsync(int grupoId, Guid examenGeneradoGuid, PaginationFilter paginationFilter = null);
        Task<List<ExamenGenerado>> GetExamenGeneradosHeadersAsync(PaginationFilter paginationFilter = null);
    }
}
