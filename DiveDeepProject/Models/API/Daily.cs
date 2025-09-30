using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class Daily
    {
        [JsonPropertyName("time")]
        public List<string> time { get; set; }

        [JsonPropertyName("precipitation_sum")]
        public List<double> precipitation_sum { get; set; }

        [JsonPropertyName("wind_speed_10m_max")]
        public List<double> wind_speed_10m_max { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<double> temperature_2m_max { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double> temperature_2m_min { get; set; }

        [JsonPropertyName("weathercode")]
        public List<int> weathercode { get; set; }
    }
}
