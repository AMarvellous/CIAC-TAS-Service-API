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
    public interface IRegistroNotaEstudianteHeaderServiceApi
    {
        [Get("/" + RegistroNotaEstudianteHeaders.GetAll)]
        Task<ApiResponse<PagedResponse<RegistroNotaEstudianteHeaderResponse>>> GetAllAsync();

        [Get("/" + RegistroNotaEstudianteHeaders.Get)]
        Task<ApiResponse<RegistroNotaEstudianteHeaderResponse>> GetAsync(int registroNotaEstudianteHeaderId);

        [Post("/" + RegistroNotaEstudianteHeaders.Create)]
        Task<ApiResponse<RegistroNotaEstudianteHeaderResponse>> CreateAsync([Body] CreateRegistroNotaEstudianteHeaderRequest registroNotaEstudianteHeaderRequest);

        [Put("/" + RegistroNotaEstudianteHeaders.Update)]
        Task<ApiResponse<RegistroNotaEstudianteHeaderResponse>> UpdateAsync(int registroNotaEstudianteHeaderId, [Body] UpdateRegistroNotaEstudianteHeaderRequest registroNotaEstudianteHeaderRequest);

        [Delete("/" + RegistroNotaEstudianteHeaders.Delete)]
        Task<ApiResponse<RegistroNotaEstudianteHeaderResponse>> DeleteAsync(int registroNotaEstudianteHeaderId);

        [Get("/" + RegistroNotaEstudianteHeaders.GetAllByRegistroNotaHeaderId)]
        Task<ApiResponse<PagedResponse<RegistroNotaEstudianteHeaderResponse>>> GetAllByRegistroNotaHeaderIdasync(int registroNotaHeaderId);

        [Delete("/" + RegistroNotaEstudianteHeaders.DeleteRegistroNotaEstudianteHeaderAndChildren)]
        Task<ApiResponse<RegistroNotaEstudianteHeaderResponse>> DeleteRegistroNotaEstudianteHeaderAndChildrenAsync(int registroNotaEstudianteHeaderId);
    }
}
