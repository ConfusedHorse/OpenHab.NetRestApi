using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void PlayUrlEventHandler(object sender, PlayUrlEvent eventObject);

    public class PlayUrlEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public string Payload { get; set; }
    }
}