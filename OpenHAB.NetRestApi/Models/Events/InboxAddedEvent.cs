using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void InboxAddedEventHandler(object sender, InboxAddedEvent eventObject);

    public class InboxAddedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public Inbox Payload { get; set; }

        #region Payload Parameters

        public Inbox Inbox => Payload;

        #endregion
    }
}