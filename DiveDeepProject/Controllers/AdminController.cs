using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepo<Product> _prodRepo;
        private readonly IRepo<Package> _packageRepo;

        public AdminController(ProductRepo prodRepo, PackageRepo packageRepo)
        {
            _prodRepo = prodRepo;
            _packageRepo = packageRepo;
        }

        public IActionResult ManageProducts()
        {
            if (_prodRepo is ProductRepo repo)
            {
                var products = repo.GetAll();

                var vm = new ProductViewData
                {
                    Products = products
                };

                return View(vm);
            }

            return View();
        }

        //public IActionResult SearchProduct()
        //{
        //    var productViewData = new ProductViewData()
        //    {
        //        products = _prodRepo.GetAll(),
        //        SelectedCategoryId = id ?? 1,
        //        snorkelPackages = _packageRepo.GetAllSnorkelPackages(),
        //        completePackages = _packageRepo.GetAllCompletePackages(),
        //        SearchString = searchString ?? string.Empty
        //    };

        //    if (!string.IsNullOrWhiteSpace(ProductViewData.SearchString))
        //    {
        //        var textInSearchString = categoryPageViewData.SearchString.ToLower();

        //        if (categoryPageViewData.SelectedCategoryId == 1)
        //        {
        //            categoryPageViewData.completePackages = categoryPageViewData.completePackages
        //                .Where(pr => !string.IsNullOrEmpty(pr.Name) && pr.Name.ToLower().Contains(textInSearchString.ToLower()))
        //                .ToList();
        //        }
        //        else if (categoryPageViewData.SelectedCategoryId == 2)
        //        {
        //            categoryPageViewData.snorkelPackages = categoryPageViewData.snorkelPackages
        //                .Where(pr => !string.IsNullOrEmpty(pr.Name) && pr.Name.ToLower().Contains(textInSearchString.ToLower()))
        //                .ToList();
        //        }
        //        else
        //        {
        //            var selectedCategory = categoryPageViewData.categories.FirstOrDefault(c => c.Id == categoryPageViewData.SelectedCategoryId);
        //            if (selectedCategory != null)
        //            {
        //                selectedCategory.products = selectedCategory.products
        //                    .Where(pr =>
        //                    !string.IsNullOrEmpty(pr.Brand) && pr.Brand.ToLower().Contains(textInSearchString) ||
        //                    !string.IsNullOrEmpty(pr.Model) && pr.Model.ToLower().Contains(textInSearchString)

        //                    ).ToList();
        //            }
        //        }
        //    }

        //    return (productViewData);
        //}

        public IActionResult CreateProduct()
        {
            ViewBag.action = "add";

            //if (ModelState.IsValid == true)
            //{
            //    ProductRepo.Add(movie);
            //    return RedirectToAction(nameof(Index));
            //}
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            ViewBag.action = "add";

            if (ModelState.IsValid)
            {
                _prodRepo.Create(product);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            ViewBag.action = "edit";

            //if (ModelState.IsValid == true)
            //{
            //    ProductRepo.Update(movie.MovieId, movie);
            //    return RedirectToAction(nameof(Index));
            //}
            return View();
        }
    }
}
