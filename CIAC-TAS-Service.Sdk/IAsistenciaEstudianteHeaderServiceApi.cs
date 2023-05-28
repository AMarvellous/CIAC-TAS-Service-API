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
    public interface IAsistenciaEstudianteHeaderServiceApi
    {
        [Get("/" + AsistenciaEstudianteHeaders.GetAll)]
        Task<ApiResponse<PagedResponse<AsistenciaEstudianteHeaderResponse>>> GetAllAsync();

        [Get("/" + AsistenciaEstudianteHeaders.Get)]
        Task<ApiResponse<AsistenciaEstudianteHeaderResponse>> GetAsync(int asistenciaEstudianteHeaderId);

        [Post("/" + AsistenciaEstudianteHeaders.Create)]
        Task<ApiResponse<AsistenciaEstudianteHeaderResponse>> CreateAsync([Body] CreateAsistenciaEstudianteHeaderRequest asistenciaEstudianteHeaderRequest);

        [Put("/" + AsistenciaEstudianteHeaders.Update)]
        Task<ApiResponse<AsistenciaEstudianteHeaderResponse>> UpdateAsync(int asistenciaEstudianteHeaderId, [Body] UpdateAsistenciaEstudianteHeaderRequest asistenciaEstudianteHeaderRequest);

        [Delete("/" + AsistenciaEstudianteHeaders.Delete)]
        Task<ApiResponse<AsistenciaEstudianteHeaderResponse>> DeleteAsync(int asistenciaEstudianteHeaderId);

        [Get("/" + AsistenciaEstudianteHeaders.GetAllHeadersByGrupoAndMateriaId)]
        Task<ApiResponse<PagedResponse<AsistenciaEstudianteHeaderResponse>>> GetAllHeadersByGrupoIdMateriaIdAsync(int grupoId, int materiaId);
    }
}
