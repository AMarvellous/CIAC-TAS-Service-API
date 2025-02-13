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
    public interface ITipoRegistroNotaEstudianteServiceApi
    {
        [Get("/" + TipoRegistroNotaEstudiantes.GetAll)]
        Task<ApiResponse<PagedResponse<TipoRegistroNotaEstudianteResponse>>> GetAllAsync();

        [Get("/" + TipoRegistroNotaEstudiantes.Get)]
        Task<ApiResponse<TipoRegistroNotaEstudianteResponse>> GetAsync(int tipoRegistroNotaEstudianteId);

        [Post("/" + TipoRegistroNotaEstudiantes.Create)]
        Task<ApiResponse<TipoRegistroNotaEstudianteResponse>> CreateAsync([Body] CreateTipoRegistroNotaEstudianteRequest tipoRegistroNotaEstudianteRequest);

        [Put("/" + TipoRegistroNotaEstudiantes.Update)]
        Task<ApiResponse<TipoRegistroNotaEstudianteResponse>> UpdateAsync(int tipoRegistroNotaEstudianteId, [Body] UpdateTipoRegistroNotaEstudianteRequest tipoRegistroNotaEstudianteRequest);

        [Delete("/" + TipoRegistroNotaEstudiantes.Delete)]
        Task<ApiResponse<TipoRegistroNotaEstudianteResponse>> DeleteAsync(int tipoRegistroNotaEstudianteId);
    }
}
