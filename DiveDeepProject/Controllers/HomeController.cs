using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;
using DiveDeepProject.Models;

namespace DiveDeepProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetAll();
            return View(categories);
        }

        public IActionResult CategoryLink(int? id)
        {
            var category = new Category { Id = id.HasValue ? id.Value : 0 };
            return View(category);
        }
    }
}