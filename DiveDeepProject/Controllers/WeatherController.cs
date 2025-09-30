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
        public async Task<IActionResult> Index(string latitude, string longitude)
        {
            if (!double.TryParse(latitude.Replace(",", "."),
                                 System.Globalization.NumberStyles.Any,
                                 System.Globalization.CultureInfo.InvariantCulture,
                                 out var parsedLatitude) ||
                !double.TryParse(longitude.Replace(",", "."),
                                 System.Globalization.NumberStyles.Any,
                                 System.Globalization.CultureInfo.InvariantCulture,
                                 out var parsedLongitude))
            {
                ViewBag.Error = "Ugyldigt input for koordinater (brug fx 55.67).";
                return View();
            }

            // Convert parsedLatitude and parsedLongitude to strings before passing to GetWeatherAsync
            var weatherReport = await _httpService.GetWeatherAsync(
                parsedLatitude.ToString(System.Globalization.CultureInfo.InvariantCulture),
                parsedLongitude.ToString(System.Globalization.CultureInfo.InvariantCulture));

            if (weatherReport == null)
            {
                ViewBag.Error = "Could not retrieve weather data.";
                return View();
            }

            return View(weatherReport);
        }
    }
}