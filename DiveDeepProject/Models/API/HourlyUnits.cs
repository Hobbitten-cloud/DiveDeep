using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class HourlyUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("precipitation")]
        public string Precipitation { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public string Wind_speed_10m { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string Temperature_2m { get; set; }

        [JsonPropertyName("weathercode")]
        public string Weathercode { get; set; }

        [JsonPropertyName("wave_height")]
        public string Wave_height { get; set; }
    }
}
