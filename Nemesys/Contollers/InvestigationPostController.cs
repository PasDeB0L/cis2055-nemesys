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
    [Authorize(Roles = "Investigator")]
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
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var usr = await GetCurrentUserId();

                var model = _nemesysRepository.GetInvestigationListViewModel(usr);

                ViewData["User"] = usr;

                return View(model);
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
                //Load all status and create a list of TypeOfHazardViewModel
                var statusList = _nemesysRepository.GetAllStatus().Select(c => new StatusViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

                statusList.RemoveAt(0);

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
                    var currentUser = await _userManager.GetUserAsync(User);

                    newInvestigation.Author = _nemesysRepository.GetAuthorViewModel(currentUser.Id);
                   
                    newInvestigation.Report = new ReportViewModel
                    {
                        Id = id
                    };
                    
                    _nemesysRepository.CreateNewInvestigation(newInvestigation);

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

        

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var existingInvestigation = _nemesysRepository.GetInvestigationById(id);
                if (existingInvestigation != null)
                {
                    //Check if the current user has access to this resource
                    var currentUser = await _userManager.GetUserAsync(User);

                    if (existingInvestigation.User.Id == currentUser.Id)
                    {
                        EditInvestigationViewModel model = new EditInvestigationViewModel()
                        {
                            Id = existingInvestigation.Id,
                            DateOfAction = existingInvestigation.DateOfAction,
                            Description = existingInvestigation.Description,
                            StatusId = existingInvestigation.StatusId,
                            Report = _nemesysRepository.GetReportViewModel(existingInvestigation.Report)
                        };

                        //Load all Status and create a list of StatusViewModel
                        var StatusList = _nemesysRepository.GetAllStatus().Select(c => new StatusViewModel()
                        {
                            Id = c.Id,
                            Name = c.Name
                        }).ToList();

                        //Attach to view model - view will pre-select according to the value in statusId
                        model.StatusList = StatusList;

                        return View(model);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.Data);
                return View("Error");
            }
        }


        
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, [Bind("Id, StatusId, Description, DateOfAction")] EditInvestigationViewModel updatedInvestigation)
        {
            try
            {
                var modelToUpdate = _nemesysRepository.GetInvestigationById(id);
                if (modelToUpdate == null)
                {
                    return NotFound();
                }

                //Check if the current user has access to this resource
                var currentUser = await _userManager.GetUserAsync(User);
                if (modelToUpdate.User.Id == currentUser.Id)
                {
                    Console.WriteLine(4);
                    if (ModelState.IsValid)
                    {
                        Console.WriteLine(5);
                        modelToUpdate.Description = updatedInvestigation.Description;
                        modelToUpdate.DateOfAction = updatedInvestigation.DateOfAction;
                        modelToUpdate.StatusId = updatedInvestigation.StatusId;

                        _nemesysRepository.UpdateInvestigation(modelToUpdate);
                        
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    //Load all types Of hazard and create a list of TypeOfHazardViewModel
                    var statusList = _nemesysRepository.GetAllStatus().Select(c => new StatusViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();

                    //Re-attach to view model before sending back to the View (this is necessary so that the View can repopulate the drop down and pre-select according to the CategoryId
                    updatedInvestigation.StatusList = statusList;

                    return View(updatedInvestigation);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.Data);
                return View("Error");
            }
        }




        [HttpGet]
        [Authorize]
        public IActionResult Details(int id)
        {
            try
            {
                var model = _nemesysRepository.GetInvestigationViewModel(id);
                    //_nemesysRepository.GetReportViewModel(_nemesysRepository.GetReportById(id));


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
