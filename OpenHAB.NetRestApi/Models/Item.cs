using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Item
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("groupNames")]
        public List<string> GroupNames { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("transformedState")]
        public string TransformedState { get; set; }

        [JsonProperty("stateDescription")]
        public StateDescription StateDescription { get; set; }
    }
}