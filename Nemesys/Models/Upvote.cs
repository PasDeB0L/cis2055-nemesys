using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class Upvote
    {
        public int Id { get; set; }


        public int ReportId { get; set; }
        //Reference navigation property
        public Report Report { get; set; }

        public string UserId { get; set; }
        //Reference navigation property
        public ApplicationUser User { get; set; }
    }
}

