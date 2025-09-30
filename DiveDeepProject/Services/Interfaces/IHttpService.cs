using DiveDeepProject.Models.API;
using DiveDeepProject.ViewModels;

namespace DiveDeepProject.Services.Interfaces
{
    public interface IHttpService
    {
        Task<Root?> GetWeatherAsync(double latitude, double longitude);
        Task<Root?> GetMarineAsync(double latitude, double longitude);
        Task<(Root? Weather, Root? Marine)> GetCombinedAsync(double latitude, double longitude);
    }
}
