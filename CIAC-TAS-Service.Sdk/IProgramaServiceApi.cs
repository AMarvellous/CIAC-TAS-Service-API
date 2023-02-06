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
    public interface IProgramaServiceApi
    {
        [Get("/" + Programas.GetAll)]
        Task<ApiResponse<PagedResponse<ProgramaResponse>>> GetAllAsync();

        [Get("/" + Programas.Get)]
        Task<ApiResponse<ProgramaResponse>> GetAsync(int programaId);

        [Post("/" + Programas.Create)]
        Task<ApiResponse<ProgramaResponse>> CreateAsync([Body] CreateProgramaRequest programaRequest);

        [Put("/" + Programas.Update)]
        Task<ApiResponse<ProgramaResponse>> UpdateAsync(int programaId, [Body] UpdateProgramaRequest programaRequest);

        [Delete("/" + Programas.Delete)]
        Task<ApiResponse<ProgramaResponse>> DeleteAsync(int programaId);
    }
}
