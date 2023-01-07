using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;

        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;         
        }

        public async Task<List<Post>> GetPostsAsync(GetAllPostsFilter filter = null, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.Posts.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.Include(t => t.Tags).ToListAsync();
            }

            if (!string.IsNullOrEmpty(filter?.UserId))
            {
                queryable = queryable.Where(x => x.UserId == filter.UserId);
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            // https://learn.microsoft.com/en-us/ef/ef6/querying/related-data?redirectedfrom=MSDN
            return await queryable.Include(t => t.Tags)
                .Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<bool> CreatePostAsync(Post post)
        {
            await _dataContext.Posts.AddAsync(post);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<Post> GetPostByIdAsync(Guid guid)
        {
            return await _dataContext.Posts.SingleOrDefaultAsync(x => x.Id == guid);
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            _dataContext.Posts.Update(post);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);

            if (post == null)
            {
                return false;
            }

            _dataContext.Posts.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> UserOwnsPostAsync(Guid postId, string userId)
        {
            var post = await _dataContext.Posts.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == postId);

            if (post == null)
            {
                return false;
            }

            if (post.UserId != userId)
            {
                return false;
            }

            return true;
        }

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _dataContext.Tags.ToListAsync();
        }
    }
}
