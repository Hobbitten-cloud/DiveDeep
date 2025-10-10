using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using DiveDeepProject.Data;

namespace DiveDeepProject.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryRepo _categoryRepo;
        private readonly PackageRepo _packageRepo;
        private readonly DiveDeepContext _context;

        public CategoriesController(CategoryRepo categoryRepo, PackageRepo packageRepo)
        {
            _categoryRepo = categoryRepo;
            _packageRepo = packageRepo;
        }

        public IActionResult Index(int? id, string? searchString)
        {
            var categoryPageViewData = new CategoryPageViewData()
            {
                categories = _categoryRepo.GetAll(),
                SelectedCategoryId = id ?? 1,
                snorkelPackages = _packageRepo.GetAllSnorkelPackages(),
                completePackages = _packageRepo.GetAllCompletePackages(),
                SearchString = searchString ?? string.Empty
            };

            if (!string.IsNullOrWhiteSpace(categoryPageViewData.SearchString))
            {
                var textInSearchString = categoryPageViewData.SearchString.ToLower();

                if (categoryPageViewData.SelectedCategoryId == 1)
                {
                    categoryPageViewData.completePackages = categoryPageViewData.completePackages
                        .Where(pr => !string.IsNullOrEmpty(pr.Name) && pr.Name.ToLower().Contains(textInSearchString.ToLower()))
                        .ToList();
                }

                else if (categoryPageViewData.SelectedCategoryId == 2)
                {
                    categoryPageViewData.snorkelPackages = categoryPageViewData.snorkelPackages
                        .Where(pr => !string.IsNullOrEmpty(pr.Name) && pr.Name.ToLower().Contains(textInSearchString.ToLower()))
                        .ToList();
                }

                else
                {
                    var selectedCategory = categoryPageViewData.categories.FirstOrDefault(c => c.Id == categoryPageViewData.SelectedCategoryId);
                    if (selectedCategory != null)
                    {
                        selectedCategory.products = selectedCategory.products
                            .Where(pr => 
                            !string.IsNullOrEmpty(pr.Brand) && pr.Brand.ToLower().Contains(textInSearchString) ||
                            !string.IsNullOrEmpty(pr.Model) && pr.Model.ToLower().Contains(textInSearchString)
                            
                            ).ToList();
                    }
                }
            }
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
