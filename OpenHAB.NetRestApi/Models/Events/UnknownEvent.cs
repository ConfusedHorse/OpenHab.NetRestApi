using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void UnknownEventHandler(object sender, UnknownEvent eventObject);

    public class UnknownEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public object Payload { get; set; }
    }
}