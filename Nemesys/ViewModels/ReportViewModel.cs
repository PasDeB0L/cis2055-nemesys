using Nemesys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class ReportViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ReporterInformations { get; set; }
        public string ImageUrl { get; set; }
        public int Upvotes { get; set; }

        public bool UserUpVote { get; set; }

        public InvestigationViewModel Investigation { get; set; }
        public StatusViewModel Status { get; set; }
        public TypeOfHazardViewModel TypeOfHazard { get; set; }
        
        public AuthorViewModel Author { get; set; }
    }
}
