using DiveDeepProject.Models.API;

namespace DiveDeepProject.ViewModels
{
    public class WeatherViewData
    {
        public List<Root> Roots { get; set; }
        public List<Daily> Dailys { get; set; }
        public List<DailyUnits> DailyUnits { get; set; }
    }
}