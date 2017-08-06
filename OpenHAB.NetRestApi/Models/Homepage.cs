using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Homepage
    {
        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("leaf")]
        public bool Leaf { get; set; }

        [JsonProperty("widgets")]
        public List<Widget> Widgets { get; set; }
    }
}