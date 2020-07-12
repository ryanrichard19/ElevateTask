using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Infrastructure
{
    public static class EntityExtenstions
    {
        public static HumanDTO.SessionTokenResponse MapSessionTokenResponse(this SessionToken sessionToken) =>
            new HumanDTO.SessionTokenResponse
            {
                SessionToken = sessionToken.AuthToken
            };
    
    }
}
