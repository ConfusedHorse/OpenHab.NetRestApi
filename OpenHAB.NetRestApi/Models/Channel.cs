using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Channel
    {
        //[JsonProperty("linkedItems")]
        //public List<object> LinkedItems { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("channelTypeUID")]
        public string TypeUid { get; set; }

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

        [JsonProperty("properties")]
        public object Properties { get; set; }

        [JsonProperty("configuration")]
        public object ThingConfiguration { get; set; }
    }
}