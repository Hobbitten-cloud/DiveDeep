using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class Meta
    {
        [JsonPropertyName("cost")]
        public int Cost { get; set; }

        [JsonPropertyName("dailyQuota")]
        public int DailyQuota { get; set; }

        [JsonPropertyName("end")]
        public string End { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lng")]
        public double Lng { get; set; }

        [JsonPropertyName("params")]
        public List<string> @Params { get; set; }

        [JsonPropertyName("requestCount")]
        public int RequestCount { get; set; }

        [JsonPropertyName("start")]
        public string Start { get; set; }
    }
}
