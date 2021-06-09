using Nemesys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class UpVoteViewModel
    {
        public int Id { get; set; }
        
        public Report Report { get; set; }

        
        public ApplicationUser User { get; set; }
    }
}
