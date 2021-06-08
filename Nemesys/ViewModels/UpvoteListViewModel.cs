using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class UpvoteListViewModel
    {
        public int TotalUpvotes { get; set; }
        public IEnumerable<UpVoteViewModel> Upvotes { get; set; }

        public Task<IEnumerable<UpVoteViewModel>> UserId { get; set; }
    }
}
