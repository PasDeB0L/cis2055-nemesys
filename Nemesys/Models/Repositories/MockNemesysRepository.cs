using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nemesys.Models.Interfaces;



namespace Nemesys.Models.Repositories
{
    public class MockNemesysRepository : INemesysRepository
    {
        private List<Report> _reports;
        private List<Investigation> _investigations;
        private List<Status> _status;
        private List<TypeOfHasard> _typeOfHasard;

        public MockNemesysRepository()
        {
            if (_reports == null)
            {
                InitializeReport();
            }

            if (_investigations == null)
            {
                InitializeInvestigation();
            }

            if (_status == null)
            {
                InitializeStatus();
            }

            if (_typeOfHasard == null)
            {
                InitializeTypeOfHasard();
            }
        }

        public void InitializeReport()
        {

        }

        public void InitializeInvestigation()
        {

        }

        public void InitializeStatus()
        {
            _status = new List<Status>()  
            {
                new Status()
                {
                    Id = 1,
                    Name = "open"
                },
                new Status()
                {
                    Id = 2,
                    Name = "closed"
                },
                new Status()
                {
                    Id = 3,
                    Name = "being investigated"
                },
                new Status()
                {
                    Id = 4,
                    Name = "no action required"
                }

            };

        }
        public void InitializeTypeOfHasard()
        {
            _typeOfHasard = new List<TypeOfHasard>()
            {
                new TypeOfHasard()
                {
                    Id = 1,
                    Name = "e.g. unsafe act"
                },
                new TypeOfHasard()
                {
                    Id = 2,
                    Name = "condition"
                },
                new TypeOfHasard()
                {
                    Id = 3,
                    Name = "equipment"
                },
                new TypeOfHasard()
                {
                    Id = 4,
                    Name = "structure"
                }
            };
        }



        public IEnumerable<Report> GetAllReports()
        {
            List<Report> result = new List<Report>();
            foreach (var report in _reports)
            {
                report.Status = _status.FirstOrDefault(c => c.Id == report.StatusId);
                result.Add(report);
            }
            return result;

        }

        public Report GetReportById(int ReportId)
        {
            var report = _reports.FirstOrDefault(p => p.Id == ReportId); //if not found, it returns null
            var status = _status.FirstOrDefault(c => c.Id == report.StatusId);
            report.Status = status;
            return report;
        }

        public void CreateReport(Report report)
        {
            report.Id = _reports.Count + 1;
            _reports.Add(report);
        }

        public void UpdateReport(Report report)
        {
            var existingReport = _reports.FirstOrDefault(p => p.Id == report.Id);

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
                existingReport.User = report.User;
            }           
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return _status;
        }

        public Status GetStatusById(int statusId)
        {
            return _status.FirstOrDefault(c => c.Id == statusId); //if not found, it returns null
        }
    }
}
