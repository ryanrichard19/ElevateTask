using BackEnd.Infrastructure;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionTokensController : ControllerBase
    {
        private readonly IApiClient _apiClient;
        private readonly ApplicationDbContext _db;

        public SessionTokensController(IApiClient apiClient, ApplicationDbContext db)
        {
            _apiClient = apiClient;
            _db = db;
        }


        [HttpGet("{useremail}")]
        public async Task<ActionResult<HumanDTO.SessionTokenResponse>> GetSessionToken(string useremail)
        {

            var userSessionToken = await _db.SessionTokens.SingleOrDefaultAsync(s => s.UserId.ToLower() == useremail.ToLower());

            if (userSessionToken == null)
            {
                var connectSessionToken = await _apiClient.GetConnectSessionTokenAsync(useremail);

                var newSessionToken = new SessionToken
                {
                    UserId = useremail,
                    AuthToken = connectSessionToken.session_token,
                    HumanId = connectSessionToken.human_id,
                    ExpiresIn = connectSessionToken.expires_in,
                    Created = DateAndTime.Now,
                    Modified = DateAndTime.Now

                };
                await _db.SessionTokens.AddAsync(newSessionToken);
                await _db.SaveChangesAsync();

                return newSessionToken.MapSessionTokenResponse();
            }

            if (userSessionToken.Modified.AddSeconds(userSessionToken.ExpiresIn) < DateAndTime.Now)
            {
                var connectIdToken = await _apiClient.GetConnectIdTokenAsync(useremail);
                userSessionToken.RefreshToken = connectIdToken.id_refresh_token;
                userSessionToken.ExpiresIn = connectIdToken.id_token_expires_in;
                userSessionToken.AuthToken = connectIdToken.id_token;
                userSessionToken.Modified = DateAndTime.Now;
                await _db.SaveChangesAsync();
                return userSessionToken.MapSessionTokenResponse();
            }



            return userSessionToken.MapSessionTokenResponse();
        }
    }
}
