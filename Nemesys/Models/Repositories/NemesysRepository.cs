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
                    //existingReport.Investation = report.Investation;
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




        public ReportViewModel GetReportViewModelById(int reportId, UserManager<ApplicationUser> _userManager)
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
                    
                    Author = new AuthorViewModel()
                    {
                        Id = report.UserId,
                        Name = (_userManager.FindByIdAsync(report.UserId).Result != null) ? _userManager.FindByIdAsync(report.UserId).Result.UserName : "Anonymous"
                    },
                };

                if (InvestigationForReportIdExist(reportId) == true)
                {
                    ReportVM.Investigation = GetInvestigationForReportId(reportId);
                }
            
                return ReportVM;
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
         * INVESTIGATION
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */

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

        public async Task DeleteInvestation(Investigation investigation)
        {
            _appDbContext.Investigations.Remove(investigation);
            await _appDbContext.SaveChangesAsync();
        }

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
        public Investigation GetInvestigationById(int investigationId)
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Investigations.Include(b => b.User).FirstOrDefault(p => p.Id == investigationId);
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
                //Using Eager loading with Include
                return _appDbContext.Investigations.Include(b => b.User).FirstOrDefault(p => p.ReportId == reportId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }


        public InvestigationViewModel GetInvestigationViewModelById(int investigationId)
        {
            try
            {
                //Using Eager loading with Include
                Investigation investigation = _appDbContext.Investigations.Include(b => b.User).FirstOrDefault(p => p.Id == investigationId);

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

        public void CreateInvestigation(Investigation investigation)
        {
            try
            {
                Console.WriteLine("a");
                if (InvestigationForReportIdExist(investigation.ReportId) == false)
                {
                    Console.WriteLine("b");
                    _appDbContext.Investigations.Add(investigation);
                    Console.WriteLine("c");
                    _appDbContext.SaveChanges();
                    Console.WriteLine("ajout inv : ");
                }
                else
                {
                    Console.WriteLine("une investigation existe deja pour reportId : " + investigation.ReportId);
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
                    existingInvestigation.DateOfAction = updatedInvestigation.DateOfAction ;
                    existingInvestigation.InvestigatorDetails = updatedInvestigation.InvestigatorDetails ;
                    existingInvestigation.StatusId = updatedInvestigation.StatusId ;
                    

                    _appDbContext.Entry(existingInvestigation).State = EntityState.Modified;
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
         * 
         * 
         * 
         * 
         * STATUS 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */
        public IEnumerable<Status> GetAllStatus()
        {
            try
            {
                //Not loading related blog posts
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
                //Not loading related blog posts
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
         * 
         * 
         * 
         * 
         * 
         * TYPE OF HAZARD 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
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
