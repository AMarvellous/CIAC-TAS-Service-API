using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Responses;
using Refit;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Sdk
{
    [Headers("Authorization: Bearer")]
    public interface ITipoRegistroNotaHeaderServiceApi
    {
        [Get("/" + TipoRegistroNotaHeaders.GetAll)]
        Task<ApiResponse<PagedResponse<TipoRegistroNotaHeaderResponse>>> GetAllAsync();

        [Get("/" + TipoRegistroNotaHeaders.Get)]
        Task<ApiResponse<TipoRegistroNotaHeaderResponse>> GetAsync(int tipoRegistroNotaHeaderId);

        [Post("/" + TipoRegistroNotaHeaders.Create)]
        Task<ApiResponse<TipoRegistroNotaHeaderResponse>> CreateAsync([Body] CreateTipoRegistroNotaHeaderRequest tipoRegistroNotaHeaderRequest);

        [Put("/" + TipoRegistroNotaHeaders.Update)]
        Task<ApiResponse<TipoRegistroNotaHeaderResponse>> UpdateAsync(int tipoRegistroNotaHeaderId, [Body] UpdateTipoRegistroNotaHeaderRequest tipoRegistroNotaHeaderRequest);

        [Delete("/" + TipoRegistroNotaHeaders.Delete)]
        Task<ApiResponse<TipoRegistroNotaHeaderResponse>> DeleteAsync(int tipoRegistroNotaHeaderId);
    }
}
