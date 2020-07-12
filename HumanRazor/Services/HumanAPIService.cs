using HumanDTO;
using HumanRazor.Data;
using HumanRazor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HumanRazor.Services
{
    public class HumanAPIService : IHumanAPIService
    {

        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HumanAPIService(IConfiguration configuraton,
                               HttpClient httpClient,
                               UserManager<User> userManager,
                               IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuraton;
            _httpClient = httpClient;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<SessionTokenResponse> GetSessionTokenAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);


            _httpClient.BaseAddress = new System.Uri("https://localhost:44306/");
            var response = await _httpClient.GetAsync($"/api/SessionTokens/{user.Email}");

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<SessionTokenResponse>();
        }


        private async Task<AccessTokenModel> GetAccessTokenAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            var data = new
            {
                client_id = _configuration["HumanAPISettings:ClientSecret"],
                client_user_id = user.Email,
                client_secret = _configuration["HumanAPISettings:ClientId"],
                type = "access",

            };
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
            StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            _httpClient.BaseAddress = new System.Uri("https://auth.humanapi.co/v1/");
            var httpResponse = await _httpClient.PostAsync("https://auth.humanapi.co/v1/connect/token", content);
            var accessToken = JsonConvert.DeserializeObject<AccessTokenModel>(await httpResponse.Content.ReadAsStringAsync());
            return accessToken;
        }

        public async Task<List<ActivityDataModel>> GetActivySummaryAsync()
        {
            AccessTokenModel accessTokenModel = await GetAccessTokenAsync();
            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessTokenModel.access_token);
            var httpResponse = await _httpClient.GetAsync("https://api.humanapi.co/v1/human/activities/summaries");
            var activitySummary = JsonConvert.DeserializeObject<List<ActivityDataModel>>(await httpResponse.Content.ReadAsStringAsync());
            return activitySummary;
        }

    }
}
