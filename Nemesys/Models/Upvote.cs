using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class Upvote
    {
        public int Id { get; set; }

        //Foreign Key - Report 
        public int ReportId { get; set; }
        //Reference navigation Report
        public Report Report { get; set; }

        //Foreign Key - User 
        public string UserId { get; set; }
        //Reference navigation User
        public ApplicationUser User { get; set; }
    }
}

