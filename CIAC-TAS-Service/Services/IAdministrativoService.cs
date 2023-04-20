using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IAdministrativoService
    {
        Task<List<Administrativo>> GetAdministrativosAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateAdministrativoAsync(Administrativo administrativo);
        Task<Administrativo> GetAdministrativoByIdAsync(int id);
        Task<bool> UpdateAdministrativoAsync(Administrativo administrativo);
        Task<bool> DeleteAdministrativoAsync(int id);
        Task<bool> CheckUserIdIsAssignedAsync(string userId);
        Task<bool> CheckUserIdIsAssignableToThisAdministrativoAsync(int administrativoId, string proposedUserId);
    }
}
