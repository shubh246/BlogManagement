using Data.Repository;
using Newtonsoft.Json;
using System.Net;

namespace BlogManagementWeb.Service
{
    public class AdminService:IAdminService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7012";

        public AdminService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
            // _apiBaseUrl = configuration.GetValue<string>("ServiceUrls:BlogManagementAPI");
            // _blogRepository = blogRepository;
        }
        public async Task<IEnumerable<Models.Blog>> GetUsersAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Admin/GetAllNoActionTakenBlogs");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<Models.Blog> blog = JsonConvert.DeserializeObject<IEnumerable<Models.Blog>>(content);
            return blog;
        }

        public async Task<bool> ApproveBlog(int id)
        {
            var response = await _httpClient.PutAsync($"api/AdminController/ApprovedBlog?id={id}", null);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Blog not found.");
            }
            else
            {
                throw new Exception("Error approving blog.");
            }
        }

        public async Task<bool> RejectBlog(int id)
        {
            var response = await _httpClient.PutAsync($"api/AdminController/RejectBlog?id={id}", null);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Blog not found.");
            }
            else
            {
                throw new Exception("Error rejecting blog.");
            }

        }
    }
}
