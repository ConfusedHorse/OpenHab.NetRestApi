using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Widget
    {
        [JsonProperty("widgetId")]
        public string WidgetId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("mappings")]
        public List<object> Mappings { get; set; }

        [JsonProperty("item")]
        public Item Item { get; set; }

        [JsonProperty("linkedPage")]
        public LinkedPage LinkedPage { get; set; }

        [JsonProperty("widgets")]
        public List<Widget> Widgets { get; set; }

        [JsonProperty("switchSupport")]
        public bool? SwitchSupport { get; set; }

        [JsonProperty("sendFrequency")]
        public int? SendFrequency { get; set; }
    }
}