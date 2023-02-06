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
    public interface IPreguntaAsaImagenAsaServiceApi
    {
        [Get("/" + PreguntaAsaImagenAsas.GetAll)]
        Task<ApiResponse<PagedResponse<PreguntaAsaImagenAsaResponse>>> GetAllAsync();

        [Get("/" + PreguntaAsaImagenAsas.Get)]
        Task<ApiResponse<PreguntaAsaImagenAsaResponse>> GetAsync(int preguntaAsaId, int imagenAsaId);

        [Post("/" + PreguntaAsaImagenAsas.Create)]
        Task<ApiResponse<PreguntaAsaImagenAsaResponse>> CreateAsync([Body] CreatePreguntaAsaImagenAsaRequest preguntaAsaImagenAsaRequest);

        [Delete("/" + PreguntaAsaImagenAsas.Delete)]
        Task<ApiResponse<PreguntaAsaImagenAsaResponse>> DeleteAsync(int preguntaAsaId, int imagenAsaId);
    }
}
