using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class InvestigationViewModel
    {
        public int Id { get; set; }
        public DateTime DateOfAction { get; set; }
        public string Description { get; set; }
        public string InvestigatorDetails { get; set; }

        public ReportViewModel Report { get; set; }

        public AuthorViewModel Author { get; set; }
    }
}
