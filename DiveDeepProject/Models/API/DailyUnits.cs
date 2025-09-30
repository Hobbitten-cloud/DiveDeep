using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class DailyUnits
    {
        [JsonPropertyName("time")]
        public string time { get; set; }

        [JsonPropertyName("precipitation_sum")]
        public string precipitation_sum { get; set; }

        [JsonPropertyName("wind_speed_10m_max")]
        public string wind_speed_10m_max { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public string temperature_2m_max { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public string temperature_2m_min { get; set; }

        [JsonPropertyName("weathercode")]
        public string weathercode { get; set; }
    }
}
