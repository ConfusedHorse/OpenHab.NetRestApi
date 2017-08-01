using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void InboxRemovedEventHandler(object sender, InboxRemovedEvent eventObject);

    public class InboxRemovedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public Inbox Payload { get; set; }

        #region Payload Parameters

        public Inbox Inbox => Payload;

        #endregion
    }
}