using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Models.Inferfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using DiveDeepProject.Models.Enums;
using DiveDeepProject.Models;


namespace DiveDeepProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepo<IProduct> _prodRepo;
        private readonly IRepo<Package> _packageRepo;
        public ProductController(ProductRepo prodRepo, PackageRepo packageRepo)
        {
            _prodRepo = prodRepo;
            _packageRepo =packageRepo;

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
				// Prepare filtered enum list (only S, M, L)
				var allowedSizes = new[] { Size.S, Size.M, Size.L };
				var filteredList = allowedSizes.Select(s => new SelectListItem
				{
					Text = s.ToString(),          // or get display attribute if you have one
					Value = ((int)s).ToString()
				}).ToList();

				ViewData["SizeOptions"] = filteredList;

				return View(product);
            }
            return NotFound();
        }
        
        public IActionResult AddToBasket(int ItemID, string nameID)
        {
            if (_packageRepo is PackageRepo packrepo) {
                if (_prodRepo is ProductRepo prodrepo)
                {
                    if (prodrepo.Get(ItemID) != null && nameID =="Prod")
                    {
                        Basket.Products.Add(prodrepo.Get(ItemID));
                    }
                    else if (packrepo.Get(ItemID) != null && nameID == "Cat")
                    {
                        Basket.Packages.Add(packrepo.Get(ItemID));
					}
                    Console.WriteLine(Basket.Products.Count);

				}
            }

            return RedirectToAction(nameof(Details), new { id = ItemID });

		}
    }
}

