using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void RuleRemovedEventHandler(object sender, RuleRemovedEvent eventObject);

    public class RuleRemovedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public Rule Payload { get; set; }

        #region Payload Parameters

        public Rule Rule => Payload;

        #endregion
    }
}