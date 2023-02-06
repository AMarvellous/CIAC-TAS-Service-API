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
    public interface IEstudianteProgramaServiceApi
    {
        [Get("/" + EstudianteProgramas.GetAll)]
        Task<ApiResponse<PagedResponse<EstudianteProgramaResponse>>> GetAllAsync();

        [Get("/" + EstudianteProgramas.Get)]
        Task<ApiResponse<EstudianteProgramaResponse>> GetAsync(int estudianteId, int programaId);

        [Post("/" + EstudianteProgramas.Create)]
        Task<ApiResponse<EstudianteProgramaResponse>> CreateAsync([Body] CreateEstudianteProgramaRequest estudianteProgramaRequest);

        [Delete("/" + EstudianteProgramas.Delete)]
        Task<ApiResponse<EstudianteProgramaResponse>> DeleteAsync(int estudianteId, int programaId);
    }
}
