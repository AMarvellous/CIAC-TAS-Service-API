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
    public interface IInstructorServiceApi
    {
        [Get("/" + Instructores.GetAll)]
        Task<ApiResponse<PagedResponse<InstructorResponse>>> GetAllAsync();

        [Get("/" + Instructores.Get)]
        Task<ApiResponse<InstructorResponse>> GetAsync(int instructorId);

        [Post("/" + Instructores.Create)]
        Task<ApiResponse<InstructorResponse>> CreateAsync([Body] CreateInstructorRequest instructorRequest);

        [Put("/" + Instructores.Update)]
        Task<ApiResponse<InstructorResponse>> UpdateAsync(int instructorId, [Body] UpdateInstructorRequest instructorRequest);

        [Delete("/" + Instructores.Delete)]
        Task<ApiResponse<InstructorResponse>> DeleteAsync(int instructorId);
    }
}
