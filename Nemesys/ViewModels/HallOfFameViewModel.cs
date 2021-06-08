using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class HallOfFameViewModel
    {
        public int TotalEntries { get; set; }

        public IEnumerable<AuthorViewModel> Authors { get; set; }

        public IEnumerable<int> NumberOfReport { get; set; }
    }
}
