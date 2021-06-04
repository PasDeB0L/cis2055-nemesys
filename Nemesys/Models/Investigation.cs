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
        

        
        public int ReportId { get; set; }
        //Reference navigation property
        public Report Report { get; set; }

        public int StatusId { get; set; }
        //Reference navigation property
        public Status Status { get; set; }


        //Foreign Key - navigation property name + key property name
        public string UserId { get; set; }
        //Reference navigation property
        public ApplicationUser User { get; set; }
    }
}
