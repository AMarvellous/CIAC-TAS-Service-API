using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Responses;
using Refit;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Sdk
{
    [Headers("Authorization: Bearer")]
    public interface ITipoAsistenciaServiceApi
    {
        [Get("/" + TipoAsistencias.GetAll)]
        Task<ApiResponse<PagedResponse<TipoAsistenciaResponse>>> GetAllAsync();

        [Get("/" + TipoAsistencias.Get)]
        Task<ApiResponse<TipoAsistenciaResponse>> GetAsync(int tipoAsistenciaId);

        [Post("/" + TipoAsistencias.Create)]
        Task<ApiResponse<TipoAsistenciaResponse>> CreateAsync([Body] CreateTipoAsistenciaRequest tipoAsistenciaRequest);

        [Put("/" + TipoAsistencias.Update)]
        Task<ApiResponse<TipoAsistenciaResponse>> UpdateAsync(int tipoAsistenciaId, [Body] UpdateTipoAsistenciaRequest tipoAsistenciaRequest);

        [Delete("/" + TipoAsistencias.Delete)]
        Task<ApiResponse<TipoAsistenciaResponse>> DeleteAsync(int tipoAsistenciaId);
    }
}
