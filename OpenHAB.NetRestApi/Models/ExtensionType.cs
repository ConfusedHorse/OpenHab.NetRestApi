using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ExtensionType
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}