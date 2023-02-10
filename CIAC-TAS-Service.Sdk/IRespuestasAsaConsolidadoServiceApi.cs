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
    public interface IRespuestasAsaconsolidadoServiceApi
    {
        [Get("/" + RespuestasAsasConsolidado.GetAllByUserId)]
        Task<ApiResponse<PagedResponse<RespuestasAsaConsolidadoResponse>>> GetAllByUserIdAsync(string userId);

        [Post("/" + RespuestasAsasConsolidado.CreateBatch)]
        Task<ApiResponse<List<RespuestasAsaConsolidadoResponse>>> CreateBatchAsync([Body] List<CreateRespuestasAsaConsolidadoRequest> respuestasAsaConsolidadoRequest);

    }
}
