using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class Investigation
    {
        public int Id { get; set; }
        public int  ReportId { get; set; }
        public string DescriptionOfInvestigation { get; set; }
        public string InvestigatorDetails { get; set; }
        public DateTime DateOfAction { get; set; }
    }
}
