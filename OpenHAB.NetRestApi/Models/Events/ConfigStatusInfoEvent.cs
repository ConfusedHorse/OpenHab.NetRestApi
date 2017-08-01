using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ConfigStatusInfoEventHandler(object sender, ConfigStatusInfoEvent eventObject);

    public class ConfigStatusInfoEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public List<Property> Payload { get; set; }
    }
}