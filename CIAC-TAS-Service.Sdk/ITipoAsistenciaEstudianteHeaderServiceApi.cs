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
    public interface ITipoAsistenciaEstudianteHeaderServiceApi
    {
        [Get("/" + TipoAsistenciaEstudianteHeaders.GetAll)]
        Task<ApiResponse<PagedResponse<TipoAsistenciaEstudianteHeaderResponse>>> GetAllAsync();

        [Get("/" + TipoAsistenciaEstudianteHeaders.Get)]
        Task<ApiResponse<TipoAsistenciaEstudianteHeaderResponse>> GetAsync(int tipoAsistenciaEstudianteHeaderId);

        [Post("/" + TipoAsistenciaEstudianteHeaders.Create)]
        Task<ApiResponse<TipoAsistenciaEstudianteHeaderResponse>> CreateAsync([Body] CreateTipoAsistenciaEstudianteHeaderRequest tipoAsistenciaEstudianteHeaderRequest);

        [Put("/" + TipoAsistenciaEstudianteHeaders.Update)]
        Task<ApiResponse<TipoAsistenciaEstudianteHeaderResponse>> UpdateAsync(int tipoAsistenciaEstudianteHeaderId, [Body] UpdateTipoAsistenciaEstudianteHeaderRequest tipoAsistenciaEstudianteHeaderRequest);

        [Delete("/" + TipoAsistenciaEstudianteHeaders.Delete)]
        Task<ApiResponse<TipoAsistenciaEstudianteHeaderResponse>> DeleteAsync(int tipoAsistenciaEstudianteHeaderId);
    }
}
