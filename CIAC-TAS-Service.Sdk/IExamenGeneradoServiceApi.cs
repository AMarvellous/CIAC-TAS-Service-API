using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Sdk
{
	[Headers("Authorization: Bearer")]
	public interface IExamenGeneradoServiceApi
	{
		[Get("/" + ExamenGenerados.GetAll)]
		Task<ApiResponse<PagedResponse<ExamenGeneradoResponse>>> GetAllAsync();

		[Get("/" + ExamenGenerados.Get)]
		Task<ApiResponse<ExamenGeneradoResponse>> GetAsync(int examenGeneradoId);

		[Post("/" + ExamenGenerados.Create)]
		Task<ApiResponse<ExamenGeneradoResponse>> CreateAsync([Body] CreateExamenGeneradoRequest examenGeneradoRequest);

		[Put("/" + ExamenGenerados.Update)]
		Task<ApiResponse<ExamenGeneradoResponse>> UpdateAsync(int examenGeneradoId, [Body] UpdateExamenGeneradoRequest examenGeneradoRequest);

		[Delete("/" + ExamenGenerados.Delete)]
		Task<ApiResponse<ExamenGeneradoResponse>> DeleteAsync(int examenGeneradoId);

		[Post("/" + ExamenGenerados.CreatePreguntasExamenGenerado)]
		Task<ApiResponse<List<ExamenGeneradoResponse>>> CreatePreguntasExamenGeneradoAsync(int grupoId, int numeroPreguntas);

		[Get("/" + ExamenGenerados.GetExamenByGrupoGuid)]
		Task<ApiResponse<PagedResponse<ExamenGeneradoResponse>>> GetExamenByGrupoGuidAsync(int grupoId, Guid guid);

        [Get("/" + ExamenGenerados.GetExamenHeaders)]
        Task<ApiResponse<PagedResponse<ExamenGeneradoResponse>>> GetExamenHeadersAsync();
    }
}
