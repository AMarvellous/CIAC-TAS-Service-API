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
    public interface IGrupoServiceApi
    {
        [Get("/" + Grupos.GetAll)]
        Task<ApiResponse<PagedResponse<GrupoResponse>>> GetAllAsync();

        [Get("/" + Grupos.Get)]
        Task<ApiResponse<GrupoResponse>> GetAsync(int grupoId);

        [Post("/" + Grupos.Create)]
        Task<ApiResponse<GrupoResponse>> CreateAsync([Body] CreateGrupoRequest grupoRequest);

        [Put("/" + Grupos.Update)]
        Task<ApiResponse<GrupoResponse>> UpdateAsync(int grupoId, [Body] UpdateGrupoRequest grupoRequest);

        [Delete("/" + Grupos.Delete)]
        Task<ApiResponse<GrupoResponse>> DeleteAsync(int grupoId);

		[Get("/" + Grupos.GetAllNotAssignedEstudents)]
		Task<ApiResponse<PagedResponse<GrupoResponse>>> GetAllNotAssignedEstudentsAsync();

        [Get("/" + Grupos.GetAllGruposAssignedByInstructor)]
        Task<ApiResponse<PagedResponse<GrupoResponse>>> GetAllGruposAssignedByInstructorAsync(int instructorId);
    }
}
