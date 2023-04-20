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
    public interface IAdministrativoServiceApi
    {
        [Get("/" + Administrativos.GetAll)]
        Task<ApiResponse<PagedResponse<AdministrativoResponse>>> GetAllAsync();

        [Get("/" + Administrativos.Get)]
        Task<ApiResponse<AdministrativoResponse>> GetAsync(int administrativoId);

        [Post("/" + Administrativos.Create)]
        Task<ApiResponse<AdministrativoResponse>> CreateAsync([Body] CreateAdministrativoRequest administrativoRequest);

        [Put("/" + Administrativos.Update)]
        Task<ApiResponse<AdministrativoResponse>> UpdateAsync(int administrativoId, [Body] UpdateAdministrativoRequest administrativoRequest);

        [Delete("/" + Administrativos.Delete)]
        Task<ApiResponse<AdministrativoResponse>> DeleteAsync(int administrativoId);
    }
}
