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

        public ProductController(ProductRepo prodRepo)
        {
            _prodRepo = prodRepo;

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
        public IActionResult AddToBasket(object Item)
        {
            if(Item is IProduct product)
            {
                Basket.Products.Add(product);
			}
            else if(Item is Package package)
            {
                Basket.Packages.Add(package);
			}
			return RedirectToAction(nameof(Index));
		}
    }
}

