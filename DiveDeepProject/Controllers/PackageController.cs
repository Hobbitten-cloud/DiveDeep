using Microsoft.AspNetCore.Mvc;

namespace DiveDeepProject.Controllers
{
    public class PackageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
