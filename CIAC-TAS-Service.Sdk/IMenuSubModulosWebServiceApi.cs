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
    public interface IMenuSubModulosWebServiceApi
    {
        [Get("/" + MenuSubModulosWebs.GetAll)]
        Task<ApiResponse<PagedResponse<MenuSubModulosWebResponse>>> GetAllAsync();

        [Get("/" + MenuSubModulosWebs.Get)]
        Task<ApiResponse<MenuSubModulosWebResponse>> GetAsync(int menuSubModulosWebId);

        [Post("/" + MenuSubModulosWebs.Create)]
        Task<ApiResponse<MenuSubModulosWebResponse>> CreateAsync([Body] CreateMenuSubModulosWebRequest menuSubModulosWebRequest);

        [Put("/" + MenuSubModulosWebs.Update)]
        Task<ApiResponse<MenuSubModulosWebResponse>> UpdateAsync(int menuSubModulosWebId, [Body] UpdateMenuSubModulosWebRequest menuSubModulosWebRequest);

        [Delete("/" + MenuSubModulosWebs.Delete)]
        Task<ApiResponse<MenuSubModulosWebResponse>> DeleteAsync(int menuSubModulosWebId);
    }
}
