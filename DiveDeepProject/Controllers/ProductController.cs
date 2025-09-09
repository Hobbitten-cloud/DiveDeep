using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Models.Inferfaces;
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

