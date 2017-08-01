using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ThingAddedEventHandler(object sender, ThingAddedEvent eventObject);

    public class ThingAddedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public Thing Payload { get; set; }

        #region Payload Parameters

        public Thing Thing => Payload;

        #endregion
    }
}