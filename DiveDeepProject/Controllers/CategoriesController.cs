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
                var textInSearchString = categoryPageViewData.SearchString;

                //if (categoryPageViewData.SelectedCategoryId == 2)
                //{
                //    categoryPageViewData.snorkelPackages = categoryPageViewData.snorkelPackages
                //        .Where(p => (p.Name != null && p.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
                //                 || (p.Description != null && p.Description.Contains(query, StringComparison.OrdinalIgnoreCase)))
                //        .ToList();
                //}
                //else if (categoryPageViewData.SelectedCategoryId == 1)
                //{
                //    categoryPageViewData.completePackages = categoryPageViewData.completePackages
                //        .Where(p => (p.Name != null && p.Name.Contains(query, StringComparison.OrdinalIgnoreCase))
                //                 || (p.Description != null && p.Description.Contains(query, StringComparison.OrdinalIgnoreCase)))
                //        .ToList();
                //}
                //else
                //{
                var selectedCategory = categoryPageViewData.categories.FirstOrDefault(c => c.Id == categoryPageViewData.SelectedCategoryId);
                if (selectedCategory != null)
                {
                    selectedCategory.products = selectedCategory.products
                        .Where(pr => !string.IsNullOrEmpty(pr.Brand) && pr.Brand.ToLower().Contains(textInSearchString.ToLower()))
                        .ToList();
                    //(pr.Brand != null && pr.Brand.Contains(query, StringComparison.OrdinalIgnoreCase)))
                    //    //|| (pr.Description != null && pr.Description.Contains(query, StringComparison.OrdinalIgnoreCase)))
                    //    .ToList();
                }
                //}
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
