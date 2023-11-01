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
    public interface IRegistroNotaHeaderServiceApi
    {
        [Get("/" + RegistroNotaHeaders.GetAll)]
        Task<ApiResponse<PagedResponse<RegistroNotaHeaderResponse>>> GetAllAsync();

        [Get("/" + RegistroNotaHeaders.Get)]
        Task<ApiResponse<RegistroNotaHeaderResponse>> GetAsync(int registroNotaHeaderId);

        [Post("/" + RegistroNotaHeaders.Create)]
        Task<ApiResponse<RegistroNotaHeaderResponse>> CreateAsync([Body] CreateRegistroNotaHeaderRequest registroNotaHeaderRequest);

        [Put("/" + RegistroNotaHeaders.Update)]
        Task<ApiResponse<RegistroNotaHeaderResponse>> UpdateAsync(int registroNotaHeaderId, [Body] UpdateRegistroNotaHeaderRequest registroNotaHeaderRequest);

        [Delete("/" + RegistroNotaHeaders.Delete)]
        Task<ApiResponse<RegistroNotaHeaderResponse>> DeleteAsync(int registroNotaHeaderId);

        [Get("/" + RegistroNotaHeaders.GetAllHeadersByGrupoAndMateriaId)]
        Task<ApiResponse<PagedResponse<RegistroNotaHeaderResponse>>> GetAllHeadersByGrupoAndMateriaIdAsync(int grupoId, int materiaId);
        
        [Post("/" + RegistroNotaHeaders.CreateRegistroNotaEstudianteHeader)]
        Task<ApiResponse<RegistroNotaHeaderResponse>> CreateRegistroNotaEstudianteHeaderAsync([Body] CreateRegistroNotaHeaderRequest registroNotaHeaderRequest);
    }
}
