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
            var weatherReport = await _httpService.GetWeatherAsync(latitude, longitude);

            if (weatherReport == null)
            {
                ViewBag.Error = "Could not retrieve weather data.";
                return View();
            }

            return View(weatherReport);
        }
    }
}