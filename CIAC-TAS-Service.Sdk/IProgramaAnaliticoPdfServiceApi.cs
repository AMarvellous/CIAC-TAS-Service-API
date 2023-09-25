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
    public interface IProgramaAnaliticoPdfServiceApi
    {
        [Get("/" + ProgramaAnaliticoPdfs.GetAll)]
        Task<ApiResponse<PagedResponse<ProgramaAnaliticoPdfResponse>>> GetAllAsync();

        [Get("/" + ProgramaAnaliticoPdfs.Get)]
        Task<ApiResponse<ProgramaAnaliticoPdfResponse>> GetAsync(int programaAnaliticoPdfId);

        [Post("/" + ProgramaAnaliticoPdfs.Create)]
        Task<ApiResponse<ProgramaAnaliticoPdfResponse>> CreateAsync([Body] CreateProgramaAnaliticoPdfRequest programaAnaliticoPdfRequest);

        [Put("/" + ProgramaAnaliticoPdfs.Update)]
        Task<ApiResponse<ProgramaAnaliticoPdfResponse>> UpdateAsync(int programaAnaliticoPdfId, [Body] UpdateProgramaAnaliticoPdfRequest programaAnaliticoPdfRequest);

        [Delete("/" + ProgramaAnaliticoPdfs.Delete)]
        Task<ApiResponse<ProgramaAnaliticoPdfResponse>> DeleteAsync(int programaAnaliticoPdfId);
        
        [Get("/" + ProgramaAnaliticoPdfs.GetAllNotAssignedInstructor)]
        Task<ApiResponse<PagedResponse<ProgramaAnaliticoPdfResponse>>> GetAllNotAssignedInstructorAsync(int instructorId);       
    }
}
