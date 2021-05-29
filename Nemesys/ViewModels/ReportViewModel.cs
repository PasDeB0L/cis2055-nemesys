using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nemesys.Models;

namespace Nemesys.ViewModels
{
    public class ReportViewModel
    {
        public int Id { get; set; }
        public int Upvotes { get; set; }

        public string TypeOfHazard { get; set; }
        public string DetailsOnTheReporter { get; set; }
        public string Status { get; set; }
        public string ImageUrl { get; set; }


        [StringLength(60, MinimumLength = 10)]
        [Required]
        public string Description { get; set; }

        [StringLength(60, MinimumLength = 4)]
        [Required]
        public string Location { get; set; }


        public DateTime DateOfReport { get; set; }
        public DateTime DateAndTime { get; set; }


        public Boolean Investigation { get; set; }

        public ApplicationUser User { get; set; }

    }
}
