using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;
using DiveDeepProject.Persistence.Repo;

namespace DiveDeepProject.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryRepo _categoryRepo;
        public CategoriesController(CategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            var categories = _categoryRepo.GetAll();
            return View(categories);
        }
    }
}
