using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class WaveHeight
    {
        [JsonPropertyName("dwd")]
        public double Dwd { get; set; }

        [JsonPropertyName("ecmwf")]
        public double Ecmwf { get; set; }

        [JsonPropertyName("fcoo")]
        public double Fcoo { get; set; }

        [JsonPropertyName("fmi")]
        public double Fmi { get; set; }

        [JsonPropertyName("metno")]
        public double Metno { get; set; }

        [JsonPropertyName("noaa")]
        public double Noaa { get; set; }

        [JsonPropertyName("sg")]
        public double Sg { get; set; }
    }
}
