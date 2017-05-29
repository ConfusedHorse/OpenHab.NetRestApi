using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Thing
    {
        [JsonProperty("statusInfo")]
        public StatusInfo StatusInfo { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        //[JsonProperty("bridgeUID")]
        //public string BridgeUid { get; set; }

        [JsonProperty("configuration")]
        public object Configuration { get; set; }

        [JsonProperty("properties")]
        public object Properties { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("thingTypeUID")]
        public string ThingTypeUid { get; set; }

        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }
    }
}