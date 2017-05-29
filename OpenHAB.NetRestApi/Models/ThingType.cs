using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ThingType
    {
        [JsonProperty("UID")]
        public string Uid { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("listed")]
        public bool Listed { get; set; }

        [JsonProperty("supportedBridgeTypeUIDs")]
        public List<string> SupportedBridgeTypeUiDs { get; set; }

        [JsonProperty("bridge")]
        public bool Bridge { get; set; }
    }
}