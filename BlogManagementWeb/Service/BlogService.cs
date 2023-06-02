using Models;
using System.Net.Http;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace BlogManagementWeb.Service
{
    public class BlogService:IBlogService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7012";
        public BlogService(HttpClient httpClient, IConfiguration configuration/*, IBlogRepository blogRepository*/)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
            // _apiBaseUrl = configuration.GetValue<string>("ServiceUrls:BlogManagementAPI");
            // _blogRepository = blogRepository;
        }
        public async Task<IEnumerable<Models.Blog>> GetblogsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Blog/");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<Models.Blog> blog = JsonConvert.DeserializeObject<IEnumerable<Models.Blog>>(content);
            return blog;
        }

        public async Task<Models.Blog> GetBlogByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Blog/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
           Models.Blog blogPost = JsonConvert.DeserializeObject<Models.Blog>(content);
            return blogPost;
        }

        public async Task<Models.Blog> CreateBlogAsync(Models.Blog blog)
        {
            string json = JsonConvert.SerializeObject(blog);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("/api/Blog/", content);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            Models.Blog createdBlogPost = JsonConvert.DeserializeObject<Models.Blog>(responseContent);
            return createdBlogPost;

        }

        public async Task<Models.Blog> UpdateBlogAsync(int id, Models.Blog blog)
        {
            string json = JsonConvert.SerializeObject(blog);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync($"/api/Blog/{id}", content);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
           Models.Blog updatedBlog = JsonConvert.DeserializeObject<Models.Blog>(responseContent);
            return updatedBlog;
        }

        public async Task DeleteBlogAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/Blog/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
