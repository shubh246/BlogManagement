using Models;
using System.Reflection.Metadata;

namespace BlogManagementWeb.Service
{
    public interface IBlogService
    {
        Task<IEnumerable<Models.Blog>> GetblogsAsync();
        Task<Models.Blog> GetBlogByIdAsync(int id);
        Task<Models.Blog> CreateBlogAsync(Models.Blog blog);
        Task<Models.Blog> UpdateBlogAsync(int id, Models.Blog updatedblog);
        Task DeleteBlogAsync(int id);
    }
}
