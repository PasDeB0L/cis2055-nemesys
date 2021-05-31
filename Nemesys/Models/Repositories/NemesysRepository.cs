using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models.Repositories
{
    public class NemesysRepository
    {
        private List<Report> _reports;
        private List<Investigation> _investigations;
        private List<Status> _status;
        private List<TypeOfHasard> _typeOfHasard;

        public NemesysRepository()
        {
            if (_reports == null)
            {
                InitializeReport();
            }

            if (_investigations == null)
            {
                InitializeInvestigation();
            }

            if (_status == null)
            {
                InitializeStatus();
            }

            if (_typeOfHasard == null)
            {
                InitializeTypeOfHasard();
            }
        }

        public void InitializeReport()
        {

        }

        public void InitializeInvestigation()
        {

        }

        public void InitializeStatus()
        {

        }
        public void InitializeTypeOfHasard()
        {

        }


    }

}
