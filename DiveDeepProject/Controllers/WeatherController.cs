using DiveDeepProject.Services.Interfaces;
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
        public async Task<IActionResult> Index(double latitude, double longitude)
        {
            var (weather, marine) = await _httpService.GetCombinedAsync(latitude, longitude);

            if (weather is null && marine is null)
            {
                ViewBag.Error = "Could not retrieve weather or marine data.";
                return View();
            }

            return View((weather, marine));
        }
    }
}