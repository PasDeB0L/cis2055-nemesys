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

        


        bool UserUpvoteReportExist(string userId, int reportId);
        IEnumerable<Upvote> GetAllUpvotesUser(string userId);
        IEnumerable<Upvote> GetAllUpvotesReport(int reportId);
        void CreateUpvote(Upvote upvote);
        Task DeleteUpvotes( int reportId);

        HallOfFameListViewModel GetHallOfFameList();


        /*
        * REPORTS
        */
        IEnumerable<Report> GetAllReports();
        IEnumerable<Report> GetAllReports(string userId);
        Report GetReportById(int reportId);
        ReportListViewModel GetReportListViewModel(string userId);
        IEnumerable<ReportViewModel> GetAllReportsViewModel(IEnumerable<Report> reports, string userId);      
        ReportViewModel GetReportViewModel(Report report);
        



        /*
         * dbo.Reports UPDATES
         */
        void CreateReport(Report report);
        void CreateReport(EditReportViewModel reportEditVM);
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
        InvestigationViewModel GetInvestigationViewModel(int  id);
        InvestigationViewModel GetInvestigationViewModel(Investigation investigation);
        Investigation GetInvestigationById(int investigationId);
        Investigation GetInvestigationByReportId(int reportId);
        bool InvestigationForReportIdExist(int reportId);
        Investigation EditInvestigationViewModelToInvestigation(EditInvestigationViewModel editInvVM);
        void CreateNewInvestigation(EditInvestigationViewModel editInvVM);




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
        IEnumerable<string> GetAllStatusString();


        /*
         * TYPE OF HAZARD 
         */
        TypeOfHazardViewModel GetTypeOfHazardViewModel(TypeOfHazard typeOfHazard);
        
        /*
         * dbo.TypeOfHazard access
         */
        IEnumerable<TypeOfHazard> GetAllTypesOfHazard();
        TypeOfHazard GetTypeOfHazardById(int typeOfHazardId);
        IEnumerable<string> GetAllTypesOfHazardString();



        /*
         * AuthorViewModel
         */
        AuthorViewModel GetAuthorViewModel(string UserId);






        IEnumerable<BlogPost> GetAllBlogPosts();
        BlogPost GetBlogPostById(int blogPostId);

        void CreateBlogPost(BlogPost newBlogPost);

        void UpdateBlogPost(BlogPost updatedBlogPost);

        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
    }
}
