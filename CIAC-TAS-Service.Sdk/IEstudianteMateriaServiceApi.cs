using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Responses;
using Refit;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Sdk
{
    [Headers("Authorization: Bearer")]
    public interface IEstudianteMateriaServiceApi
    {
        [Get("/" + EstudianteMaterias.GetAll)]
        Task<ApiResponse<PagedResponse<EstudianteMateriaResponse>>> GetAllAsync();

        [Get("/" + EstudianteMaterias.Get)]
        Task<ApiResponse<EstudianteMateriaResponse>> GetAsync(int estudianteId, int grupoId, int materiaId);

        [Post("/" + EstudianteMaterias.Create)]
        Task<ApiResponse<EstudianteMateriaResponse>> CreateAsync([Body] CreateEstudianteMateriaRequest estudianteMateriaRequest);

        [Delete("/" + EstudianteMaterias.Delete)]
        Task<ApiResponse<EstudianteMateriaResponse>> DeleteAsync(int estudianteId, int grupoId, int materiaId);

        [Get("/" + EstudianteMaterias.GetAllByEstudianteGrupo)]
        Task<ApiResponse<PagedResponse<EstudianteMateriaResponse>>> GetAllByEstudianteGrupoAsync(int estudianteId, int grupoId);

        [Post("/" + EstudianteMaterias.CreateAsignAllMaterias)]
        Task<ApiResponse<EstudianteMateriaResponse>> CreateAsignAllMateriasAsync(int estudianteId, int grupoId);
        
        [Get("/" + EstudianteMaterias.GetAllByMateriaGrupo)]
        Task<ApiResponse<PagedResponse<EstudianteMateriaResponse>>> GetAllByMateriaGrupoAsync(int materiaId, int grupoId);

        [Get("/" + EstudianteMaterias.GetAllByEstudianteId)]
        Task<ApiResponse<PagedResponse<EstudianteMateriaResponse>>> GetAllByEstudianteIdAsync(int estudianteId);
    }
}
