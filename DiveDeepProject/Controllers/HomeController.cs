using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;

namespace DiveDeepProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetAll();
            return View(categories);
        }
    }
}
