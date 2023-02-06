using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> CheckRoleNameExists(string roleName)
        {
            return await _managerRole.FindByNameAsync(roleName) != null;
        }

        public async Task<IEnumerable<string>> GetRolesNamesAsync()
        {
            return await _managerRole.Roles.Select(x => x.Name).ToListAsync();
        }
    }
}
