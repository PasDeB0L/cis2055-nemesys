using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Nemesys.Models
{
    public class Investigation
    {
        public int Id { get; set; }
        public DateTime DateOfAction { get; set; }
        public string Description { get; set; }
        public string InvestigatorDetails { get; set; }
        public int StatusId { get; set; }
        public int ReportId { get; set; } //Foreign Key - Report 
        public string UserId { get; set; } //Foreign Key - user



        public Report Report { get; set; } //Reference navigation Report
        public ApplicationUser User { get; set; }  //Reference navigation User
    }
}
