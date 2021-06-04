using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models.Interfaces
{
    public interface INemesysRepository
    {
        IEnumerable<BlogPost> GetAllBlogPosts();
        BlogPost GetBlogPostById(int blogPostId);

        void CreateBlogPost(BlogPost newBlogPost);

        void UpdateBlogPost(BlogPost updatedBlogPost);

        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);



        /*
         * 
         * pour nemesys
         * 
         */
        IEnumerable<Report> GetAllReports();
        Report GetReportById(int reportId);

        void CreateReport(Report report);

        void UpdateReport(Report updatedReport);

        IEnumerable<Status> GetAllStatus();
        Status GetStatusById(int statusId);

        IEnumerable<TypeOfHazard> GetAllTypesOfHazard();
        TypeOfHazard GetTypeOfHazardById(int typeOfHazardId);
    }

}
