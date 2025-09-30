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

        //public async Task<Root> GetWeatherAsync(double latitude, double longitude)
        //{
        //    var httpClient = _httpClientFactory.CreateClient("WeatherApiClient");

        //    // Daily
        //    //var response = await httpClient.GetAsync($"forecast?latitude={latitude}&longitude={longitude}&hourly=precipitation_sum,wind_speed_10m_max,temperature_2m_min,temperature_2m_max,weathercode&timezone=auto");

        //    // Hourly
        //    var response = await httpClient.GetAsync($"forecast?latitude={latitude}&longitude={longitude}&hourly=precipitation,wind_speed_10m,temperature_2m,weathercode&timezone=auto");

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        return null;
        //    }

        //    return await response.Content.ReadFromJsonAsync<Root?>();
        //}


        public async Task<Root?> GetWeatherAsync(double latitude, double longitude)
        {
            var http = _httpClientFactory.CreateClient("WeatherApiClient");
            var url = $"forecast?latitude={latitude}&longitude={longitude}&hourly=temperature_2m,precipitation,wind_speed_10m&timezone=auto";

            var resp = await http.GetAsync(url);
            if (!resp.IsSuccessStatusCode) return null;

            return await resp.Content.ReadFromJsonAsync<Root?>();
        }

        public async Task<Root?> GetMarineAsync(double latitude, double longitude)
        {
            var http = _httpClientFactory.CreateClient("MarineApiClient");
            var url = $"marine?latitude={latitude}&longitude={longitude}&hourly=wave_height,wind_wave_height&timezone=auto";

            var resp = await http.GetAsync(url);
            if (!resp.IsSuccessStatusCode) return null;

            return await resp.Content.ReadFromJsonAsync<Root?>();
        }

        public async Task<(Root? Weather, Root? Marine)> GetCombinedAsync(double latitude, double longitude)
        {
            var weatherClient = _httpClientFactory.CreateClient("WeatherApiClient");
            var marineClient = _httpClientFactory.CreateClient("MarineApiClient");

            var weatherUrl = $"forecast?latitude={latitude}&longitude={longitude}&hourly=temperature_2m,precipitation,wind_speed_10m&timezone=auto";
            var marineUrl = $"marine?latitude={latitude}&longitude={longitude}&hourly=wave_height,wind_wave_height&timezone=auto";

            var weatherTask = weatherClient.GetFromJsonAsync<Root>(weatherUrl);
            var marineTask = marineClient.GetFromJsonAsync<Root>(marineUrl);

            await Task.WhenAll(weatherTask, marineTask);

            return (weatherTask.Result, marineTask.Result);
        }
    }
}