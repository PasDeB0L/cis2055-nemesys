using Nemesys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class InvestigationViewModel
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string DescriptionOfInvestigation { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateOfAction { get; set; }

    }
}
