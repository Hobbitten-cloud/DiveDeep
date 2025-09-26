using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class Root
    {
        [JsonPropertyName("latitude")]
        public double latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double longitude { get; set; }

        [JsonPropertyName("generationtime_ms")]
        public double generationtime_ms { get; set; }

        [JsonPropertyName("utc_offset_seconds")]
        public int utc_offset_seconds { get; set; }

        [JsonPropertyName("timezone")]
        public string timezone { get; set; }

        [JsonPropertyName("timezone_abbreviation")]
        public string timezone_abbreviation { get; set; }

        [JsonPropertyName("elevation")]
        public double elevation { get; set; }

        [JsonPropertyName("daily_units")]
        public DailyUnits daily_units { get; set; }

        [JsonPropertyName("daily")]
        public Daily daily { get; set; }
    }

}
