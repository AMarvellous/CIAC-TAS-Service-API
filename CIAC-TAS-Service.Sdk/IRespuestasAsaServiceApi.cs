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
    public interface IRespuestasAsaServiceApi
    {
        [Get("/" + RespuestasAsas.GetAllByUserId)]
        Task<ApiResponse<PagedResponse<RespuestasAsaResponse>>> GetAllByUserIdAsync(string userId);

        [Get("/" + RespuestasAsas.Get)]
        Task<ApiResponse<RespuestasAsaResponse>> GetAsync(int respuestasAsaId);

        [Post("/" + RespuestasAsas.Create)]
        Task<ApiResponse<RespuestasAsaResponse>> CreateAsync([Body] CreateRespuestasAsaRequest respuestasAsaRequest);

        [Put("/" + RespuestasAsas.Update)]
        Task<ApiResponse<RespuestasAsaResponse>> UpdateAsync(int respuestasAsaId, [Body] UpdateRespuestasAsaRequest request);

        [Delete("/" + RespuestasAsas.Delete)]
        Task<ApiResponse<RespuestasAsaResponse>> DeleteAsync(int respuestasAsaId);

        [Post("/" + RespuestasAsas.CreateBatch)]
        Task<ApiResponse<List<RespuestasAsaResponse>>> CreateBatchAsync([Body] List<CreateRespuestasAsaRequest> respuestasAsaRequest);

        [Patch("/" + RespuestasAsas.Patch)]
        Task<ApiResponse<RespuestasAsaResponse>> PatchAsync(int respuestasAsaId, [Body] PatchRespuestasAsaRequest request);

        [Get("/" + RespuestasAsas.GetUserIdHasRespuestasAsa)]
        Task<ApiResponse<bool>> GetUserIdHasRespuestasAsaAsync(string userId);

		[Get("/" + RespuestasAsas.GetFirstByUserId)]
		Task<ApiResponse<RespuestasAsaResponse>> GetFirstByUserIdAsync(string userId);

        [Post("/" + RespuestasAsas.ProcessRespuestasAsa)]
        Task<ApiResponse<bool>> ProcessRespuestasAsaAsync(string userId);
    }
}
