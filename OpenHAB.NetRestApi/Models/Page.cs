using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Page
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("parent")]
        public Parent Parent { get; set; }

        [JsonProperty("leaf")]
        public bool Leaf { get; set; }

        [JsonProperty("widgets")]
        public List<Widget> Widgets { get; set; }
    }
}