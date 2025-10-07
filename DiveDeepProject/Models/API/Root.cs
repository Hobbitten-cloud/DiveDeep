using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class Root
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("generationtime_ms")]
        public double Generationtime_ms { get; set; }

        [JsonPropertyName("utc_offset_seconds")]
        public int Utc_Offset_Seconds { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("timezone_abbreviation")]
        public string Timezone_Abbreviation { get; set; }

        [JsonPropertyName("elevation")]
        public double Elevation { get; set; }

        [JsonPropertyName("daily_units")]
        public DailyUnits Daily_Units { get; set; }

        [JsonPropertyName("daily")]
        public Daily Daily { get; set; }

        [JsonPropertyName("hourly_units")]
        public HourlyUnits Hourly_Units { get; set; }

        [JsonPropertyName("hourly")]
        public Hourly Hourly { get; set; }
    }

}
