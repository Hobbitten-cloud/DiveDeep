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

            // Common validation
            if (string.IsNullOrWhiteSpace(productViewData.Brand))
                ModelState.AddModelError(nameof(productViewData.Brand), "Mærke er påkrævet.");
            if (string.IsNullOrWhiteSpace(productViewData.Model))
                ModelState.AddModelError(nameof(productViewData.Model), "Model er påkrævet.");
            if (!productViewData.SelectedCategoryId.HasValue)
                ModelState.AddModelError(nameof(productViewData.SelectedCategoryId), "Kategori er påkrævet.");
            if (productViewData.PricePerDay <= 0)
                ModelState.AddModelError(nameof(productViewData.PricePerDay), "Pris pr. dag skal være større end 0.");

            // Category-specific validation
            if (productViewData.SelectedCategoryId.HasValue)
            {
                var selected = _categoryRepo.GetAll().FirstOrDefault(c => c.Id == productViewData.SelectedCategoryId.Value);
                var name = selected?.Name?.ToLower() ?? string.Empty;

                bool needsSize = name.Contains("bcd") || name.Contains("dragt") || name.Contains("finner");
                if (needsSize && !productViewData.Size.HasValue)
                    ModelState.AddModelError(nameof(productViewData.Size), "Størrelse er påkrævet for den valgte kategori.");

                if (name.Contains("dragt"))
                {
                    if (!productViewData.Gender.HasValue)
                        ModelState.AddModelError(nameof(productViewData.Gender), "Køn er påkrævet for dragter.");
                }

                if (name.Contains("regulator"))
                {
                    if (string.IsNullOrWhiteSpace(productViewData.FirstStep))
                        ModelState.AddModelError(nameof(productViewData.FirstStep), "1. trin er påkrævet.");
                    if (string.IsNullOrWhiteSpace(productViewData.SecondStep))
                        ModelState.AddModelError(nameof(productViewData.SecondStep), "2. trin er påkrævet.");
                    if (string.IsNullOrWhiteSpace(productViewData.Octopus))
                        ModelState.AddModelError(nameof(productViewData.Octopus), "Octopus er påkrævet.");
                }

                if (name.Contains("tank"))
                {
                    if (string.IsNullOrWhiteSpace(productViewData.Volume))
                        ModelState.AddModelError(nameof(productViewData.Volume), "Volumen er påkrævet for tanke.");
                }
            }

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
                    var categories = _categoryRepo.GetAll();
                    var selected = categories.FirstOrDefault(c => c.Id == productViewData.SelectedCategoryId.Value);
                    var name = selected?.Name?.ToLower() ?? string.Empty;

                    if (name.Contains("bcd"))
                    {
                        var sz = productViewData.Size ?? Models.Enums.Size.M;
                        _productRepo.CreateBCD(new BCD { ProductId = product.Id, Size = sz });
                    }
                    else if (name.Contains("dragt"))
                    {
                        _productRepo.CreateDivingSuit(new DivingSuit
                        {
                            ProductId = product.Id,
                            Size = productViewData.Size ?? Models.Enums.Size.M,
                            Type = productViewData.Type ?? string.Empty,
                            Gender = productViewData.Gender ?? Models.Enums.Gender.Male,
                            Thickness = productViewData.Thickness ?? string.Empty
                        });
                    }
                    else if (name.Contains("tank"))
                    {
                        _productRepo.CreateTank(new Tank { ProductId = product.Id, Volume = productViewData.Volume ?? string.Empty });
                    }
                    else if (name.Contains("regulator"))
                    {
                        _productRepo.CreateRegulatorset(new Regulatorset
                        {
                            ProductId = product.Id,
                            FirstStep = productViewData.FirstStep ?? string.Empty,
                            SecondStep = productViewData.SecondStep ?? string.Empty,
                            Octopus = productViewData.Octopus ?? string.Empty
                        });
                    }
                    else if (name.Contains("maske") || name.Contains("snorkel"))
                    {
                        _productRepo.CreateSnorkelSet(new SnorkelSet { ProductId = product.Id });
                    }
                    else if (name.Contains("finner"))
                    {
                        var sz = productViewData.Size ?? Models.Enums.Size.M;
                        _productRepo.CreateFlipper(new Flipper { ProductId = product.Id, Size = sz });
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

            // Common validation
            if (string.IsNullOrWhiteSpace(productViewData.Brand))
                ModelState.AddModelError(nameof(productViewData.Brand), "Mærke er påkrævet.");
            if (string.IsNullOrWhiteSpace(productViewData.Model))
                ModelState.AddModelError(nameof(productViewData.Model), "Model er påkrævet.");
            if (productViewData.PricePerDay <= 0)
                ModelState.AddModelError(nameof(productViewData.PricePerDay), "Pris pr. dag skal være større end 0.");

            if (productViewData.SelectedCategoryId.HasValue)
            {
                var selected = _categoryRepo.GetAll().FirstOrDefault(c => c.Id == productViewData.SelectedCategoryId.Value);
                var name = selected?.Name?.ToLower() ?? string.Empty;

                bool needsSize = name.Contains("bcd") || name.Contains("dragt") || name.Contains("finner");
                if (needsSize && !productViewData.Size.HasValue)
                    ModelState.AddModelError(nameof(productViewData.Size), "Størrelse er påkrævet for den valgte kategori.");

                if (name.contains("dragt"))
                {
                    if (!productViewData.Gender.HasValue)
                        ModelState.AddModelError(nameof(productViewData.Gender), "Køn er påkrævet for dragter.");
                }

                if (name.Contains("regulator"))
                {
                    if (string.IsNullOrWhiteSpace(productViewData.FirstStep))
                        ModelState.AddModelError(nameof(productViewData.FirstStep), "1. trin er påkrævet.");
                    if (string.IsNullOrWhiteSpace(productViewData.SecondStep))
                        ModelState.AddModelError(nameof(productViewData.SecondStep), "2. trin er påkrævet.");
                    if (string.IsNullOrWhiteSpace(productViewData.Octopus))
                        ModelState.AddModelError(nameof(productViewData.Octopus), "Octopus er påkrævet.");
                }

                if (name.Contains("tank"))
                {
                    if (string.IsNullOrWhiteSpace(productViewData.Volume))
                        ModelState.AddModelError(nameof(productViewData.Volume), "Volumen er påkrævet for tanke.");
                }
            }

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