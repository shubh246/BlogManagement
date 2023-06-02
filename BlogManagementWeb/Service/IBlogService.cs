using Models;
using System.Reflection.Metadata;

namespace BlogManagementWeb.Service
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetblogsAsync();
        Task<Blog> GetBlogByIdAsync(int id);
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<Blog> UpdateBlogAsync(int id, Blog updatedblog);
        Task DeleteBlogAsync(int id);
    }
}
