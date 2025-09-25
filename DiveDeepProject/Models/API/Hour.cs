using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class Hour
    {
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("windSpeed")]
        public Dictionary<string, double> WindSpeed { get; set; }

        [JsonPropertyName("waveHeight")]
        public Dictionary<string, double> WaveHeight { get; set; }

        [JsonPropertyName("precipitation")]
        public Dictionary<string, double> Precipitation { get; set; }
    }
}
