using Microsoft.AspNetCore.Identity;
using Nemesys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models.Interfaces
{
    public interface INemesysRepository
    {
        /*
        * REPORTS
        */
        IEnumerable<Report> GetAllReports();
        IEnumerable<Report> GetAllReports(string userId);

        ReportListViewModel GetReportListViewModel();
        IEnumerable<ReportViewModel> GetAllReportsViewModel(IEnumerable<Report> reports);      
        ReportViewModel GetReportViewModel(Report report);
        Report GetReportById(int reportId);



        /*
         * dbo.Reports UPDATES
         */
        void CreateReport(Report report);
        void CreateReport(string Title, string Description, string Location, string fileName, int TypeOfHazardId, int StatusId, DateTime Date, string reporterInformation, string userId);
        Task DeleteReport(int reportId);
        Task DeleteReport(Report report);
        void UpdateReport(Report report);





        /*
         * INVESTIGATION
         */
        IEnumerable<Investigation> GetAllInvestigations();
        IEnumerable<Investigation> GetAllInvestigations(string userId);
        InvestigationListViewModel GetInvestigationListViewModel();
        InvestigationListViewModel GetInvestigationListViewModel(string userId);
        IEnumerable<InvestigationViewModel> GetAllInvestigationsViewModel(IEnumerable<Investigation> investigations);
        InvestigationViewModel GetInvestigationViewModel(Investigation investigation, Report report);
        Investigation GetInvestigationById(int investigationId);
        Investigation GetInvestigationByReportId(int reportId);
        bool InvestigationForReportIdExist(int reportId);

        /*
         * dbo.Investigations UPDATES
         */
        void CreateInvestigation(Investigation investigation);
        void UpdateInvestigation(Investigation updatedInvestigation);
        Task DeleteInvestation(Investigation investigation);







        /*
         * STATUS 
         */
        StatusViewModel GetStatusViewModel(Status status);
        
        /*
         * dbo.Status access
         */
        IEnumerable<Status> GetAllStatus();
        Status GetStatusById(int statusId);



        /*
         * TYPE OF HAZARD 
         */
        TypeOfHazardViewModel GetTypeOfHazardViewModel(TypeOfHazard typeOfHazard);
        
        /*
         * dbo.TypeOfHazard access
         */
        IEnumerable<TypeOfHazard> GetAllTypesOfHazard();
        TypeOfHazard GetTypeOfHazardById(int typeOfHazardId);










        IEnumerable<BlogPost> GetAllBlogPosts();
        BlogPost GetBlogPostById(int blogPostId);

        void CreateBlogPost(BlogPost newBlogPost);

        void UpdateBlogPost(BlogPost updatedBlogPost);

        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
    }
}
