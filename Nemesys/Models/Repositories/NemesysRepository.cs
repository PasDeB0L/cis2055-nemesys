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

       

        public IEnumerable<Report> GetAllReports()
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Reports.Include(b => b.Status).OrderBy(b => b.DateOfReport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public Report GetReportById(int ReportId)
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Reports.Include(b => b.User).FirstOrDefault(p => p.Id == ReportId);
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
                    existingReport.Id = report.Id;
                    existingReport.Upvotes = report.Upvotes;
                    existingReport.TypeOfHasard = report.TypeOfHasard;
                    existingReport.DetailsOnTheReporter = report.DetailsOnTheReporter;
                    existingReport.Status = report.Status;
                    existingReport.ImageUrl = report.ImageUrl;
                    existingReport.Description = report.Description;
                    existingReport.Location = report.Location;
                    existingReport.DateOfReport = report.DateOfReport;
                    existingReport.DateAndTime = report.DateAndTime;
                    existingReport.Investigation = report.Investigation;
                    existingReport.UserId = report.UserId;



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
    }

}
