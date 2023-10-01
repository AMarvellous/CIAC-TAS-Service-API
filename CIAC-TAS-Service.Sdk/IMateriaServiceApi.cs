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
    public interface IMateriaServiceApi
    {
        [Get("/" + Materias.GetAll)]
        Task<ApiResponse<PagedResponse<MateriaResponse>>> GetAllAsync();

        [Get("/" + Materias.Get)]
        Task<ApiResponse<MateriaResponse>> GetAsync(int materiaId);

        [Post("/" + Materias.Create)]
        Task<ApiResponse<MateriaResponse>> CreateAsync([Body] CreateMateriaRequest materiaRequest);

        [Put("/" + Materias.Update)]
        Task<ApiResponse<MateriaResponse>> UpdateAsync(int materiaId, [Body] UpdateMateriaRequest materiaRequest);

        [Delete("/" + Materias.Delete)]
        Task<ApiResponse<MateriaResponse>> DeleteAsync(int materiaId);

        [Get("/" + Materias.GetAllNotAssignedMaterias)]
        Task<ApiResponse<PagedResponse<MateriaResponse>>> GetAllNotAssignedMateriasAsync(int estudianteId, int grupoId);

        [Get("/" + Materias.GetAllMateriasAssignedByInstructorGrupo)]
        Task<ApiResponse<PagedResponse<MateriaResponse>>> GetAllMateriasAssignedByInstructorGrupoAsync(int instructorId, int grupoId);
    }
}
