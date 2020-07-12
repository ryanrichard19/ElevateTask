using HumanDTO;
using HumanRazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanRazor.Services
{
    public interface IApiClient
    {
        Task<SessionTokenResponse> GetSessionTokenAsync();
        Task<List<ActivityDataModel>> GetActivySummaryAsync();
        Task<bool> CheckHealthAsync();
    }
}
