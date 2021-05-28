using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Models
{
    public class Status : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
