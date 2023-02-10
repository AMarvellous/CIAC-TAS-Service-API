using CIAC_TAS_Service.Contracts.V1.Requests;
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
    public interface IPreguntaAsaServiceApi
    {
        [Get("/" + PreguntaAsas.GetAll)]
        Task<ApiResponse<PagedResponse<PreguntaAsaResponse>>> GetAllAsync();

        [Get("/" + PreguntaAsas.Get)]
        Task<ApiResponse<PreguntaAsaResponse>> GetAsync(int preguntaAsaId);

        [Post("/" + PreguntaAsas.Create)]
        Task<ApiResponse<PreguntaAsaResponse>> CreateAsync([Body] CreatePreguntaAsaRequest preguntaAsaRequest);

        [Put("/" + PreguntaAsas.Update)]
        Task<ApiResponse<PreguntaAsaResponse>> UpdateAsync(int preguntaAsaId, [Body] UpdatePreguntaAsaRequest preguntaAsaRequest);

        [Delete("/" + PreguntaAsas.Delete)]
        Task<ApiResponse<PreguntaAsaResponse>> DeleteAsync(int preguntaAsaId);

        [Get("/" + PreguntaAsas.GetRandomPreguntasAsa)]
        Task<ApiResponse<PagedResponse<PreguntaAsaResponse>>> GetPreguntasRandomAsync(int numeroPreguntas, int preguntaIni, int preguntaFin, [Query(CollectionFormat.Multi)] List<int> grupoPreguntaAsaIds);
    }
}
