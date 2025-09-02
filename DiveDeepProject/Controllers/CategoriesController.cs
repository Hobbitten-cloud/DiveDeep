using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;

namespace DiveDeepProject.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetAll();
            return View(categories);
        }
    }
}
