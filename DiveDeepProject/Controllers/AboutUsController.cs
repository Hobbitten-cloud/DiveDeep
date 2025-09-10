using Microsoft.AspNetCore.Mvc;

namespace DiveDeepProject.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
