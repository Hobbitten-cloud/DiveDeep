using System.Text.Json.Serialization;
using System.Timers;

namespace DiveDeepProject.Models.API
{
    public class Hourly
    {
        [JsonPropertyName("time")]
        public List<DateTime> Time { get; set; }

        [JsonPropertyName("precipitation")]
        public List<double> Precipitation { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public List<double> Wind_Speed_10m { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double> Temperature_2m { get; set; }

        [JsonPropertyName("weathercode")]
        public List<int> Weathercode { get; set; }

        [JsonPropertyName("wave_height")]
        public List<double?> Wave_Height { get; set; }
    }
}
