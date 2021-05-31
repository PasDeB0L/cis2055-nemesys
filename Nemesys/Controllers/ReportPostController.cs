using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            try
            {
                //Load all categories and create a list of CategoryViewModel
                var categoryList = _bloggyRepository.GetAllCategories().Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

                //Pass the list into an EditBlogPostViewModel, which is used by the View (all other properties may be left blank, unless you want to add other default values
                var model = new EditBlogPostViewModel()
                {
                    CategoryList = categoryList
                };

                //Pass model to View
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, ex.Data);
                return View("Error");
            }
        }
    }
}
