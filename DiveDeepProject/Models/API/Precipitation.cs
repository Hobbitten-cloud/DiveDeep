using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class Precipitation
    {
        [JsonPropertyName("dwd")]
        public double Dwd { get; set; }

        [JsonPropertyName("ecmwf")]
        public double Ecmwf { get; set; }

        [JsonPropertyName("ecmwf:aifs")]
        public double Ecmwfaifs { get; set; }

        [JsonPropertyName("noaa")]
        public double Noaa { get; set; }

        [JsonPropertyName("sg")]
        public double Sg { get; set; }

        [JsonPropertyName("smhi")]
        public double Smhi { get; set; }
    }
}
