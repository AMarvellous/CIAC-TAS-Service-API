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
    public interface IGrupoPreguntaAsaServiceApi
    {
        [Get("/" + GrupoPreguntaAsas.GetAll)]
        Task<ApiResponse<PagedResponse<GrupoPreguntaAsaResponse>>> GetAllAsync();

        [Get("/" + GrupoPreguntaAsas.Get)]
        Task<ApiResponse<GrupoPreguntaAsaResponse>> GetAsync(int grupoPreguntaAsaId);

        [Post("/" + GrupoPreguntaAsas.Create)]
        Task<ApiResponse<GrupoPreguntaAsaResponse>> CreateAsync([Body] CreateGrupoPreguntaAsaRequest grupoPreguntaAsaRequest);

        [Put("/" + GrupoPreguntaAsas.Update)]
        Task<ApiResponse<GrupoPreguntaAsaResponse>> UpdateAsync(int grupoPreguntaAsaId, [Body] UpdateGrupoPreguntaAsaRequest grupoPreguntaAsaRequest);

        [Delete("/" + GrupoPreguntaAsas.Delete)]
        Task<ApiResponse<GrupoPreguntaAsaResponse>> DeleteAsync(int grupoPreguntaAsaId);
    }
}
