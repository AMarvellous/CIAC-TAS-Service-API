using Microsoft.AspNetCore.Identity;

namespace CIAC_TAS_Service.Services
{
    public class IdentityRoleService : IIdentityRoleService
    {
        private readonly RoleManager<IdentityRole> _managerRole;

        public IdentityRoleService(RoleManager<IdentityRole> managerRole)
        {
            _managerRole = managerRole;
        }

        public async Task<bool> CheckRoleIdExists(string roleId)
        {
            return await _managerRole.FindByIdAsync(roleId) != null;
        }
    }
}
