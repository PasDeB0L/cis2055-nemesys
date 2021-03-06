using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

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



        //Foreign Key - Status 
        public int StatusId { get; set; }
        //Reference navigation status
        public Status Status { get; set; }
        public int TypeOfHazardId { get; set; }
        //Reference navigation type
        public TypeOfHazard TypeOfHazard { get; set; }


        //Foreign Key - User
        public string UserId { get; set; }
        //Reference navigation user
        public ApplicationUser User { get; set; }
    }
}
