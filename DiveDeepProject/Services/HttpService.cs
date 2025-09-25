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

            //httpClient.DefaultRequestHeaders.Add("Authorization", _config["35b5baa0-99dd-11f0-b0b8-0242ac130006-35b5bb0e-99dd-11f0-b0b8-0242ac130006"]);

            var apiKey = _config["StormGlass:ApiKey"];
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("StormGlass:ApiKey is missing from configuration.");
            }

            //httpClient.DefaultRequestHeaders.Remove("Authorization");
            httpClient.DefaultRequestHeaders.Add("Authorization", apiKey);

            var url = await httpClient.GetAsync($"weather?lat={lat}&lng={lng}&params=precipitation,waveHeight,windSpeed");

            if (!url.IsSuccessStatusCode)
            {
                return null;
            }

            return await url.Content.ReadFromJsonAsync<Root?>();
        }
    }
}
