using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class DailyUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("precipitation_sum")]
        public string Precipitation_sum { get; set; }

        [JsonPropertyName("wind_speed_10m_max")]
        public string Wind_speed_10m_max { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public string Temperature_2m_max { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public string Temperature_2m_min { get; set; }

        [JsonPropertyName("weathercode")]
        public string Weathercode { get; set; }
    }
}
