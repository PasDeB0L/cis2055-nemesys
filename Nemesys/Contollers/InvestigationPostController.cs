using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nemesys.Models;
using Nemesys.Models.Interfaces;
using Nemesys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Contollers
{
    public class InvestigationPostController : Controller
    {
        private readonly INemesysRepository _nemesysRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ReportPostController> _logger;


        public InvestigationPostController(
            INemesysRepository nemesysRepository,
            UserManager<ApplicationUser> userManager,
            ILogger<ReportPostController> logger)
        {
            _nemesysRepository = nemesysRepository;
            _userManager = userManager;
            _logger = logger;
        }


        [HttpGet]
        public async Task<string> GetCurrentUserId()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            return usr?.Id;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var model = new InvestigationListViewModel()
                {
                    TotalEntries = _nemesysRepository.GetAllReports().Count(),

                    Investigations = _nemesysRepository
                    .GetAllInvestigations()
                    .OrderByDescending(b => b.DateOfAction)
                    .Select(b => new InvestigationViewModel
                    {
                        
                    })
                };

                ViewData["User"] = await GetCurrentUserId();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.Data);
                return View("Error");
            }
        }

    }
}
