namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class CreatePostRequest
    {
        public string Name { get; set; }
        public List<string> Tags { get; set; }
    }
}
