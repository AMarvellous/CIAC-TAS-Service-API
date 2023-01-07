using CIAC_TAS_Service.Contracts.V1.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace CIAC_TAS_Service.SwaggerExamples.Responses
{
    public class PostResponseExample : IExamplesProvider<PostResponse>
    {
        public PostResponse GetExamples()
        {
            return new PostResponse
            {
                Id = Guid.NewGuid(),
                Name = "Post Name",
                UserId = Guid.NewGuid().ToString(),
                Tags = new List<TagResponse> {
                    new TagResponse {
                        Name = "Tag Name"
                    },
                    new TagResponse {
                        Name = "Another Tag Name"
                    }
                }
            };
        }
    }
}
