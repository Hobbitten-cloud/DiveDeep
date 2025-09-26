using DiveDeepProject.Models.API;
using DiveDeepProject.Services.Interfaces;

namespace DiveDeepProject.Services
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Root> GetWeatherAsync(double lat, double lng)
        {
            var httpClient = _httpClientFactory.CreateClient("WeatherApiClient");

            //var url = await httpClient.GetAsync($"weather/point?lat={lat}&lng={lng}&params=precipitation,waveHeight,windSpeed");
            var response = await httpClient.GetAsync($"forecast?lat={lat}&lng={lng}&daily=precipitation_sum,wind_speed_10m_max,temperature_2m_min,temperature_2m_max&timezone=auto");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<Root?>();
        }
    }
}