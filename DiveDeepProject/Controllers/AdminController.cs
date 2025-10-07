using Microsoft.AspNetCore.Mvc;

namespace DiveDeepProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult ManageProducts()
        {
            return View();
        }
    }
}
