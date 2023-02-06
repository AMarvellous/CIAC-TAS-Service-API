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
    public interface IEstadoPreguntaAsaServiceApi
    {
        [Get("/" + EstadoPreguntaAsas.GetAll)]
        Task<ApiResponse<PagedResponse<EstadoPreguntaAsaResponse>>> GetAllAsync();

        [Get("/" + EstadoPreguntaAsas.Get)]
        Task<ApiResponse<EstadoPreguntaAsaResponse>> GetAsync(int estadoPreguntaAsaId);

        [Post("/" + EstadoPreguntaAsas.Create)]
        Task<ApiResponse<EstadoPreguntaAsaResponse>> CreateAsync([Body] CreateEstadoPreguntaAsaRequest estadoPreguntaAsaGrupoRequest);

        [Delete("/" + EstadoPreguntaAsas.Delete)]
        Task<ApiResponse<EstadoPreguntaAsaResponse>> DeleteAsync(int estadoPreguntaAsaId);
    }
}
