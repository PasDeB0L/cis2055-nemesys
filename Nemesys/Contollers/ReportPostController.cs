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
    public class ReportPostController : Controller
    {
        private readonly INemesysRepository _nemesysRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ReportPostController> _logger;


        public ReportPostController(
            INemesysRepository nemesysRepository,
            UserManager<ApplicationUser> userManager,
            ILogger<ReportPostController> logger)
        {
            _nemesysRepository = nemesysRepository;
            _userManager = userManager;
            _logger = logger;
        }


        public IActionResult Index()
        {
            try
            {
                var model = new ReportListViewModel()
                {
                    TotalEntries = _nemesysRepository.GetAllReports().Count(),

                    Reports = _nemesysRepository
                    .GetAllReports()
                    .OrderByDescending(b => b.CreatedDate)
                    .Select(b => new ReportViewModel
                    {
                        Id = b.Id,
                        CreatedDate = b.CreatedDate,
                        Date = b.Date,
                        Title = b.Title,
                        Description = b.Description,
                        ReporterInformations = b.ReporterInformations,
                        ImageUrl = b.ImageUrl,
                        Upvotes = b.Upvotes,
                        Investigation = b.Investation,

                        Status = new StatusViewModel()
                        {
                            Id = b.Status.Id,
                            Name = b.Status.Name
                        },
                        Author = new AuthorViewModel()
                        {
                            Id = b.UserId,
                            Name = (_userManager.FindByIdAsync(b.UserId).Result != null) ? _userManager.FindByIdAsync(b.UserId).Result.UserName : "Anonymous"
                        }


                    })
                };
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.Data);
                return View("Error");
            }
        }


        public IActionResult Details(int id)
        {
            try
            {
                var b = _nemesysRepository.GetReportById(id);
                if (b == null)
                    return NotFound();
                else
                {
                    var model = new ReportViewModel()
                    {
                        Id = b.Id,
                        CreatedDate = b.CreatedDate,
                        Date = b.Date,
                        Title = b.Title,
                        Description = b.Description,
                        ReporterInformations = b.ReporterInformations,
                        ImageUrl = b.ImageUrl,
                        Upvotes = b.Upvotes,
                        Investigation = b.Investation,



                        Status = new StatusViewModel()
                        {
                            Id = b.Status.Id,
                            Name = b.Status.Name
                        },
                        TypeOfHazard = new TypeOfHazardViewModel()
                        {
                            Id = b.TypeOfHazard.Id,
                            Name = b.TypeOfHazard.Name
                        },

                        Author = new AuthorViewModel()
                        {
                            Id = b.UserId,
                            Name = (_userManager.FindByIdAsync(b.UserId).Result != null) ? _userManager.FindByIdAsync(b.UserId).Result.UserName : "Anonymous"
                        }

                    };

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.Data);
                return View("Error");
            }

        }


    }
}
