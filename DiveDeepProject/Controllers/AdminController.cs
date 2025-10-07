using DiveDeepProject.Models.Domain;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Persistence.Repo;
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
                return View(products);
            }

            return View();
        }

        public IActionResult CreateProduct()
        {

            return View();
        }

        public IActionResult EditProduct(int Id)
        {

            return View();
        }
    }
}
