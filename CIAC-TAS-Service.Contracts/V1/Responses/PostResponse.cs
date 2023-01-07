
namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class PostResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public ICollection<TagResponse> Tags { get; set; }
    }
}
