using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.ViewModels
{
    public class StatusViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
