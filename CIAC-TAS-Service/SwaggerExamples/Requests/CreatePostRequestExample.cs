using CIAC_TAS_Service.Contracts.V1.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace CIAC_TAS_Service.SwaggerExamples.Requests
{
    public class CreatePostRequestExample : IExamplesProvider<CreatePostRequest>
    {
        public CreatePostRequest GetExamples()
        {
            return new CreatePostRequest
            {
                Name = "Post Name",
                Tags = new List<string> { "Tag One", "Tag Two" }
            };
        }
    }
}
