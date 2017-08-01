using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void RuleStatusInfoEventHandler(object sender, RuleStatusInfoEvent eventObject);

    public class RuleStatusInfoEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public StatusInfo Payload { get; set; }

        #region Payload Parameters

        public string Status => Payload.Status;

        public string StatusDetail => Payload.StatusDetail;

        #endregion
    }
}