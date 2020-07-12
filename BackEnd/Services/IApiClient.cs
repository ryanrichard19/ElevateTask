using HumanDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public interface IApiClient
    {
        Task<ConnectSessionToken> GetConnectSessionTokenAsync(string clientId);
        Task<ConnectIdToken> GetConnectIdTokenAsync(string clientId);
    }
}
