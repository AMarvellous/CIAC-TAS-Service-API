namespace CIAC_TAS_Service.Services
{
    public interface IIdentityRoleService
    {
        Task<bool> CheckRoleIdExists(string roleId);
        Task<IEnumerable<string>> GetRolesNamesAsync();
        Task<bool> CheckRoleNameExists(string roleName);
    }
}
