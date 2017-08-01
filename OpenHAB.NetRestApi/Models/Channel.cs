using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Channel
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("channelTypeUID")]
        public string ChannelTypeUid { get; set; }

        [JsonProperty("typeUID ")]
        public string TypeUid => ChannelTypeUid;

        [JsonProperty("itemType")]
        public string ItemType { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("defaultTags")]
        public List<string> DefaultTags { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags => DefaultTags;

        [JsonProperty("properties")]
        public object Properties { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("stateDescription")]
        public StateDescription StateDescription { get; set; }

        [JsonProperty("advanced")]
        public bool Advanced { get; set; }

        [JsonProperty("configuration")]
        public object ThingConfiguration { get; set; }
    }
}