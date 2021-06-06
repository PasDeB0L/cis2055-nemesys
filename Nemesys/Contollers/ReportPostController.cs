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
using System.IO;
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
                /*
                Investigation inv = new Investigation()
                {
                    DateOfAction = DateTime.UtcNow,
                    Description = "The electrician was there and he fixed the electricity probleme",
                    InvestigatorDetails = "test@gmail",
                    StatusId = 4,
                    ReportId = 3,
                    UserId = "test@gmail"
                };

                Console.WriteLine("1");
                _nemesysRepository.CreateInvestigation(inv);
                Console.WriteLine("2 ");
                */

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
                        Location = b.Location,
                        ReporterInformations = b.ReporterInformations,
                        ImageUrl = b.ImageUrl,
                        Upvotes = b.Upvotes,

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
                        },

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
                        Location = b.Location,
                        ReporterInformations = b.ReporterInformations,
                        ImageUrl = b.ImageUrl,
                        Upvotes = b.Upvotes,
                        


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



        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            try
            {
                //Load all types Of hazard and create a list of TypeOfHazardViewModel
                var typeOfHazardList = _nemesysRepository.GetAllTypesOfHazard().Select(c => new TypeOfHazardViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

                //Pass the list into an EditReportViewModel, which is used by the View (all other properties may be left blank, unless you want to add other default values
                var model = new EditReportViewModel()
                {
                    TypeOfHazardList =typeOfHazardList
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
        public IActionResult Create([Bind("Title, Description, Location, ImageToUpload, TypeOfHazardId, Date")] EditReportViewModel newReport)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string fileName = "";
                    if (newReport.ImageToUpload != null)
                    {
                        //At this point you should check size, extension etc...
                        //Then persist using a new name for consistency (e.g. new Guid)
                        var extension = "." + newReport.ImageToUpload.FileName.Split('.')[newReport.ImageToUpload.FileName.Split('.').Length - 1];
                        fileName = Guid.NewGuid().ToString() + extension;
                        var path = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\blogposts\\" + fileName; // report
                        using (var bits = new FileStream(path, FileMode.Create))
                        {
                            newReport.ImageToUpload.CopyTo(bits);
                        }
                    }


                    Report report = new Report()
                    {
                        CreatedDate = DateTime.UtcNow,
                        Date = newReport.Date,
                        Title = newReport.Title,
                        Description = newReport.Description,
                        Location = newReport.Location,
                        ReporterInformations = _userManager.GetUserId(User), // modifier
                        ImageUrl = "/images/blogposts/" + fileName, // changer en reports apres
                        Upvotes = 0,
                        StatusId = 3, // 3 = open 
                        TypeOfHazardId = newReport.TypeOfHazardId,
                        UserId = _userManager.GetUserId(User)
                        
                    };


                    _nemesysRepository.CreateReport(report);
                    return RedirectToAction("Index");
                }
                else
                {
                    //Load all types Of hazard and create a list of TypeOfHazardViewModel
                    var typeOfHazardList = _nemesysRepository.GetAllTypesOfHazard().Select(c => new TypeOfHazardViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();


                    //Re-attach to view model before sending back to the View (this is necessary so that the View can repopulate the drop down and pre-select according to the TypeOfHazardId
                    newReport.TypeOfHazardList = typeOfHazardList;

                    return View(newReport);
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
                                ModelState.AddModelError(string.Empty, string.Format("Foreign key for type of hazard with Id '{0}' does not exists.", newReport.TypeOfHazardId));
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
                    var typeOfHazardList = _nemesysRepository.GetAllTypesOfHazard().Select(c => new TypeOfHazardViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();

                    //Re-attach to view model before sending back to the View (this is necessary so that the View can repopulate the drop down and pre-select according to the TypeOfHazardId
                    newReport.TypeOfHazardList = typeOfHazardList;
                }

                return View(newReport);
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
                var existingReport = _nemesysRepository.GetReportById(id);
                if (existingReport != null)
                {
                    //Check if the current user has access to this resource
                    var currentUser = await _userManager.GetUserAsync(User);
                    
                    if( existingReport.User.Id == currentUser.Id)
                    {                            
                        EditReportViewModel model = new EditReportViewModel()
                        {
                            Id = existingReport.Id,
                            Title = existingReport.Title,
                            CreatedDate = existingReport.CreatedDate,
                            Date = existingReport.Date,
                            Description = existingReport.Description,
                            Location = existingReport.Location,
                            ImageUrl = existingReport.ImageUrl,
                            StatusId = existingReport.StatusId,
                            TypeOfHazardId = existingReport.TypeOfHazardId
                        };


                        //Load all types Of hazard and create a list of TypeOfHazardViewModel
                        var typeOfHazardList = _nemesysRepository.GetAllTypesOfHazard().Select(c => new TypeOfHazardViewModel()
                        {
                            Id = c.Id,
                            Name = c.Name
                        }).ToList();

                        //Load all Status and create a list of StatusViewModel
                        var StatusList = _nemesysRepository.GetAllStatus().Select(c => new StatusViewModel()
                        {
                            Id = c.Id,
                            Name = c.Name
                        }).ToList();


                        //Attach to view model - view will pre-select according to the value in statusId and TypeOfHazard
                        model.TypeOfHazardList = typeOfHazardList;
                        model.StatusList = StatusList;

                        return View(model);
                    }
                    else
                    {
                        Console.WriteLine("1");
                        return Unauthorized();
                    }
                }
                else
                    return RedirectToAction("Index");
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
        public async Task<IActionResult> Edit([FromRoute] int id, [Bind("Id, Title, TypeOfHazardId, Description, Location, Date, ImageToUpload")] EditReportViewModel updatedReport)
        {
            try
            {
                var modelToUpdate = _nemesysRepository.GetReportById(id);
                if (modelToUpdate == null)
                {
                    return NotFound();
                }

                //Check if the current user has access to this resource
                var currentUser = await _userManager.GetUserAsync(User);
                if (modelToUpdate.User.Id == currentUser.Id)
                {
                    if (ModelState.IsValid)
                    {
                        Console.WriteLine("valid");
                        string imageUrl = "";

                        if (updatedReport.ImageToUpload != null)
                        {
                            string fileName = "";
                            //At this point you should check size, extension etc...
                            //Then persist using a new name for consistency (e.g. new Guid)
                            var extension = "." + updatedReport.ImageToUpload.FileName.Split('.')[updatedReport.ImageToUpload.FileName.Split('.').Length - 1];
                            fileName = Guid.NewGuid().ToString() + extension;
                            var path = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\blogposts\\" + fileName; // changer la aussi reports
                            using (var bits = new FileStream(path, FileMode.Create))
                            {
                                updatedReport.ImageToUpload.CopyTo(bits);
                            }
                            imageUrl = "/images/blogposts/" + fileName; // la aussi changer pour reports
                        }
                        else
                            imageUrl = modelToUpdate.ImageUrl;


                        modelToUpdate.Title = updatedReport.Title;
                        modelToUpdate.Description = updatedReport.Description;
                        modelToUpdate.Location = updatedReport.Location;
                        modelToUpdate.Date = updatedReport.Date;
                        modelToUpdate.ImageUrl = imageUrl;
                        modelToUpdate.TypeOfHazardId = updatedReport.TypeOfHazardId;


                        _nemesysRepository.UpdateReport(modelToUpdate);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Console.WriteLine("non valide");
                        return Unauthorized();
                    }
                }
                else
                {
                    //Load all types Of hazard and create a list of TypeOfHazardViewModel
                    var typeOfHazardList = _nemesysRepository.GetAllTypesOfHazard().Select(c => new TypeOfHazardViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    }).ToList();

                    //Re-attach to view model before sending back to the View (this is necessary so that the View can repopulate the drop down and pre-select according to the CategoryId
                    updatedReport.TypeOfHazardList = typeOfHazardList;


                    return View(updatedReport);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.Data);
                return View("Error");
            }
        }




        [HttpGet]
        public IActionResult Investigation(int id)
        {
            try
            {
                var model = _nemesysRepository.GetReportViewModelById(id, _userManager);

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
        public IActionResult Delete(int id)
        {
            try 
            {
                var model = _nemesysRepository.GetReportViewModelById(id, _userManager);

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.Data);
                return View("Error");
            }
        }

        


        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int id )
        {
            try
            {
                await _nemesysRepository.DeleteReport(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.Data);
                return View("Error");
            }
        }
        




        public IActionResult HallOfFame()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.Data);
                return View("Error");
            }
        }

    }
}
