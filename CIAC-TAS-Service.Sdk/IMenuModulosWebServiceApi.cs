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
    public interface IMenuModulosWebServiceApi
    {
        [Get("/" + MenuModulosWebs.GetAll)]
        Task<ApiResponse<PagedResponse<MenuModulosWebResponse>>> GetAllAsync();

        [Get("/" + MenuModulosWebs.Get)]
        Task<ApiResponse<MenuModulosWebResponse>> GetAsync(int menuModulosWebId);

        [Post("/" + MenuModulosWebs.Create)]
        Task<ApiResponse<MenuModulosWebResponse>> CreateAsync([Body] CreateMenuModulosWebRequest menuModulosWebRequest);

        [Put("/" + MenuModulosWebs.Update)]
        Task<ApiResponse<MenuModulosWebResponse>> UpdateAsync(int menuModulosWebId, [Body] UpdateMenuModulosWebRequest menuModulosWebRequest);

        [Delete("/" + MenuModulosWebs.Delete)]
        Task<ApiResponse<MenuModulosWebResponse>> DeleteAsync(int menuModulosWebId);

        [Get("/" + MenuModulosWebs.GetByRoleName)]
        Task<ApiResponse<PagedResponse<MenuModulosWebResponse>>> GetByRoleAsync(string roleName);
    }
}
