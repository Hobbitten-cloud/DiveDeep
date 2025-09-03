using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;
using DiveDeepProject.Persistence.IRepo;
using DiveDeepProject.Persistence.Repo;
using DiveDeepProject.Models.Inferfaces;

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
           
        
    }
}

