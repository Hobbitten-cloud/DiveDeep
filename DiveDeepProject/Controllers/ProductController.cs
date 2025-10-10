using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Persistence.Repo;
using Microsoft.AspNetCore.Mvc.Rendering;
using DiveDeepProject.Models.Enums;
using DiveDeepProject.Models;
using DiveDeepProject.Models.Domain;
using DiveDeepProject.ViewModels;


namespace DiveDeepProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepo<Product> _prodRepo;
        private readonly IRepo<Package> _packageRepo;
        public ProductController(ProductRepo prodRepo, PackageRepo packageRepo)
        {
            _prodRepo = prodRepo;
            _packageRepo = packageRepo;
        }

        public IActionResult Index()
        {
            if (_prodRepo is ProductRepo repo)
            {
                var products = repo.GetAll();
                return View(products);
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            if (_prodRepo is ProductRepo repo)
            {
                var product = repo.Get(id);
                if (product == null)
                {
                    return NotFound();
                }

                var viewModel = new ProductViewData
                {
                    Id = product.Id,
                    Brand = product.Brand,
                    PricePerDay = product.PricePerDay,
                    Description = product.Description,
                    ImagePath = product.ImagePath,
                    UnavailableDates = product.UnavailableDates
                };

                string template = "Default";

                if (product.BCDs != null && product.BCDs.Any())
                {
                    var bcd = product.BCDs.First();
                    viewModel.Model = product.Model;
                    viewModel.Size = bcd.Size;
                    template = "BCD";
                }
                else if (product.DivingSuits != null && product.DivingSuits.Any())
                {
                    var suit = product.DivingSuits.First();
                    viewModel.Model = product.Model;
                    viewModel.Size = suit.Size;
                    viewModel.Type = suit.Type;
                    viewModel.Gender = suit.Gender;
                    viewModel.Thickness = suit.Thickness;
                    template = "DivingSuit";
                }
                else if (product.Flippers != null && product.Flippers.Any())
                {
                    var fin = product.Flippers.First();
                    viewModel.Model = product.Model;
                    viewModel.Size = fin.Size;
                    template = "Flipper";
                }
                else if (product.Regulatorsets != null && product.Regulatorsets.Any())
                {
                    var reg = product.Regulatorsets.First();
                    viewModel.FirstStep = reg.FirstStep;
                    viewModel.SecondStep = reg.SecondStep;
                    viewModel.Octopus = reg.Octopus;
                    template = "Regulatorset";
                }
                else if (product.SnorkelSets != null && product.SnorkelSets.Any())
                {
                    var mask = product.SnorkelSets.First();
                    viewModel.Model = product.Model;
                    template = "SnorkelSet";
                }
                else if (product.Tanks != null && product.Tanks.Any())
                {
                    var tank = product.Tanks.First();
                    viewModel.Volume = tank.Volume;
                    template = "Tank";
                }

                // Defining sizes
                var allowedSizes = new[] { Size.S, Size.M, Size.L };
                var filteredList = allowedSizes.Select(s => new SelectListItem
                {
                    Text = s.ToString(), // or get display attribute if you have one
                    Value = ((int)s).ToString()
                }).ToList();
                
                ViewData["SizeOptions"] = filteredList;
                ViewData["Template"] = template;

                return View(viewModel);
            }

            return NotFound();
        }

        //public IActionResult AddToBasket(int ItemID, string nameID)
        //{
        //    if (_packageRepo is PackageRepo packrepo)
        //    {
        //        if (_prodRepo is ProductRepo prodrepo)
        //        {
        //            if (prodrepo.Get(ItemID) != null && nameID == "Prod")
        //            {
        //                Basket.Products.Add(prodrepo.Get(ItemID));
        //            }
        //            else if (packrepo.Get(ItemID) != null && nameID == "Cat")
        //            {
        //                Basket.Packages.Add(packrepo.Get(ItemID));
        //            }
        //            Console.WriteLine(Basket.Products.Count);
        //        }
        //    }
        //    return RedirectToAction(nameof(Details), new { id = ItemID });
        //}

        [HttpPost]
		public IActionResult AddToBasket(int ItemID, string nameID, ProductViewData productViewData)
		{
			// Custom validation based on product type
			if (_prodRepo is ProductRepo repo)
			{
				var product = repo.Get(ItemID);
				if (product != null)
				{
					// Validate Size for products that require it
					if ((product.BCDs != null && product.BCDs.Any()) || 
						(product.DivingSuits != null && product.DivingSuits.Any()) || 
						(product.Flippers != null && product.Flippers.Any()))
					{
						if (productViewData.Size == null)
						{
							ModelState.AddModelError("Size", "Størrelse er påkrævet for dette produkt.");
						}
					}

					// Validate Gender for DivingSuits
					if (product.DivingSuits != null && product.DivingSuits.Any())
					{
						if (productViewData.Gender == null)
						{
							ModelState.AddModelError("Gender", "Køn er påkrævet for dykkerdragter.");
						}
					}
				}
			}

			if (!ModelState.IsValid)
			{
				// Rebuild the Details view data and return the same view with validation messages
				if (_prodRepo is ProductRepo productRepo)
				{
					var product = productRepo.Get(ItemID);
					if (product == null)
					{
						return NotFound();
					}

					var viewModel = new ProductViewData
					{
						Id = product.Id,
						Brand = product.Brand,
						PricePerDay = product.PricePerDay,
						Description = product.Description,
						ImagePath = product.ImagePath,
						UnavailableDates = product.UnavailableDates,
						// Preserve user selections so validation messages show next to their inputs
						Size = productViewData.Size,
						Gender = productViewData.Gender
					};

					string template = "Default";
					if (product.BCDs != null && product.BCDs.Any())
					{
                    var bcd = product.BCDs.First();
                    viewModel.Model = product.Model;
						viewModel.Size = viewModel.Size ?? bcd.Size;
						template = "BCD";
					}
					else if (product.DivingSuits != null && product.DivingSuits.Any())
					{
                    var suit = product.DivingSuits.First();
                    viewModel.Model = product.Model;
						viewModel.Type = suit.Type;
						viewModel.Thickness = suit.Thickness;
						template = "DivingSuit";
					}
					else if (product.Flippers != null && product.Flippers.Any())
					{
                    var fin = product.Flippers.First();
                    viewModel.Model = product.Model;
						template = "Flipper";
					}
					else if (product.Regulatorsets != null && product.Regulatorsets.Any())
					{
						var reg = product.Regulatorsets.First();
						viewModel.FirstStep = reg.FirstStep;
						viewModel.SecondStep = reg.SecondStep;
						viewModel.Octopus = reg.Octopus;
						template = "Regulatorset";
					}
					else if (product.SnorkelSets != null && product.SnorkelSets.Any())
					{
                    var mask = product.SnorkelSets.First();
                    viewModel.Model = product.Model;
						template = "SnorkelSet";
					}
					else if (product.Tanks != null && product.Tanks.Any())
					{
						var tank = product.Tanks.First();
						viewModel.Volume = tank.Volume;
						template = "Tank";
					}

					// Sizes for dropdowns if needed elsewhere
					var allowedSizes = new[] { Size.S, Size.M, Size.L };
					var filteredList = allowedSizes.Select(s => new SelectListItem
					{
						Text = s.ToString(),
						Value = ((int)s).ToString()
					}).ToList();
					ViewData["SizeOptions"] = filteredList;
					ViewData["Template"] = template;

					return View("Details", viewModel);
				}

				return BadRequest();
			}

			// Model valid: add to basket and return to Details page
			if (_packageRepo is PackageRepo packrepo && _prodRepo is ProductRepo prodrepo)
			{
				if (nameID == "Prod")
				{
					var product = prodrepo.Get(ItemID);
					if (product != null)
					{
						Basket.Products.Add(product);
						TempData["Message"] = "Produkt tilføjet til kurven.";
					}
				}
				else if (nameID == "Cat")
				{
					var package = packrepo.Get(ItemID);
					if (package != null)
					{
						Basket.Packages.Add(package);
						TempData["Message"] = "Pakke tilføjet til kurven.";
					}
				}
			}

			return RedirectToAction(nameof(Details), new { id = ItemID });
		}
	}
}