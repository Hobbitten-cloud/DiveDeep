using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.ViewModels;

namespace DiveDeepProject.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryRepo _categoryRepo;
        private readonly PackageRepo _packageRepo;
		public CategoriesController(CategoryRepo categoryRepo,PackageRepo packageRepo)
        {
            _categoryRepo = categoryRepo;
			_packageRepo = packageRepo;
		}
        
        public IActionResult Index(int? id) 
        {
            var categoryPageViewData = new CategoryPageViewData();
            categoryPageViewData.categories = _categoryRepo.GetAll();
            categoryPageViewData.SelectedCategoryId = id.HasValue ? id.Value : 1;
            categoryPageViewData.snorkelPackages = _packageRepo.GetAllSnorkelPackages();
			categoryPageViewData.completePackages = _packageRepo.GetAllCompletePackages();

			return View(categoryPageViewData);
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
