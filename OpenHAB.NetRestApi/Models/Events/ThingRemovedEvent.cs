using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ThingRemovedEventHandler(object sender, ThingRemovedEvent eventObject);

    public class ThingRemovedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public Thing Payload { get; set; }

        #region Payload Parameters

        public Thing Thing => Payload;

        #endregion
    }
}