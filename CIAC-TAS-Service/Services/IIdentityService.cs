using CIAC_TAS_Service.Domain;
using Microsoft.AspNetCore.Identity;

namespace CIAC_TAS_Service.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string userName, string email, string password);
        Task<AuthenticationResult> LoginAsync(string userName, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
        Task<IEnumerable<string>> GetRolesByUserNameAsync(string userName);
        Task<IEnumerable<IdentityUser>> GetUsersAsync();
        Task<IEnumerable<IdentityUser>> GetUsersByRoleAsync(string roleName);
		Task<bool> CheckUserExistsByUserIdAsync(string userId);
        Task<IdentityResult> AddUserToRoleAsync(string userId, string roleId);
        Task<IdentityUser> GetUserByNameAsync(string userName);
        Task<AuthenticationResult> UpdatePasswordByUserNameAsync(string userName, string newPassword);
        Task<bool> UserOwnsUserAsync(string userName, string userId);
    }
}
