using HumanDTO;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class ApiClient : IApiClient
    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public ApiClient(HttpClient httpClient, IConfiguration configuraton)
        {
            _httpClient = httpClient;
            _configuration = configuraton;
        }

        public async Task<ConnectSessionToken> GetConnectSessionTokenAsync(string clientId)
        {
            var data = new
            {
                client_id = _configuration["HumanAPISettings:ClientId"],
                client_user_id = clientId,
                client_secret = _configuration["HumanAPISettings:ClientSecret"],
                type = "session",
                client_user_email = clientId,

            };
            var response = await _httpClient.PostAsJsonAsync($"v1/connect/token", data);

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ConnectSessionToken>();
        }


        public async Task<ConnectIdToken> GetConnectIdTokenAsync(string clientId)
        {
            var data = new
            {
                client_id = _configuration["HumanAPISettings:ClientId"],
                client_user_id = clientId,
                client_secret = _configuration["HumanAPISettings:ClientSecret"],
                type = "id",
                client_user_email = clientId,

            };
            var response = await _httpClient.PostAsJsonAsync($"v1/connect/token", data);

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ConnectIdToken>();
        }

    }
}
