using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class HallOfFameViewModel
    {
        [Display(Name = "Email")]
        public AuthorViewModel Authors { get; set; }


        [Display(Name = "Number of reports done since 1 year")]
        public int NumberOfReport { get; set; }
    }
}
