using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class LinkedPage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        public string PageId => Regex.Match(Link, @"http://(.*?)/rest/(.*?)/(.*?)/(.*)").Groups[4].Value;

        [JsonProperty("leaf")]
        public bool Leaf { get; set; }

        [JsonProperty("widgets")]
        public List<Widget> Widgets { get; set; }
    }
}