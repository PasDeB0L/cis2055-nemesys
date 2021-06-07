using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nemesys.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nemesys.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Nemesys.Models.Repositories
{
    public class NemesysRepository : INemesysRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger _logger;

        public NemesysRepository(AppDbContext appDbContext, ILogger<NemesysRepository> logger)
        {
            try
            {
                _appDbContext = appDbContext;
                _logger = logger;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }






        public bool UserUpvotes(string IdentityName)
        {
            return true;
        }


        /*
         * 
         * 
         * A FAIRE DISPARAITRE 
         * 
         * 
         */


        // = GetReportViewModel( GetReportById(int reportId) );
        public ReportViewModel GetReportViewModelById(int reportId)
        {
            try
            {
                //Using Eager loading with Include
                Report report = GetReportById(reportId);

                ReportViewModel ReportVM = new ReportViewModel
                {
                    Id = report.Id,
                    CreatedDate = report.CreatedDate,
                    Date = report.Date,
                    Title = report.Title,
                    Description = report.Description,
                    Location = report.Location,
                    ReporterInformations = report.ReporterInformations,
                    ImageUrl = report.ImageUrl,
                    Upvotes = report.Upvotes,

                    TypeOfHazard = new TypeOfHazardViewModel()
                    {
                        Id = report.TypeOfHazard.Id,
                        Name = report.TypeOfHazard.Name
                    },

                    Status = new StatusViewModel()
                    {
                        Id = report.Status.Id,
                        Name = report.Status.Name
                    },
                    /*
                    Author = new AuthorViewModel()
                    {
                        Id = report.UserId,
                        Name = (_userManager.FindByIdAsync(report.UserId).Result != null) ? _userManager.FindByIdAsync(report.UserId).Result.UserName : "Anonymous"
                    }
                    */
                };

                

                return ReportVM;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }


        // = GetInvestigationViewModel(  GetInvestigationByReportId(int reportId) ,  GetReportById(int reportId) )
        public InvestigationViewModel GetInvestigationForReportId(int reportId)
        {
            try
            {
                //Using Eager loading with Include
                Investigation investigation = _appDbContext.Investigations.Include(b => b.User).FirstOrDefault(p => p.ReportId == reportId);

                InvestigationViewModel InvestigationVM = new InvestigationViewModel
                {
                    Id = investigation.Id,
                    DateOfAction = investigation.DateOfAction,
                    Description = investigation.Description,
                    InvestigatorDetails = investigation.InvestigatorDetails
                };

                return InvestigationVM;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }




        public InvestigationViewModel GetInvestigationViewModelById(int investigationId, UserManager<ApplicationUser> _userManager)
        {
            try
            {
                //Using Eager loading with Include
                Investigation investigation = _appDbContext.Investigations.Include(b => b.User).FirstOrDefault(p => p.Id == investigationId);

                ReportViewModel report = GetReportViewModelById(investigation.ReportId);

                InvestigationViewModel InvestigationVM = new InvestigationViewModel
                {
                    Id = investigation.Id,
                    DateOfAction = investigation.DateOfAction,
                    Description = investigation.Description,
                    InvestigatorDetails = investigation.InvestigatorDetails,
                    Report = report,
                    /*
                    Author = new AuthorViewModel()
                    {
                        Id = investigation.UserId,
                        Name = (_userManager.FindByIdAsync(investigation.UserId).Result != null) ? _userManager.FindByIdAsync(investigation.UserId).Result.UserName : "Anonymous"
                    }
                    */
                };


                return InvestigationVM;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }






        /*
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * REPORTS 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */
        public IEnumerable<Report> GetAllReports()
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Reports.Include(b => b.Status).Include(b => b.TypeOfHazard).OrderBy(b => b.CreatedDate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public ReportListViewModel GetReportListViewModel()
        {
            IEnumerable<Report> AllReports = GetAllReports();
            
            return new ReportListViewModel
            {
                TotalEntries = AllReports.Count(),
                Reports = GetAllReportsViewModel(AllReports)
            };
        }

        public IEnumerable<ReportViewModel> GetAllReportsViewModel(IEnumerable<Report> reports)
        {
            List<ReportViewModel> ListReportsViewModel  = new List<ReportViewModel> { };

            foreach (var report in reports)
            {
                List<ReportViewModel> Listnew = ListReportsViewModel.Append( GetReportViewModel(report) ).ToList();
                ListReportsViewModel = Listnew;
            }
            
            return ListReportsViewModel;
        }

        public IEnumerable<Report> GetAllReports(string userId)
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Reports.Include(b => b.Status).Include(b => b.TypeOfHazard).Where(s => s.UserId.Contains(userId)).OrderBy(b => b.CreatedDate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }


        public ReportViewModel GetReportViewModel(Report report)
        {
            ReportViewModel reportVM = new ReportViewModel
            {
                Id = report.Id,
                CreatedDate = report.CreatedDate,
                Date = report.Date,
                Title = report.Title,
                Description = report.Description,
                Location = report.Location,
                ReporterInformations = report.ReporterInformations,
                ImageUrl = report.ImageUrl,
                Upvotes = report.Upvotes,
                Status = GetStatusViewModel(report.Status),
                TypeOfHazard = GetTypeOfHazardViewModel(report.TypeOfHazard),
                Author = GetAuthorViewModel(report.UserId),
                
            };    
            
            if ( InvestigationForReportIdExist(report.Id) )
            {
                reportVM.Investigation = GetInvestigationViewModel(GetInvestigationByReportId(report.Id));

            }

            return reportVM;
        }


        public Report GetReportById(int reportId)
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Reports.Include(b => b.Status).Include(b => b.TypeOfHazard).Include(b => b.User).FirstOrDefault(p => p.Id == reportId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        /*
         * 
         * dbo.Reports UPDATES
         * 
         */
        public void CreateReport(Report report)
        {
            try
            {
                _appDbContext.Reports.Add(report);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public void CreateReport(string Title, string Description, string Location, string  fileName, int TypeOfHazardId, int StatusId, DateTime Date, string reporterInformation, string userId)
        {
            Report report = new Report()
            {
                CreatedDate = DateTime.UtcNow,
                Date = Date,
                Title = Title,
                Description = Description,
                Location = Location,
                ReporterInformations = reporterInformation, // modifier _userManager.GetUserId(User)
                ImageUrl = "/images/blogposts/" + fileName, // changer en reports apres
                Upvotes = 0,
                StatusId = 3, // 3 = open 
                TypeOfHazardId = TypeOfHazardId,
                UserId =userId// _userManager.GetUserId(User)

            };

            CreateReport(report);
        }



        public async Task DeleteReport(int reportId)
        {
            await DeleteReport(GetReportById(reportId));
            
            if ( InvestigationForReportIdExist(reportId))
            {
                 await DeleteInvestation(GetInvestigationByReportId(reportId));
            }
        }

        public async Task DeleteReport(Report report)
        {
            _appDbContext.Reports.Remove(report);
            await _appDbContext.SaveChangesAsync();
        }

        public void UpdateReport(Report report)
        {
            try 
            {
                var existingReport = _appDbContext.Reports.SingleOrDefault(bp => bp.Id == report.Id);
                if (existingReport != null)
                {
                    existingReport.CreatedDate = report.CreatedDate;
                    existingReport.Date = report.Date;
                    existingReport.Title = report.Title;
                    existingReport.Description = report.Description;
                    existingReport.Location = report.Location;
                    existingReport.ReporterInformations = report.ReporterInformations;
                    existingReport.ImageUrl = report.ImageUrl;
                    existingReport.Upvotes = report.Upvotes;
                    existingReport.StatusId = report.StatusId;
                    existingReport.TypeOfHazardId = report.TypeOfHazardId;

                    _appDbContext.Entry(existingReport).State = EntityState.Modified;
                    _appDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }











        






        /*
         * 
         * 
         * INVESTIGATION 
         * 
         * 
         * 
         */
        public IEnumerable<Investigation> GetAllInvestigations()
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Investigations.OrderBy(b => b.DateOfAction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public IEnumerable<Investigation> GetAllInvestigations(string userId)
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Investigations.Where(s => s.UserId.Contains(userId)).OrderBy(b => b.DateOfAction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }




        
        public InvestigationListViewModel GetInvestigationListViewModel()
        {
            IEnumerable<Investigation> AllInvestigations = GetAllInvestigations();
            return new InvestigationListViewModel
            {
                TotalEntries = AllInvestigations.Count(),
                Investigations = GetAllInvestigationsViewModel(AllInvestigations)
            };
        }

        public InvestigationListViewModel GetInvestigationListViewModel(string userId)
        {
            IEnumerable<Investigation> AllInvestigations = GetAllInvestigations(userId);
            return new InvestigationListViewModel
            {
                TotalEntries = AllInvestigations.Count(),
                Investigations = GetAllInvestigationsViewModel(AllInvestigations)
            };
        }


        public IEnumerable<InvestigationViewModel> GetAllInvestigationsViewModel(IEnumerable<Investigation> investigations)
        {
            List < InvestigationViewModel > ListInvestigationViewModel = new List<InvestigationViewModel> { };

            foreach (var inv in investigations)
            {
                List<InvestigationViewModel> Listnew = ListInvestigationViewModel.Append( (GetInvestigationViewModel(inv, GetReportById(inv.ReportId)))).ToList();
                ListInvestigationViewModel = Listnew;
            }
            return ListInvestigationViewModel;
        }

        public InvestigationViewModel GetInvestigationViewModel(Investigation investigation, Report report)
        {
            return new InvestigationViewModel
            {
                Id = investigation.Id,
                DateOfAction = investigation.DateOfAction,
                Description = investigation.Description,
                InvestigatorDetails = investigation.InvestigatorDetails,
                Report = GetReportViewModel(report)
            };
        }


        public  InvestigationViewModel GetInvestigationViewModel(int id)
        {
            InvestigationViewModel invVM = GetInvestigationViewModel( GetInvestigationById(id) );
            invVM.Report = GetReportViewModelById(invVM.Report.Id);
            return invVM;
        }




        public InvestigationViewModel GetInvestigationViewModel(Investigation investigation)
        {
            return new InvestigationViewModel
            {
                Id = investigation.Id,
                DateOfAction = investigation.DateOfAction,
                Description = investigation.Description,
                InvestigatorDetails = investigation.InvestigatorDetails,
                Report = new ReportViewModel
                {
                    Id = investigation.ReportId
                }
            };
        }
        



        public Investigation GetInvestigationById(int investigationId)
        {
            try
            {
                //Using Eager loading with Include
                Investigation inv =   _appDbContext.Investigations.Include(b => b.User).FirstOrDefault(p => p.Id == investigationId);
                inv.Report = GetReportById(inv.ReportId);
                return inv;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }


        public Investigation GetInvestigationByReportId(int reportId)
        {
            try
            {
                if (InvestigationForReportIdExist(reportId))
                {
                    //Using Eager loading with Include
                    return _appDbContext.Investigations.Include(b => b.User).FirstOrDefault(p => p.ReportId == reportId);
                }
                else
                    return null;
            }
                
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public bool InvestigationForReportIdExist(int reportId)
        {
            //Using Eager loading with Include
            Investigation investigation = _appDbContext.Investigations.Include(b => b.User).FirstOrDefault(p => p.ReportId == reportId);

            if (investigation == null)
            {
                return false;
            }
            return true;
        }


        public Investigation EditInvestigationViewModelToInvestigation(EditInvestigationViewModel editInvVM)
        {
            return new Investigation
            {
                DateOfAction = editInvVM.DateOfAction,
                Description = editInvVM.Description,
                InvestigatorDetails = editInvVM.Author.Name,
                ReportId = editInvVM.Report.Id,
                StatusId = editInvVM.StatusId,
                UserId = editInvVM.Author.Id
            };
        }

        public void CreateNewInvestigation(EditInvestigationViewModel editInvVM)
        {
            CreateInvestigation((EditInvestigationViewModelToInvestigation(editInvVM)));
        }



        /*
         * 
         * dbo.Investigations UPDATES
         * 
         */
        public void CreateInvestigation(Investigation investigation)
        {
            try
            {
                if (InvestigationForReportIdExist(investigation.ReportId) == false)
                {
                    _appDbContext.Investigations.Add(investigation);

                    var existingReport = _appDbContext.Reports.SingleOrDefault(bp => bp.Id == investigation.ReportId);
                    if (existingReport != null)
                    {
                        existingReport.StatusId = investigation.StatusId;

                        _appDbContext.Entry(existingReport).State = EntityState.Modified;
                        _appDbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public void UpdateInvestigation(Investigation updatedInvestigation)
        {
            try
            {
                var existingInvestigation = _appDbContext.Investigations.SingleOrDefault(bp => bp.Id == updatedInvestigation.Id);
                
                if (existingInvestigation != null)
                {
                    existingInvestigation.Description = updatedInvestigation.Description;
                    existingInvestigation.DateOfAction = updatedInvestigation.DateOfAction;
                    existingInvestigation.InvestigatorDetails = updatedInvestigation.InvestigatorDetails;
                    existingInvestigation.StatusId = updatedInvestigation.StatusId;


                    var existingReport = _appDbContext.Reports.SingleOrDefault(bp => bp.Id == existingInvestigation.ReportId);
                    if (existingReport != null)
                    {
                        existingReport.StatusId = existingInvestigation.StatusId;

                        _appDbContext.Entry(existingInvestigation).State = EntityState.Modified;
                        _appDbContext.Entry(existingReport).State = EntityState.Modified;
                        _appDbContext.SaveChanges();
                    }                   
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task DeleteInvestation(Investigation investigation)
        {
            _appDbContext.Investigations.Remove(investigation);
            await _appDbContext.SaveChangesAsync();
        }















        /*
         * 
         * 
         * STATUS 
         *
         *
         */
        public StatusViewModel GetStatusViewModel(Status status)
        {
            return new StatusViewModel
            {
                Id = status.Id,
                Name = status.Name
            };
        }

        /*
         * 
         * dbo.Status access
         * 
         */
        public IEnumerable<Status> GetAllStatus()
        {
            try
            {
               
                return _appDbContext.Status;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public Status GetStatusById(int statusId)
        {
            try
            {
                return _appDbContext.Status.FirstOrDefault(c => c.Id == statusId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }









        /*
         * 
         * 
         * TYPE OF HAZARD 
         * 
         * 
         */
        public TypeOfHazardViewModel GetTypeOfHazardViewModel(TypeOfHazard typeOfHazard)
        {
            return new TypeOfHazardViewModel
            {
                Id = typeOfHazard.Id,
                Name = typeOfHazard.Name
            };
        }

        /*
         * 
         * dbo.TypeOfHazard access
         * 
         */
        public IEnumerable<TypeOfHazard> GetAllTypesOfHazard()
        {
            try
            {
                //Not loading related report
                return _appDbContext.TypeOfHazard;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        public TypeOfHazard GetTypeOfHazardById(int typeOfHazardId)
        {
            try
            {
                //Not loading related blog posts
                return _appDbContext.TypeOfHazard.FirstOrDefault(c => c.Id == typeOfHazardId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }




        /*
         * 
         * AuthorViewModel
         * 
         */
        public AuthorViewModel GetAuthorViewModel(string  UserId)
        {
            return new AuthorViewModel
            {
                Id = UserId,
                Name = _appDbContext.Users.FirstOrDefault(c => c.Id == UserId).UserName
            };
        }

























        /*
         * 
         * 
         * 
         * 
         * BLOGGY
         * 
         * 
         * 
         */

        public IEnumerable<Category> GetAllCategories()
        {
            try
            {
                //Not loading related blog posts
                return _appDbContext.Categories;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            try
            {
                //Not loading related blog posts
                return _appDbContext.Categories.FirstOrDefault(c => c.Id == categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }



        public IEnumerable<BlogPost> GetAllBlogPosts()
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.BlogPosts.Include(b => b.Category).OrderBy(b => b.CreatedDate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public BlogPost GetBlogPostById(int blogPostId)
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.BlogPosts.Include(b => b.Category).Include(b => b.User).FirstOrDefault(p => p.Id == blogPostId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public void CreateBlogPost(BlogPost blogPost)
        {
            try
            {
                _appDbContext.BlogPosts.Add(blogPost);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public void UpdateBlogPost(BlogPost blogPost)
        {
            try
            {
                var existingBlogPost = _appDbContext.BlogPosts.SingleOrDefault(bp => bp.Id == blogPost.Id);
                if (existingBlogPost != null)
                {
                    existingBlogPost.Title = blogPost.Title;
                    existingBlogPost.Content = blogPost.Content;
                    existingBlogPost.UpdatedDate = blogPost.UpdatedDate;
                    existingBlogPost.ImageUrl = blogPost.ImageUrl;
                    existingBlogPost.CategoryId = blogPost.CategoryId;
                    existingBlogPost.UserId = blogPost.UserId;

                    _appDbContext.Entry(existingBlogPost).State = EntityState.Modified;
                    _appDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

    }
}
