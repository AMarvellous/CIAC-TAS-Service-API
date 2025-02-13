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
    public interface IInhabilitacionEstudianteServiceApi
    {
        [Get("/" + InhabilitacionEstudiantes.GetAll)]
        Task<ApiResponse<PagedResponse<InhabilitacionEstudianteResponse>>> GetAllAsync();

        [Get("/" + InhabilitacionEstudiantes.Get)]
        Task<ApiResponse<InhabilitacionEstudianteResponse>> GetAsync(int inhabilitacionEstudianteId);

        [Post("/" + InhabilitacionEstudiantes.Create)]
        Task<ApiResponse<InhabilitacionEstudianteResponse>> CreateAsync([Body] CreateInhabilitacionEstudianteRequest inhabilitacionEstudianteRequest);

        [Put("/" + InhabilitacionEstudiantes.Update)]
        Task<ApiResponse<InhabilitacionEstudianteResponse>> UpdateAsync(int inhabilitacionEstudianteId, [Body] UpdateInhabilitacionEstudianteRequest inhabilitacionEstudianteRequest);

        [Delete("/" + InhabilitacionEstudiantes.Delete)]
        Task<ApiResponse<InhabilitacionEstudianteResponse>> DeleteAsync(int inhabilitacionEstudianteId);

        [Get("/" + InhabilitacionEstudiantes.GetByEstudianteId)]
        Task<ApiResponse<InhabilitacionEstudianteResponse>> GetByEstudianteIdAsync(int estudianteId);
    }
}
