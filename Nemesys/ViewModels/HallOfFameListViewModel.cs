using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class HallOfFameListViewModel
    {
        [Display(Name = "Position")]
        public int TotalReporters { get; set; }

        public IEnumerable<HallOfFameViewModel> HallOfFame { get; set; }
    }
}
