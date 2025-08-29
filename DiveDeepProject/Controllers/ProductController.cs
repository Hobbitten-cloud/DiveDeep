using Microsoft.AspNetCore.Mvc;
using DiveDeepProject.Persistence;

namespace DiveDeepProject.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductRepository.GetAll();
            return View(products);
        }
    }
}
