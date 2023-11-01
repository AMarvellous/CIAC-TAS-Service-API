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
    public interface IRegistroNotaEstudianteServiceApi
    {
        [Get("/" + RegistroNotaEstudiantes.GetAll)]
        Task<ApiResponse<PagedResponse<RegistroNotaEstudianteResponse>>> GetAllAsync();

        [Get("/" + RegistroNotaEstudiantes.Get)]
        Task<ApiResponse<RegistroNotaEstudianteResponse>> GetAsync(int registroNotaEstudianteId);

        [Post("/" + RegistroNotaEstudiantes.Create)]
        Task<ApiResponse<RegistroNotaEstudianteResponse>> CreateAsync([Body] CreateRegistroNotaEstudianteRequest registroNotaEstudianteRequest);

        [Put("/" + RegistroNotaEstudiantes.Update)]
        Task<ApiResponse<RegistroNotaEstudianteResponse>> UpdateAsync(int registroNotaEstudianteId, [Body] UpdateRegistroNotaEstudianteRequest registroNotaEstudianteRequest);

        [Delete("/" + RegistroNotaEstudiantes.Delete)]
        Task<ApiResponse<RegistroNotaEstudianteResponse>> DeleteAsync(int registroNotaEstudianteId);

        [Get("/" + RegistroNotaEstudiantes.GetAllByRegistroNotaEstudianteHeaderId)]
        Task<ApiResponse<PagedResponse<RegistroNotaEstudianteResponse>>> GetAllByRegistroNotaEstudianteHeaderIdAsync(int registroNotaEstudianteHeaderId);
    }
}
