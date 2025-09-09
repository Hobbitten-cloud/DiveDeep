using DiveDeepProject.Persistence.Repo;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepProject.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult Index()
        {
            var faqs = FAQRepository.GetAll();
            return View(faqs);
        }
    }
}
