using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Sdk
{
    [Headers("Authorization: Bearer")]
    public interface ICIACTASServiceApi
    {
        [Get("/api/v1/posts")]
        Task<ApiResponse<List<PostResponse>>> GetAllAsync();

        [Get("/api/v1/posts/{postId}")]
        Task<ApiResponse<PostResponse>> GetAsync(Guid postId);

        [Post("/api/v1/posts")]
        Task<ApiResponse<PostResponse>> CreateAsync([Body] CreatePostRequest createPostRequest);
    }
}
