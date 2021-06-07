using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var usr = await GetCurrentUserId();

                var model = _nemesysRepository.GetInvestigationListViewModel(usr);

                ViewData["User"] = usr;

                return View(model);




                /*
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

                */

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.Data);
                return View("Error");
            }
        }




        [HttpGet]
        [Authorize]
        public IActionResult Create(int id)
        {
            try
            {
                //Load all types Of hazard and create a list of TypeOfHazardViewModel
                var statusList = _nemesysRepository.GetAllStatus().Select(c => new StatusViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();



                ReportViewModel report = _nemesysRepository.GetReportViewModel(_nemesysRepository.GetReportById(id));


                //Pass the list into an EditReportViewModel, which is used by the View (all other properties may be left blank, unless you want to add other default values
                var model = new EditInvestigationViewModel()
                {
                    Report = report,
                    StatusList = statusList
                };


                //Pass model to View
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.Data);
                return View("Error");
            }
        }

        // POST: ReportPost/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(int id ,[Bind(" Description, StatusId, DateOfAction")] EditInvestigationViewModel newInvestigation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine(1);

                    var currentUser = await _userManager.GetUserAsync(User);

                    

                    newInvestigation.Author = _nemesysRepository.GetAuthorViewModel(currentUser.Id);
                    Console.WriteLine("avant");
                   
                    newInvestigation.Report = new ReportViewModel
                    {
                        Id = id
                    };

                    Console.WriteLine("apres");

                    _nemesysRepository.CreateNewInvestigation(newInvestigation);

                    Console.WriteLine(3);
                    return RedirectToAction("Index");
                }
                else
                {
                    //Load all types Of hazard and create a list of TypeOfHazardViewModel
                    var statusList = _nemesysRepository.GetAllStatus().Select(c => new StatusViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();


                    //Re-attach to view model before sending back to the View (this is necessary so that the View can repopulate the drop down and pre-select according to the StatusId
                    newInvestigation.StatusList = statusList;

                    return View(newInvestigation);
                }
            }
            catch (DbUpdateException e)
            {
                SqlException s = e.InnerException as SqlException;
                if (s != null)
                {
                    switch (s.Number)
                    {
                        case 547:  //Unique constraint error
                            {
                                ModelState.AddModelError(string.Empty, string.Format("Foreign key for status with Id '{0}' does not exists.", newInvestigation.StatusList));
                                break;
                            }
                        default:
                            {
                                ModelState.AddModelError(string.Empty,
                                 "A database error occured - please contact your system administrator.");
                                break;
                            }
                    }


                    //Load all types Of hazard and create a list of TypeOfHazardViewModel
                    var statusList = _nemesysRepository.GetAllStatus().Select(c => new StatusViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();

                    //Re-attach to view model before sending back to the View (this is necessary so that the View can repopulate the drop down and pre-select according to the TypeOfHazardId
                    newInvestigation.StatusList = statusList;
                }

                return View(newInvestigation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.Data);
                return View("Error");
            }
        }
    }
}
