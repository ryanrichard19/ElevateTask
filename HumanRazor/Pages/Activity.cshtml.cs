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
    public class ActivityModel : PageModel
    {
        private readonly ILogger<ActivityModel> _logger;
        private readonly IApiClient _humanAPIService;
        public List<ActivityDataModel> activitySummary { get; set; }
       

        public ActivityModel(ILogger<ActivityModel> logger, IApiClient humanAPIService)
        {
            _logger = logger;
            _humanAPIService = humanAPIService;
        }

        public async Task OnGet()
        {
            activitySummary = await _humanAPIService.GetActivySummaryAsync();
        }
    }
}
