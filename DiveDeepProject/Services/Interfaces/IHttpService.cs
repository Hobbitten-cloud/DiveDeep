using DiveDeepProject.Models.API;
using DiveDeepProject.ViewModels;

namespace DiveDeepProject.Services.Interfaces
{
    public interface IHttpService
    {
        Task<Root> GetWeatherAsync(string latitude, string longitude);
    }
}
