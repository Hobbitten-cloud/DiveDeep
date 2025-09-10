using Microsoft.AspNetCore.Mvc;

namespace DiveDeepProject.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
