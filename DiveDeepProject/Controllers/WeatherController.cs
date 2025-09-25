using DiveDeepProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepProject.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IHttpService _httpService;

        public WeatherController(IHttpService httpService)
        {
            _httpService = httpService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {

        }
    }
}
