﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nemesys.Controllers
{
    public class ReportPostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        

        public IActionResult Edit()
        {
            return View();
        }

        
        public IActionResult Create()
        {
            return View();           
        }
    }
}
