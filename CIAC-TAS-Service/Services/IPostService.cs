using CIAC_TAS_Service.Domain;

namespace CIAC_TAS_Service.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync(GetAllPostsFilter filter = null, PaginationFilter paginationFilter = null);
        Task<bool> CreatePostAsync(Post post);
        Task<Post> GetPostByIdAsync(Guid guid);
        Task<bool> UpdatePostAsync(Post post);
        Task<bool> DeletePostAsync(Guid postId);
        Task<bool> UserOwnsPostAsync(Guid postId, string userId);
        Task<List<Tag>> GetAllTagsAsync();
    }
}
