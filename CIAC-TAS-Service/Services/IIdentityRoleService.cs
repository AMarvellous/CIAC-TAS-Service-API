namespace CIAC_TAS_Service.Services
{
    public interface IIdentityRoleService
    {
        Task<bool> CheckRoleIdExists(string roleId);
    }
}
