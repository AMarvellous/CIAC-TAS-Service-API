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
    public interface IIdentityApi
    {
        [Post("/" + Identity.Register)]
        Task<ApiResponse<AuthSuccessResponse>> RegisterAsync([Body] UserRegistrationRequest registrationRequest);

        [Post("/" + Identity.Login)]
        Task<ApiResponse<AuthSuccessResponse>> LoginAsync([Body] UserLoginRequest userLoginRequest);

        [Post("/" + Identity.Refresh)]
        Task<ApiResponse<AuthSuccessResponse>> RefreshAsync([Body] RefreshTokenRequest refreshTokenRequest);

        [Get("/" + Identity.GetRolesNames)]
        Task<ApiResponse<IEnumerable<string>>> GetRolesNamesAsync();

        [Get("/" + Identity.GetRolesUserName)]
        Task<ApiResponse<IEnumerable<string>>> GetRolesByUserNameAsync(string userName);

        [Get("/" + Identity.GetUsers)]
        Task<ApiResponse<PagedResponse<IdentityUserResponse>>> GetUsersAsync();

		[Get("/" + Identity.GetUsersByRoleName)]
		Task<ApiResponse<PagedResponse<IdentityUserResponse>>> GetUsersByRoleNameAsync(string roleName);

		[Get("/" + Identity.GetUserByName)]
        Task<ApiResponse<IdentityUserResponse>> GetUserByNameAsync(string userName);

        [Post("/" + Identity.GetAsignToRole)]
        Task<ApiResponse<PagedResponse<bool>>> AsignUserToRoleAsync([Body] AsignRoleToUserRequest request);

        [Patch("/" + Identity.PatchUserPassword)]
        Task<ApiResponse<AuthSuccessResponse>> PatchUserPasswordAsync(string userName, [Body] PatchUsuarioPasswordRequest usuarioPasswordRequest);

        [Patch("/" + Identity.PatchUserPasswordUserOwns)]
        Task<ApiResponse<AuthSuccessResponse>> PatchUserPasswordUserOwnsForEstudianteOrInstructorAsync(string userName, [Body] PatchUsuarioPasswordRequest usuarioPasswordRequest);

    }
}
