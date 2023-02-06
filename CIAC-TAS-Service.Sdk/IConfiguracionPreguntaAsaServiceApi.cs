using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Responses;
using Refit;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Sdk
{
    [Headers("Authorization: Bearer")]
    public interface IConfiguracionPreguntaAsaServiceApi
    {
        [Get("/" + ConfiguracionPreguntaAsas.GetAll)]
        Task<ApiResponse<PagedResponse<ConfiguracionPreguntaAsaResponse>>> GetAllAsync();

        [Get("/" + ConfiguracionPreguntaAsas.Get)]
        Task<ApiResponse<ConfiguracionPreguntaAsaResponse>> GetAsync(int configuracionPreguntaAsaId);

        [Post("/" + ConfiguracionPreguntaAsas.Create)]
        Task<ApiResponse<ConfiguracionPreguntaAsaResponse>> CreateAsync([Body] CreateConfiguracionPreguntaAsaRequest configuracionPreguntaAsaRequest);

        [Put("/" + ConfiguracionPreguntaAsas.Update)]
        Task<ApiResponse<ConfiguracionPreguntaAsaResponse>> UpdateAsync(int configuracionPreguntaAsaId, [Body] UpdateConfiguracionPreguntaAsaRequest configuracionPreguntaAsaRequest);
        
        [Delete("/" + ConfiguracionPreguntaAsas.Delete)]
        Task<ApiResponse<ConfiguracionPreguntaAsaResponse>> DeleteAsync(int configuracionPreguntaAsaId);
    }
}
