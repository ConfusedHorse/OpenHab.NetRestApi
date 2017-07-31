using System;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public class Event : EventArgs
    {
        [JsonProperty("topic")]
        public string Topic { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public string Target { get; set; }

        public DateTime Occured { get; set; }
    }
}