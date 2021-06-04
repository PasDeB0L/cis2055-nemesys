using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class Report
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

        public Boolean Investation { get; set; }


        //Foreign Key - navigation property name + key property name
        public int StatusId { get; set; }
        //Reference navigation property
        public Status Status { get; set; }
        public int TypeOfHazardId { get; set; }
        //Reference navigation property
        public TypeOfHazard TypeOfHazard { get; set; }


        //Foreign Key - navigation property name + key property name
        public string UserId { get; set; }
        //Reference navigation property
        public ApplicationUser User { get; set; }
    }
}
