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

        public async Task<Root> GetWeatherAsync(double latitude, double longitude)
        {
            var httpClient = _httpClientFactory.CreateClient("WeatherApiClient");

            // Daily
            //var response = await httpClient.GetAsync($"forecast?latitude={latitude}&longitude={longitude}&hourly=precipitation_sum,wind_speed_10m_max,temperature_2m_min,temperature_2m_max,weathercode&timezone=auto");
            
            // Hourly
            var response = await httpClient.GetAsync($"forecast?latitude={latitude}&longitude={longitude}&hourly=precipitation,wind_speed_10m,temperature_2m,weathercode&timezone=auto");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<Root?>();
        }
    }
}