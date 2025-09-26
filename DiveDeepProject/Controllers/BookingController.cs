using DiveDeepProject.Models.Domain;
using DiveDeepProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepProject.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            
            return View(new List<Receipt>());
        }
    }
}
