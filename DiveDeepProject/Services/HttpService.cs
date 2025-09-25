using DiveDeepProject.Models.API;

namespace DiveDeepProject.Services
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public HttpService(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<Root> GetWeatherAsync(double lat, double lng)
        {
            var httpClient = _httpClientFactory.CreateClient("WeatherApiClient");

            httpClient.DefaultRequestHeaders.Add("Authorization", _config["StormGlass:ApiKey"]);

            var url = await httpClient.GetAsync($"weather?lat={lat}&lng={lng}&params=precipitation,waveHeight,windSpeed");

            if (!url.IsSuccessStatusCode)
            {
                return null;
            }

            return await url.Content.ReadFromJsonAsync<Root?>();
        }
    }
}
