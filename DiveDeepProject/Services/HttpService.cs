using DiveDeepProject.Models.API;
using DiveDeepProject.Services.Interfaces;
using DiveDeepProject.ViewModels;

namespace DiveDeepProject.Services
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Root?> GetWeatherAsync(string latitude, string longitude)
        {
            var http = _httpClientFactory.CreateClient("WeatherApiClient");
            var url = $"forecast?latitude={latitude}&longitude={longitude}&hourly=temperature_2m,precipitation,wind_speed_10m,weathercode&wind_speed_unit=ms&timezone=auto";

            var resp = await http.GetAsync(url);
            if (!resp.IsSuccessStatusCode) return null;

            return await resp.Content.ReadFromJsonAsync<Root?>();
        }

        public async Task<Root?> GetMarineAsync(string latitude, string longitude)
        {
            var http = _httpClientFactory.CreateClient("MarineApiClient");
            var url = $"marine?latitude={latitude}&longitude={longitude}&hourly=wave_height&timezone=auto";

            var resp = await http.GetAsync(url);
            if (!resp.IsSuccessStatusCode) return null;

            return await resp.Content.ReadFromJsonAsync<Root?>();
        }

        public async Task<(Root? Weather, Root? Marine)> GetCombinedAsync(string latitude, string longitude, string startDate, string endDate)
        {
            var weatherClient = _httpClientFactory.CreateClient("WeatherApiClient");
            var marineClient = _httpClientFactory.CreateClient("MarineApiClient");

            var weatherUrl = $"forecast?latitude={latitude}&longitude={longitude}&hourly=temperature_2m,precipitation,wind_speed_10m,weathercode&wind_speed_unit=ms&timezone=auto&start_date={startDate}&end_date={endDate}";
            var marineUrl = $"marine?latitude={latitude}&longitude={longitude}&hourly=wave_height&timezone=auto&start_date={startDate}&end_date={endDate}";

            var weatherTask = weatherClient.GetFromJsonAsync<Root>(weatherUrl);
            var marineTask = marineClient.GetFromJsonAsync<Root>(marineUrl);

            await Task.WhenAll(weatherTask, marineTask);

            return (weatherTask.Result, marineTask.Result);
        }
    }
}