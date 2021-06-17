using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class ReportListViewModel
    {
        public int TotalEntries { get; set; }
        public IEnumerable<ReportViewModel> Reports { get; set; }

        public Task<string> UserId { get; set; }


        public SelectList Status { get; set; }
        public string SearchStatus { get; set; }

        public SelectList TypeOfHzard { get; set; }
        public string SearchTypeOfHazard { get; set; }

        public SelectList Upvote { get; set; }
        public string SearchUpvote { get; set; }

        public SelectList Date { get; set; }
        public string SearchDate { get; set; }
    }
}
