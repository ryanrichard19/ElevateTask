using HumanRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanRazor.Services
{
    public interface IHumanAPIService
    {
        Task<SessionTokenModel> GetSessionTokenAsync();
        Task<List<ActivityDataModel>> GetActivySummaryAsync();
    }
}
