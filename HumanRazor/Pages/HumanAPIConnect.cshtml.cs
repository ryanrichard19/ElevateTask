using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanRazor.Models;
using HumanRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HumanRazor.Pages
{
    public class HumanAPIConnectModel : PageModel
    {
        private readonly ILogger<HumanAPIConnectModel> _logger;
        private readonly IHumanAPIService _humanAPIService;
        public string sessionToken { get; set; }
        private SessionTokenModel sessionTokenModel { get; set; }

        public HumanAPIConnectModel(ILogger<HumanAPIConnectModel> logger, IHumanAPIService humanAPIService)
        {
            _logger = logger;
            _humanAPIService = humanAPIService;
        }

        public async Task OnGet()
        {
            sessionTokenModel = await _humanAPIService.GetSessionTokenAsync();
            sessionToken = sessionTokenModel.session_token;
        }
    }
}
