using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace DiveDeepProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IGetRepo<Product> _prodRepo;
        private readonly IGetRepo<Package> _packageRepo;
        private readonly ProductRepo _productRepo;

        public AdminController(IGetRepo<Product> prodRepo, IGetRepo<Package> packageRepo)
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

        public IActionResult SearchProduct(int? id, string? searchString)
        {
            var allProducts = _prodRepo.GetAll();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var textInSearchString = searchString.ToLower();
                allProducts = allProducts
                    .Where(pr => (!string.IsNullOrEmpty(pr.Brand) && pr.Brand.ToLower().Contains(textInSearchString)) ||
                                 (!string.IsNullOrEmpty(pr.Model) && pr.Model.ToLower().Contains(textInSearchString)) ||
                                 (!string.IsNullOrEmpty(pr.Description) && pr.Description.ToLower().Contains(textInSearchString)))
                    .ToList();
            }
            var vm = new ProductViewData
            {
                Products = allProducts,
                SearchString = searchString ?? string.Empty
            };
            return View("ManageProducts", vm);
        }

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
                //_prodRepo.Create(product);
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
