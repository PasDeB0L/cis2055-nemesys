using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class EditReportViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A title is required")]
        [StringLength(50, ErrorMessage = "Report heading cannot be longer than 50 characters")]
        [Display(Name = "Report heading")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Title { get; set; }

        [Display(Name = "Create Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of the hazard")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        


        [Required(ErrorMessage = "Report post description is required")]
        [StringLength(1500, ErrorMessage = "Description cannot be longer than 1500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Report post location is required")]
        [StringLength(60, ErrorMessage = "Location cannot be longer than 60 characters")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        public string Location { get; set; }

        public string ImageUrl { get; set; }
        
        [Display(Name = "Featured Image")]
        public IFormFile ImageToUpload { get; set; } //used only when submitting form


        [Display(Name = "Report Status")]        
        [Required(ErrorMessage = "Status is required")]
        public int StatusId { get; set; }

        [Display(Name = "Type of hazard")]
        [Required(ErrorMessage = "Type of hazard is required")]
        public int TypeOfHazardId { get; set; }

        //Property used solely to populate drop down
        public List<StatusViewModel> StatusList { get; set; }
        //Property used solely to populate drop down
        public List<TypeOfHazardViewModel> TypeOfHazardList { get; set; }

        public AuthorViewModel Author { get; set; }
    }
}
