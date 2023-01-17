using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.General;

namespace CIAC_TAS_Service.Services
{
    public interface IGrupoService
    {
        Task<List<Grupo>> GetGruposAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateGrupoAsync(Grupo grupo);
        Task<Grupo> GetGrupoByIdAsync(int id);
        Task<bool> UpdateGrupoAsync(Grupo grupo);
        Task<bool> DeleteGrupoAsync(int id);
    }
}
