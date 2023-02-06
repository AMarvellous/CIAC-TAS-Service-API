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
    public interface IPreguntaAsaOpcionServiceApi
    {
        [Get("/" + PreguntaAsaOpciones.GetAll)]
        Task<ApiResponse<PagedResponse<PreguntaAsaOpcionResponse>>> GetAllAsync();

        [Get("/" + PreguntaAsaOpciones.Get)]
        Task<ApiResponse<PreguntaAsaOpcionResponse>> GetAsync(int preguntaAsaOpcionId);

        [Post("/" + PreguntaAsaOpciones.Create)]
        Task<ApiResponse<PreguntaAsaOpcionResponse>> CreateAsync([Body] CreatePreguntaAsaOpcionRequest preguntaAsaOpcionRequest);

        [Put("/" + PreguntaAsaOpciones.Update)]
        Task<ApiResponse<PreguntaAsaOpcionResponse>> UpdateAsync(int preguntaAsaOpcionId, [Body] UpdatePreguntaAsaOpcionRequest preguntaAsaOpcionRequest);

        [Delete("/" + PreguntaAsaOpciones.Delete)]
        Task<ApiResponse<PreguntaAsaOpcionResponse>> DeleteAsync(int preguntaAsaOpcionId);
    }
}
