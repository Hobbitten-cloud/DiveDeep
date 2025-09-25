using System.Text.Json.Serialization;

namespace DiveDeepProject.Models.API
{
    public class Root
    {
        [JsonPropertyName("hours")]
        public List<Hour> Hours { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }
}
