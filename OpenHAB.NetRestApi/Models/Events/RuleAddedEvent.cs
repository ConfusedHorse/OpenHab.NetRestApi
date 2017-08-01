using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void RuleAddedEventHandler(object sender, RuleAddedEvent eventObject);

    public class RuleAddedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public Rule Payload { get; set; }

        #region Payload Parameters

        public Rule Rule => Payload;

        #endregion
    }
}