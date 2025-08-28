using Microsoft.AspNetCore.Mvc;

namespace DiveDeepProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
