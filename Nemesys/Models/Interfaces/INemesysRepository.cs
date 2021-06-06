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
        * 
        * REPORTS
        * 
        */
        IEnumerable<Report> GetAllReports();
        Report GetReportById(int reportId);
        void CreateReport(Report report);
        Task DeleteReport(int reportId);
        Task DeleteReport(Report report);
        void UpdateReport(Report report);
        ReportViewModel GetReportViewModelById(int reportId, UserManager<ApplicationUser> _userManager);



        /*
         * 
         * INVESTIGATION
         * 
         */
        InvestigationViewModel GetInvestigationForReportId(int reportId);
        Task DeleteInvestation(Investigation investigation);
        IEnumerable<Investigation> GetAllInvestigations();
        Investigation GetInvestigationById(int investigationId);
        Investigation GetInvestigationByReportId(int reportId);
        InvestigationViewModel GetInvestigationViewModelById(int investigationId);
        bool InvestigationForReportIdExist(int reportId);
        void CreateInvestigation(Investigation investigation);
        void UpdateInvestigation(Investigation updatedInvestigation);



        /*
         * 
         * STATUS 
         * 
         */
        IEnumerable<Status> GetAllStatus();
        Status GetStatusById(int statusId);



        /*
         * 
         * TYPE OF HAZARD 
         * 
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
