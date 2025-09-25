using DiveDeepProject.Models.API;

namespace DiveDeepProject.Services
{
    public interface IHttpService
    {
        Task <Root> GetWeatherAsync(double lat, double lng);
    }
}
