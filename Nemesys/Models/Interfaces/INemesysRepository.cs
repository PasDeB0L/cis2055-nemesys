using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models.Interfaces
{
    public interface INemesysRepository
    {
        IEnumerable<Report> GetAllReports();
        Report GetReportById(int blogPostId);

        void CreateReport(Report newBlogPost);

        void UpdateReport(Report updatedReport);

        IEnumerable<Status> GetAllStatus();
        Status GetStatusById(int statusId);
    }
}
