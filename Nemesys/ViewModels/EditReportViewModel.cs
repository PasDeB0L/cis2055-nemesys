using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class EditReportViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A title is required")]
        [StringLength(50)]
        [Display(Name = "Report heading")]
        public string Title { get; set; }


        public DateTime CreatedDate { get; set; }
        public DateTime Date { get; set; }
        

        [Required(ErrorMessage = "Repost post description is required")]
        [StringLength(1500, ErrorMessage = "Report post cannot be longer than 1500 characters")]
        public string Description { get; set; }

        public string ImageUrl { get; set; }
        
        [Display(Name = "Featured Image")]
        public IFormFile ImageToUpload { get; set; } //used only when submitting form


        [Display(Name = "Blog Post Category")]        
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        //Property used solely to populate drop down
        public List<StatusViewModel> StatusList { get; set; }
        //Property used solely to populate drop down
        public List<TypeOfHazardViewModel> TypeOfHazardList { get; set; }


    }
}
