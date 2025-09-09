using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;
using DiveDeepProject.Models;
using DiveDeepProject.Persistence.Repo;

namespace DiveDeepProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly CategoryRepo _categoryRepo;
        private readonly PackageRepo _packageRepo;

		public HomeController(CategoryRepo categoryRepo,PackageRepo packageRepo)
        {
            _categoryRepo = categoryRepo;
			_packageRepo = packageRepo;
		}
        public IActionResult Index()
        {
            var categories = _categoryRepo.GetAll();
            return View(categories);
        }

        public IActionResult CategoryLink(int? id)
        {
            var category = new Category { Id = id.HasValue ? id.Value : 0 };
            return View(category);
        }
    }
}