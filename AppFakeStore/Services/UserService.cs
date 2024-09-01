using AppFakeStore.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using AppFakeStore.Utils;
using System.Net.Http.Json;

namespace AppFakeStore.Services
{
    public class UserService : IUserService
    {
        HttpClient client;

        private static JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public UserService()
        {
            client = new HttpClient();

            client.BaseAddress = new Uri(Constants.ApiDataServer);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var response = await client.GetAsync(Constants.UserEndpoint);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<User>>(options);

            return default;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var response = await client.GetAsync($"{Constants.UserEndpoint}/{id}");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<User>(options);

            return default;
        }
    }
}