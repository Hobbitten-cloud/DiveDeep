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
        private readonly ProductRepo _productRepo;
        private readonly IGetRepo<Package> _packageRepo;

        public AdminController(ProductRepo productRepo, IGetRepo<Package> packageRepo)
        {
            _productRepo = productRepo;
            _packageRepo = packageRepo;
        }

        public IActionResult ManageProducts()
        {
            var products = _productRepo.GetAll();

            var vm = new ProductViewData
            {
                Products = products
            };

            return View(vm);
        }

        public IActionResult SearchProduct(int? id, string? searchString)
        {
            var allProducts = _productRepo.GetAll();

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

        [HttpGet]
        public IActionResult CreateProduct()
        {
            ViewBag.Action = "add";
            return View(new ProductViewData());
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductViewData productViewData)
        {
            ViewBag.Action = "add";

            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Brand = productViewData.Brand,
                    Model = productViewData.Model,
                    Description = productViewData.Description,
                    PricePerDay = productViewData.PricePerDay,
                    ImagePath = productViewData.ImagePath
                };

                _productRepo.Create(product);
                return RedirectToAction(nameof(ManageProducts));
            }
            return View(productViewData);
        }

        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            ViewBag.Action = "edit";
            var product = _productRepo.Get(id);
            
            if (product == null)
            {
                return NotFound();
            }

            var productViewData = new ProductViewData
            {
                Id = product.Id,
                Brand = product.Brand,
                Model = product.Model,
                Description = product.Description,
                PricePerDay = product.PricePerDay,
                ImagePath = product.ImagePath,
                SelectedProductId = product.Id
            };

            return View(productViewData);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductViewData productViewData)
        {
            ViewBag.Action = "edit";

            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = productViewData.Id,
                    Brand = productViewData.Brand,
                    Model = productViewData.Model,
                    Description = productViewData.Description,
                    PricePerDay = productViewData.PricePerDay,
                    ImagePath = productViewData.ImagePath
                };

                _productRepo.Edit(product.Id, product);
                return RedirectToAction(nameof(ManageProducts));
            }
            return View(productViewData);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productRepo.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            _productRepo.Delete(product);
            return RedirectToAction(nameof(ManageProducts));
        }
    }
}
