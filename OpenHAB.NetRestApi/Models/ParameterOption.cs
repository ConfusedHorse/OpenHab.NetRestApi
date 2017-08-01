using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ParameterOption
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}