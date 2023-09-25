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
    public interface IInstructorMateriaServiceApi
    {
        [Get("/" + InstructorMaterias.GetAll)]
        Task<ApiResponse<PagedResponse<InstructorMateriaResponse>>> GetAllAsync();

        [Get("/" + InstructorMaterias.Get)]
        Task<ApiResponse<InstructorMateriaResponse>> GetAsync(int instructorId, int materiaId, int grupoId);

        [Post("/" + InstructorMaterias.Create)]
        Task<ApiResponse<InstructorMateriaResponse>> CreateAsync([Body] CreateInstructorMateriaRequest instructorMateriaRequest);

        [Delete("/" + InstructorMaterias.Delete)]
        Task<ApiResponse<InstructorMateriaResponse>> DeleteAsync(int instructorId, int materiaId, int grupoId);

        [Get("/" + InstructorMaterias.GetAllByInstructorId)]
        Task<ApiResponse<PagedResponse<InstructorMateriaResponse>>> GetAllByInstructorIdAsync(int instructorId);
    }
}
