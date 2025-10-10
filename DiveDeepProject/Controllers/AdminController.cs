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
        private readonly IGetRepo<Category> _categoryRepo;

        public AdminController(ProductRepo productRepo, IGetRepo<Package> packageRepo, IGetRepo<Category> categoryRepo)
        {
            _productRepo = productRepo;
            _packageRepo = packageRepo;
            _categoryRepo = categoryRepo;
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
            var categories = _categoryRepo.GetAll();
            ViewBag.Categories = categories;
            return View(new ProductViewData());
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductViewData productViewData)
        {
            ViewBag.Action = "add";

            if (ModelState.IsValid)
            {
                var imagePath = string.IsNullOrWhiteSpace(productViewData.ImagePath)
                    ? "Lib/Public/DesignImageTemplate.png"
                    : productViewData.ImagePath;

                var product = new Product
                {
                    Brand = productViewData.Brand,
                    Model = productViewData.Model,
                    Description = productViewData.Description,
                    PricePerDay = productViewData.PricePerDay,
                    ImagePath = imagePath
                };

                _productRepo.Create(product);
                // Attach type-specific entity so SortingService will include it in category filters
                if (productViewData.SelectedCategoryId.HasValue)
                {
                    switch (productViewData.SelectedCategoryId.Value)
                    {
                        case 3: // BCD
                            if (productViewData.Size.HasValue)
                                _productRepo.CreateBCD(new BCD { ProductId = product.Id, Size = productViewData.Size.Value });
                            break;
                        case 4: // Dykkerdragter
                            _productRepo.CreateDivingSuit(new DivingSuit
                            {
                                ProductId = product.Id,
                                Size = productViewData.Size ?? Models.Enums.Size.M,
                                Type = productViewData.Type ?? string.Empty,
                                Gender = productViewData.Gender ?? Models.Enums.Gender.Male,
                                Thickness = productViewData.Thickness ?? string.Empty
                            });
                            break;
                        case 5: // Tanke
                            _productRepo.CreateTank(new Tank { ProductId = product.Id, Volume = productViewData.Volume ?? string.Empty });
                            break;
                        case 6: // Regulatorsæt
                            _productRepo.CreateRegulatorset(new Regulatorset
                            {
                                ProductId = product.Id,
                                FirstStep = productViewData.FirstStep ?? string.Empty,
                                SecondStep = productViewData.SecondStep ?? string.Empty,
                                Octopus = productViewData.Octopus ?? string.Empty
                            });
                            break;
                        case 7: // Maske/snorkel (SnorkelSet)
                            _productRepo.CreateSnorkelSet(new SnorkelSet { ProductId = product.Id });
                            break;
                        case 8: // Finner
                            if (productViewData.Size.HasValue)
                                _productRepo.CreateFlipper(new Flipper { ProductId = product.Id, Size = productViewData.Size.Value });
                            break;
                        default:
                            break;
                    }
                }
                return RedirectToAction(nameof(ManageProducts));
            }
            var allCategories = _categoryRepo.GetAll();
            ViewBag.Categories = allCategories;
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
