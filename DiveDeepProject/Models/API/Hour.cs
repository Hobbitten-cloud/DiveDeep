using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class Hour
    {
        [JsonPropertyName("precipitation")]
        public Precipitation Precipitation { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("waveHeight")]
        public WaveHeight WaveHeight { get; set; }

        [JsonPropertyName("windSpeed")]
        public WindSpeed WindSpeed { get; set; }
    }
}
