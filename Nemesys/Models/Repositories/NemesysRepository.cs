using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nemesys.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nemesys.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.IO;

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


        public bool UserUpvoteReportExist(string userId, int reportId) // return TRUE if the user already voted for the reportId and FALSE otherwise
        {           
            Upvote upvote = _appDbContext.Upvotes.Include(b => b.User).Include(b => b.Report).Where(s => s.UserId.Contains(userId)).Where(p => p.ReportId == reportId).FirstOrDefault();
            if (upvote != null)
                return false;
            else
                return true;
        }

        public IEnumerable<Upvote> GetAllUpvotesUser(string userId)  // return all the Upvotes for a UserId
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Upvotes.Where(s => s.UserId.Contains(userId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public IEnumerable<Upvote> GetAllUpvotesReport(int reportId)  // return all the Upvotes for a ReportId
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Upvotes.Where(s => s.ReportId == reportId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }





        public void CreateUpvote(Upvote upvote)  // create a nex Upvote in the DB
        {
            try
            {
                _appDbContext.Upvotes.Add(upvote);

                var existingReport = _appDbContext.Reports.SingleOrDefault(bp => bp.Id == upvote.ReportId);
                
                if (existingReport != null)
                {
                    existingReport.Upvotes++;
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





        public async Task DeleteUpvotes(int reportId) // ask for all the Upvote with reportId and then ask to delete them all
        {
            await DeleteUpvotes(GetAllUpvotesReport(reportId));
        }

        public async Task DeleteUpvotes(IEnumerable <Upvote> upvote)
        {
            foreach( var vote in upvote)
            {
                _appDbContext.Upvotes.Remove(vote);
            }
            await _appDbContext.SaveChangesAsync();
        }


        public HallOfFameListViewModel GetHallOfFameList() // return HallOffFameList
        {
            IEnumerable<Report> AllReports = _appDbContext.Reports.Include(b => b.User).Where(c => c.CreatedDate > DateTime.UtcNow.AddYears(-1)); // select all the report done since 1 year
            
            IEnumerable<string> ListUsersId =  AllReports.Select(d => d.UserId).Distinct(); // select only the distinct user who did a report

            List<HallOfFameViewModel> hallOfFame = new List<HallOfFameViewModel> { };

            foreach ( var usrId in ListUsersId)
            {
                hallOfFame.Add(new HallOfFameViewModel
                {
                    Authors = GetAuthorViewModel(usrId),
                    NumberOfReport = AllReports.Where(d => d.UserId == usrId).Count()
                });
            }

            IEnumerable<HallOfFameViewModel> hallOfFameOrderBy = hallOfFame.OrderByDescending(b => b.NumberOfReport); // with that we have the list order by the number of report done for each user for the hall of fame

            HallOfFameListViewModel HoFList = new HallOfFameListViewModel
            {
                TotalReporters = ListUsersId.Count(),
                HallOfFame = hallOfFameOrderBy
            };

            return HoFList;
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
       

        public IEnumerable<Report> GetAllReports()  // return all reports
        {
            try
            {
                //Using Eager loading with Include
                return _appDbContext.Reports.Include(b => b.Status).Include(b => b.TypeOfHazard).OrderByDescending(b => b.CreatedDate) ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public ReportListViewModel GetReportListViewModel(string userId) // return ReportListViewModel with all the reports done
        {
            IEnumerable<Report> AllReports = GetAllReports();

            return new ReportListViewModel
            {
                TotalEntries = AllReports.Count(),

                Reports = GetAllReportsViewModel(AllReports, userId)
            };
        }

        public IEnumerable<ReportViewModel> GetAllReportsViewModel(IEnumerable<Report> reports, string userId) // return all the ReportViewModel
        {
            List<ReportViewModel> ListReportsViewModel  = new List<ReportViewModel> { };

            foreach (var report in reports)
            {
                ReportViewModel reportVM = GetReportViewModel(report);
                
                reportVM.UserUpVote = UserUpvoteReportExist(userId, reportVM.Id);

                List<ReportViewModel> Listnew = ListReportsViewModel.Append( reportVM ).ToList();
                ListReportsViewModel = Listnew;
            }
            
            return ListReportsViewModel;
        }


        public IEnumerable<Report> GetAllReports(string userId)  // get all Report with the UserId
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


        public ReportViewModel GetReportViewModel(Report report) // changes Report to ReportViewModel
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
                Author = GetAuthorViewModel(report.UserId)
            };    
            
            if ( InvestigationForReportIdExist(report.Id) )
            {
                reportVM.Investigation = GetInvestigationViewModel(GetInvestigationByReportId(report.Id));
            }

            return reportVM;
        }


        public Report GetReportById(int reportId)  // return the report with the same id as reportId
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

        public void CreateReport( EditReportViewModel reportEditVM)  // transform EditReportViewModel to Report and then calls CreateReport(report)
        {
            string fileName = "";
            
            if (reportEditVM.ImageToUpload != null)
            {
                var extension = "." + reportEditVM.ImageToUpload.FileName.Split('.')[reportEditVM.ImageToUpload.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension;
                var path = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\reports\\" + fileName; // report
                using (var bits = new FileStream(path, FileMode.Create))
                {
                    reportEditVM.ImageToUpload.CopyTo(bits);
                }
            }



            string reporterInfo = "Mail: " + reportEditVM.Author.Mail;
            if (!reportEditVM.Author.Mail.Equals(reportEditVM.Author.Alias) && (reportEditVM.Author.Alias!=null) )
                reporterInfo += " | Alias: " + reportEditVM.Author.Alias;
            if (reportEditVM.Author.PhoneNumber!=null)
                reporterInfo += " | Phone number: " + reportEditVM.Author.PhoneNumber;
            

            Report report = new Report()
            {
                CreatedDate = DateTime.UtcNow,
                Date = reportEditVM.Date,
                Title = reportEditVM.Title,
                Description = reportEditVM.Description,
                Location = reportEditVM.Location,
                ReporterInformations = reporterInfo,
                ImageUrl = "/images/reports/" + fileName, 
                Upvotes = 0,
                StatusId = 1, // 1 = open 
                TypeOfHazardId = reportEditVM.TypeOfHazardId,
                UserId = reportEditVM.Author.Id
            };

            CreateReport(report);
        }




        /*
         * 
         * dbo.Reports UPDATES
         * 
         */
        public void CreateReport(Report report) // add Report in the Db
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
        


        public async Task DeleteReport(int reportId)  // calls DeleteReport( GetReportById( reportId)) and then calls DeleteInvestigation( reportId) and DeleteUpvote(reportId)
        {
            await DeleteReport(GetReportById(reportId));
            
            if ( InvestigationForReportIdExist(reportId))
            {
                 await DeleteInvestation(GetInvestigationByReportId(reportId));
            }

            await DeleteUpvotes(reportId);
        }

        public async Task DeleteReport(Report report)  // delete reportin the DB 
        {
            _appDbContext.Reports.Remove(report);
            await _appDbContext.SaveChangesAsync();
        }

        public void UpdateReport(Report report)  // update the reports in the Db
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
                    existingReport.Upvotes = report.Upvotes;

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
        public IEnumerable<Investigation> GetAllInvestigations()  // return all the Investigations
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

        public IEnumerable<Investigation> GetAllInvestigations(string userId)  // return all the Investigatione done by UserId
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




         


        public InvestigationListViewModel GetInvestigationListViewModel(string userId)  // return InvestigationListViewModel for UserID
        {
            IEnumerable<Investigation> AllInvestigations = GetAllInvestigations(userId);
            return new InvestigationListViewModel
            {
                TotalEntries = AllInvestigations.Count(),
                Investigations = GetAllInvestigationsViewModel(AllInvestigations)
            };
        }


        public IEnumerable<InvestigationViewModel> GetAllInvestigationsViewModel(IEnumerable<Investigation> investigations) // changes List of Investigation to a list of InvestigationViewModel
        {
            List < InvestigationViewModel > ListInvestigationViewModel = new List<InvestigationViewModel> { };

            foreach (var inv in investigations)
            {
                List<InvestigationViewModel> Listnew = ListInvestigationViewModel.Append( (GetInvestigationViewModel(inv, GetReportById(inv.ReportId)))).ToList();
                ListInvestigationViewModel = Listnew;
            }
            return ListInvestigationViewModel;
        }


        public InvestigationViewModel GetInvestigationViewModel(Investigation investigation, Report report) // return InvestigationViewModel
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



        public  InvestigationViewModel GetInvestigationViewModel(int id)  // return InvestigationeViewModel with id
        {
            InvestigationViewModel invVM = GetInvestigationViewModel( GetInvestigationById(id) );

            invVM.Report = GetReportViewModel(GetReportById(invVM.Report.Id));
            return invVM;
        }




        public InvestigationViewModel GetInvestigationViewModel(Investigation investigation)  // transform Investigation into InvestigatioViewModel
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
        



        public Investigation GetInvestigationById(int investigationId)  // return INvestigation with the id 
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


        public Investigation GetInvestigationByReportId(int reportId)  // return INvestigation with the reportId
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

        public bool InvestigationForReportIdExist(int reportId) // tell if there is an investigation or not with the reportId
        {
            //Using Eager loading with Include
            Investigation investigation = _appDbContext.Investigations.Include(b => b.User).FirstOrDefault(p => p.ReportId == reportId);

            if (investigation == null)
            {
                return false;
            }
            return true;
        }


        public Investigation EditInvestigationViewModelToInvestigation(EditInvestigationViewModel editInvVM) // transform EditInvestigation in an Investigation 
        {
            string investigatorInfo = "Mail: " + editInvVM.Author.Mail;
            
            if (!editInvVM.Author.Mail.Equals(editInvVM.Author.Alias) && (editInvVM.Author.Alias != null))
                investigatorInfo += " | Alias: " + editInvVM.Author.Alias;
            if (editInvVM.Author.PhoneNumber != null)
                investigatorInfo += " | Phone number: " + editInvVM.Author.PhoneNumber;


            return new Investigation
            {
                DateOfAction = editInvVM.DateOfAction,
                Description = editInvVM.Description,
                InvestigatorDetails = investigatorInfo,
                ReportId = editInvVM.Report.Id,
                StatusId = editInvVM.StatusId,
                UserId = editInvVM.Author.Id
            };
        }

        public void CreateNewInvestigation(EditInvestigationViewModel editInvVM) // create a new investigation
        {
            CreateInvestigation((EditInvestigationViewModelToInvestigation(editInvVM)));
        }



        /*
         * 
         * dbo.Investigations UPDATES
         * 
         */        
        public void CreateInvestigation(Investigation investigation)  // create a new investigation
        {
            try
            {
                if (InvestigationForReportIdExist(investigation.ReportId) == false) // if there isnt any investigation on the report
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

        public void UpdateInvestigation(Investigation updatedInvestigation)  // Update the investigation
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

        public async Task DeleteInvestation(Investigation investigation)  // Delete the investigation
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
        public StatusViewModel GetStatusViewModel(Status status) // transform status in statusViewModel
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
        public IEnumerable<Status> GetAllStatus()  // return all status
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

        

        public IEnumerable<string> GetAllStatusString() // return the status in a String list 
        {
            try
            {
                //Not loading related report

                var AllStatus = _appDbContext.Status;
                List<string> listStatus = new List<string> { };

                foreach (var Status in AllStatus)
                {
                    listStatus.Add(Status.Name);
                }
                return listStatus;
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
        public TypeOfHazardViewModel GetTypeOfHazardViewModel(TypeOfHazard typeOfHazard)  // transform TypeOfHazard in TypeOfHazardViewModel 
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
        public IEnumerable<TypeOfHazard> GetAllTypesOfHazard()  // return all the TypeOfHazard
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

        public IEnumerable<string> GetAllTypesOfHazardString()  // return all the type of hazard in string 
        {
            try
            {
                //Not loading related report

                var ToH = _appDbContext.TypeOfHazard;
                List<string> listType = new List<string> { };

                foreach ( var Type in ToH)
                {
                    listType.Add(Type.Name);
                }
                return listType;
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
        public AuthorViewModel GetAuthorViewModel(string UserId)  // return the Authorview model 
        {
            return new AuthorViewModel
            {
                Id = UserId,
                Mail = _appDbContext.Users.FirstOrDefault(c => c.Id == UserId).UserName,
                Alias = _appDbContext.Users.FirstOrDefault(c => c.Id == UserId).AuthorAlias,
                PhoneNumber = _appDbContext.Users.FirstOrDefault(c => c.Id == UserId).PhoneNumber
            };
        }
    }
}
