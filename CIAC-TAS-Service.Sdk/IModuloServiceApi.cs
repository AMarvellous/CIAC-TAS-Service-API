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
    public interface IModuloServiceApi
    {
        [Get("/" + Modulos.GetAll)]
        Task<ApiResponse<PagedResponse<ModuloResponse>>> GetAllAsync();

        [Get("/" + Modulos.Get)]
        Task<ApiResponse<ModuloResponse>> GetAsync(int moduloId);

        [Post("/" + Modulos.Create)]
        Task<ApiResponse<ModuloResponse>> CreateAsync([Body] CreateModuloRequest moduloRequest);

        [Put("/" + Modulos.Update)]
        Task<ApiResponse<ModuloResponse>> UpdateAsync(int moduloId, [Body] UpdateModuloRequest moduloRequest);

        [Delete("/" + Modulos.Delete)]
        Task<ApiResponse<ModuloResponse>> DeleteAsync(int moduloId);
    }
}
