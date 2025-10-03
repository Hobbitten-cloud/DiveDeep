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
                    viewModel.Model = bcd.Model;
                    viewModel.Size = bcd.Size;
                    template = "BCD";
                }
                else if (product.DivingSuits != null && product.DivingSuits.Any())
                {
                    var suit = product.DivingSuits.First();
                    viewModel.Model = suit.Model;
                    viewModel.Size = suit.Size;
                    viewModel.Type = suit.Type;
                    viewModel.Gender = suit.Gender;
                    viewModel.Thickness = suit.Thickness;
                    template = "DivingSuit";
                }
                else if (product.Flippers != null && product.Flippers.Any())
                {
                    var fin = product.Flippers.First();
                    viewModel.Model = fin.Model;
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
                    viewModel.Model = mask.Model;
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
        public IActionResult AddToBasket(int ItemID, string nameID)
        {
            //if (ModelState.IsValid)
            //{
                if (_packageRepo is PackageRepo packrepo)
                {
                    if (_prodRepo is ProductRepo prodrepo)
                    {
                        if (prodrepo.Get(ItemID) != null && nameID == "Prod")
                        {
                            Basket.Products.Add(prodrepo.Get(ItemID));
                        }
                        else if (packrepo.Get(ItemID) != null && nameID == "Cat")
                        {
                            Basket.Packages.Add(packrepo.Get(ItemID));
                        }
                        Console.WriteLine(Basket.Products.Count);
                    }
                //}
            }
            return RedirectToAction(nameof(Details), new { id = ItemID });
        }

		[HttpPost]
		public IActionResult AddToBasket(ProductViewData productViewData)
		{
            if (!ModelState.IsValid)
            {
				var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
				return BadRequest(new { Message = "Validation failed", Errors = errors });
			}

            return View(Index);
		}
	}
}