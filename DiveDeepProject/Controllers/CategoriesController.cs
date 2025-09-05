using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Models;
using DiveDeepProject.Models.Inferfaces;

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
        public IActionResult ProductLink(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            return RedirectToAction("Details", "Product", new { id = id.Value });
        }
    }
}
