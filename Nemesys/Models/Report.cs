using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nemesys.Models
{
    public class Report
    {
        public int Id { get; set; }
        public int Upvotes { get; set; }

        public int TypeOfHasardId { get; set; }

        public TypeOfHasard TypeOfHasard { get; set; }
        public string DetailsOnTheReporter { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public string ImageUrl { get; set; }


        [StringLength(60, MinimumLength = 10)]
        [Required]
        public string Description { get; set; }

        [StringLength(60, MinimumLength = 4)]
        [Required]
        public string Location { get; set; }


        public DateTime DateOfReport { get; set; }
        public DateTime DateAndTime { get; set; }


        public Boolean Investigation {get; set;}


        //Foreign Key - navigation property name + key property name
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
