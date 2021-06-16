using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class EditInvestigationViewModel
    {
        public int Id { get; set; }

        public DateTime DateOfAction { get; set; }

        [Required(ErrorMessage = "Investigation description is required")]
        [StringLength(1500, ErrorMessage = "Investigation  cannot be longer than 1500 characters")]
        public string Description { get; set; }

        public string InvestigatorDetails { get; set; }

        public ReportViewModel Report { get; set; }


        [Display(Name = "Report Post Status")]
        [Required(ErrorMessage = "Status is required")]
        public int StatusId { get; set; }

        public List<StatusViewModel> StatusList { get; set; }

        public AuthorViewModel Author { get; set; }

    }
}
