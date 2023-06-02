namespace BlogManagementWeb.Service
{
    public interface IAdminService
    {
        Task<IEnumerable<Models.Blog>> GetUsersAsync();
        Task<bool> ApproveBlog(int id);
        Task<bool> RejectBlog(int id);
    }
}
