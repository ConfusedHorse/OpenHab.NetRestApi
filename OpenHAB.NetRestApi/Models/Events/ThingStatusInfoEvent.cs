using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ThingStatusInfoEventHandler(object sender, ThingStatusInfoEvent eventObject);

    public class ThingStatusInfoEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public StatusInfo Payload { get; set; }

        #region Payload Parameters

        public string Status => Payload.Status;
        
        public string StatusDetail => Payload.StatusDetail;

        public string Description => Payload.Description;

        #endregion
    }
}