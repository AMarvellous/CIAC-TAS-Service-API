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
    public interface IEstudianteGrupoServiceApi
    {
        [Get("/" + EstudianteGrupos.GetAll)]
        Task<ApiResponse<PagedResponse<EstudianteGrupoResponse>>> GetAllAsync();

        [Get("/" + EstudianteGrupos.Get)]
        Task<ApiResponse<EstudianteGrupoResponse>> GetAsync(int estudianteId, int GrupoId);

        [Post("/" + EstudianteGrupos.Create)]
        Task<ApiResponse<EstudianteGrupoResponse>> CreateAsync([Body] CreateEstudianteGrupoRequest estudianteGrupoRequest);

        [Delete("/" + EstudianteGrupos.Delete)]
        Task<ApiResponse<EstudianteGrupoResponse>> DeleteAsync(int estudianteId, int GrupoId);
    }
}
