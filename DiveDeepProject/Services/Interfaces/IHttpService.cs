using DiveDeepProject.Models.API;

namespace DiveDeepProject.Services.Interfaces
{
    public interface IHttpService
    {
        //Task <Root> GetWeatherAsync(double lat, double lng);
        Task<Root> GetRootAsync(double lat, double lng);
    }
}
