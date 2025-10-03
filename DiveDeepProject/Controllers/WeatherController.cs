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
        public async Task<IActionResult> Index(string latitude, string longitude, string startDate, string endDate)
        {
            if (string.IsNullOrEmpty(latitude) || (string.IsNullOrEmpty(longitude)))
            {
                ViewBag.Error = "Begge felter skal udfyldes!";
                return View();
            }

            ViewBag.Latitude = latitude;
            ViewBag.Longitude = longitude;

            // NumberStyles.Any = Postive and negative numbers
            // CultureInfo = We are using . instead of , 
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

            var lat = parsedLatitude.ToString(System.Globalization.CultureInfo.InvariantCulture);
            var lon = parsedLongitude.ToString(System.Globalization.CultureInfo.InvariantCulture);

            var (weather, marine) = await _httpService.GetCombinedAsync(lat, lon, startDate, endDate);

            if (weather is null && marine is null)
            {
                ViewBag.Error = "Could not retrieve weather or marine data.";
                return View();
            }

            // If view expects Root, prefer weather, else marine; and merge marine wave data in if available
            var model = weather ?? marine;
            if (model != null && marine?.hourly != null)
            {
                model.hourly.wave_height = marine.hourly.wave_height;
            }

            return View(model);
        }
    }
}