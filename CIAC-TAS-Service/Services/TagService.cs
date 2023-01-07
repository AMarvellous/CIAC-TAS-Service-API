using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class TagService : ITagService
    {
        private readonly DataContext _dataContext;
        public TagService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateTagsAsync(List<Tag> tags)
        {
            await _dataContext.Tags.AddRangeAsync(tags);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<List<Tag>> GetTagsByPostIdAsync(Guid postId)
        {
            return await _dataContext.Tags.Where(t => t.PostId == postId).ToListAsync();
        }
    }
}
