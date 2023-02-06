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
    public interface IImagenAsaServiceApi
    {
        [Get("/" + ImagenAsas.GetAll)]
        Task<ApiResponse<PagedResponse<ImagenAsaResponse>>> GetAllAsync();

        [Get("/" + ImagenAsas.Get)]
        Task<ApiResponse<ImagenAsaResponse>> GetAsync(int imagenAsaId);

        [Post("/" + ImagenAsas.Create)]
        Task<ApiResponse<ImagenAsaResponse>> CreateAsync([Body] CreateImagenAsaRequest imagenAsaRequest);

        [Put("/" + ImagenAsas.Update)]
        Task<ApiResponse<ImagenAsaResponse>> UpdateAsync(int imagenAsaId, [Body] UpdateImagenAsaRequest imagenAsaRequest);

        [Delete("/" + ImagenAsas.Delete)]
        Task<ApiResponse<ImagenAsaResponse>> DeleteAsync(int imagenAsaId);
    }
}
