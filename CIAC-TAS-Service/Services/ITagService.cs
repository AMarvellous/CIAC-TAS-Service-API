using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface ITagService
    {
        Task<List<Tag>> GetTagsByPostIdAsync(Guid guid);
        Task<bool> CreateTagsAsync(List<Tag> tags);
    }
}
