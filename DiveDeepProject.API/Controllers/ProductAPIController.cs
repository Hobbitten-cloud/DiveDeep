using Microsoft.AspNetCore.Mvc;

namespace DiveDeepProject.API.Controllers
{
    public class ProductAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
