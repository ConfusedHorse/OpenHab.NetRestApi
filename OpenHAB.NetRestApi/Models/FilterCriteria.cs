using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class FilterCriteria
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}