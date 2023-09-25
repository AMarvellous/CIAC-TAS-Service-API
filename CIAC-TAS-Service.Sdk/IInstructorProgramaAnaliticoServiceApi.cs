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
    public interface IInstructorProgramaAnaliticoServiceApi
    {
        [Get("/" + InstructorProgramaAnaliticos.GetAll)]
        Task<ApiResponse<PagedResponse<InstructorProgramaAnaliticoResponse>>> GetAllAsync();

        [Get("/" + InstructorProgramaAnaliticos.Get)]
        Task<ApiResponse<InstructorProgramaAnaliticoResponse>> GetAsync(int instructorId, int programaAnaliticoPdfId);

        [Post("/" + InstructorProgramaAnaliticos.Create)]
        Task<ApiResponse<InstructorProgramaAnaliticoResponse>> CreateAsync([Body] CreateInstructorProgramaAnaliticoRequest instructorProgramaAnaliticoRequest);

        [Delete("/" + InstructorProgramaAnaliticos.Delete)]
        Task<ApiResponse<InstructorProgramaAnaliticoResponse>> DeleteAsync(int instructorId, int programaAnaliticoPdfId);

        [Get("/" + InstructorProgramaAnaliticos.GetAllByInstructorId)]
        Task<ApiResponse<PagedResponse<InstructorProgramaAnaliticoResponse>>> GetAllByInstructorIdAsync(int instructorId);
    }
}
