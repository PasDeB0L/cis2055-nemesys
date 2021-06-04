using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nemesys.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

        public IEnumerable<BlogPost> GetAllBlogPosts()
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.BlogPosts.Include(b => b.Category).OrderBy(b => b.CreatedDate);
            }
            catch(Exception ex)
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


        public IEnumerable<Report> GetAllReports()
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Reports.Include(b => b.Status).OrderBy(b => b.CreatedDate);
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
                return _appDbContext.Reports.Include(b => b.Status).Include(b => b.User).FirstOrDefault(p => p.Id == reportId);
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
                    existingReport.Investation = report.Investation;
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

        public IEnumerable<TypeOfHazard> GetAllTypesOfHazard()
        {
            try
            {
                //Not loading related blog posts
                return _appDbContext.TypeOfHazards;
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
                return _appDbContext.TypeOfHazards.FirstOrDefault(c => c.Id == typeOfHazardId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
