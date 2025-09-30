using System.Text.Json.Serialization;
using System.Timers;

namespace DiveDeepProject.Models.API
{
    public class Hourly
    {
        [JsonPropertyName("time")]
        public List<DateTime> time { get; set; }

        [JsonPropertyName("precipitation")]
        public List<double> precipitation { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public List<double> wind_speed_10m { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double> temperature_2m { get; set; }

        [JsonPropertyName("weathercode")]
        public List<int> weathercode { get; set; }

        [JsonPropertyName("wave_height")]
        public List<double?> wave_height { get; set; }

        [JsonPropertyName("wind_wave_height")]
        public List<double?> wind_wave_height { get; set; }
    }
}
