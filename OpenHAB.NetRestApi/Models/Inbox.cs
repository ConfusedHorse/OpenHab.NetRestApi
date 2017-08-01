using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Inbox
    {
        [JsonProperty("bridgeUID")]
        public string BridgeUid { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("properties")]
        public object Properties { get; set; }

        [JsonProperty("representationProperty")]
        public string RepresentationProperty { get; set; }

        [JsonProperty("thingUID")]
        public string ThingUid { get; set; }

        [JsonProperty("thingTypeUID")]
        public string ThingTypeUid { get; set; }
    }
}