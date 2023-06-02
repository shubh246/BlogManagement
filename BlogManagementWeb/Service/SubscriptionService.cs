using Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace BlogManagementWeb.Service
{
    public class SubscriptionService:ISubscriptionService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7012";

        public SubscriptionService(HttpClient httpClient, IConfiguration configuration/*, IBlogRepository blogRepository*/)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
            
        }
        public async Task<IEnumerable<Subscription>> GetSubscriptionsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Subscription/");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<Subscription> sub = JsonConvert.DeserializeObject<IEnumerable<Subscription>>(content);
            return sub;
        }

        public async Task<Subscription> GetSubscriptionByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Subscription/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            Subscription sub = JsonConvert.DeserializeObject<Subscription>(content);
            return sub;
        }

        public async Task<Subscription> CreateSubscriptionAsync(Subscription sub)
        {
            string json = JsonConvert.SerializeObject(sub);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("/api/Subscription/", content);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            Subscription createdSub = JsonConvert.DeserializeObject<Subscription>(responseContent);
            return createdSub;

        }
        public async Task DeleteSubscriptionAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/Subscription/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
