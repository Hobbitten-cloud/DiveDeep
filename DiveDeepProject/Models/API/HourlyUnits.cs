using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class HourlyUnits
    {
        [JsonPropertyName("time")]
        public string time { get; set; }

        [JsonPropertyName("precipitation")]
        public string precipitation { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public string wind_speed_10m { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string temperature_2m { get; set; }

        [JsonPropertyName("weathercode")]
        public string weathercode { get; set; }

        [JsonPropertyName("wave_height")]
        public string wave_height { get; set; }
    }
}
