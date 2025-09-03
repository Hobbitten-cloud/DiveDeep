using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;
using DiveDeepProject.Persistence.Repo;

namespace DiveDeepProject.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoryRepo.GetAll();
            return View(categories);
        }
    }
}
