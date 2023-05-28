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
    public interface IAsistenciaEstudianteServiceApi
    {
        [Get("/" + AsistenciaEstudiantes.GetAll)]
        Task<ApiResponse<PagedResponse<AsistenciaEstudianteResponse>>> GetAllAsync();

        [Get("/" + AsistenciaEstudiantes.Get)]
        Task<ApiResponse<AsistenciaEstudianteResponse>> GetAsync(int asistenciaEstudianteId);

        [Post("/" + AsistenciaEstudiantes.Create)]
        Task<ApiResponse<AsistenciaEstudianteResponse>> CreateAsync([Body] CreateAsistenciaEstudianteRequest asistenciaEstudianteRequest);

        [Put("/" + AsistenciaEstudiantes.Update)]
        Task<ApiResponse<AsistenciaEstudianteResponse>> UpdateAsync(int asistenciaEstudianteId, [Body] UpdateAsistenciaEstudianteRequest asistenciaEstudianteRequest);

        [Delete("/" + AsistenciaEstudiantes.Delete)]
        Task<ApiResponse<AsistenciaEstudianteResponse>> DeleteAsync(int asistenciaEstudianteId);

        [Post("/" + AsistenciaEstudiantes.CreateBatch)]
        Task<ApiResponse<List<AsistenciaEstudianteResponse>>> CreateBatchAsync([Body] List<CreateAsistenciaEstudianteRequest> asistenciaEstudianteRequest);
    }
}
