using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class Daily
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("precipitation_sum")]
        public List<double> Precipitation_sum { get; set; }

        [JsonPropertyName("wind_speed_10m_max")]
        public List<double> Wind_speed_10m_max { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<double> Temperature_2m_max { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double> Temperature_2m_min { get; set; }

        [JsonPropertyName("weathercode")]
        public List<int> Weathercode { get; set; }
    }
}
