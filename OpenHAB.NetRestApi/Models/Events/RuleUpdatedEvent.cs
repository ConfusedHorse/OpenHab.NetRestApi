using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void RuleUpdatedEventHandler(object sender, RuleUpdatedEvent eventObject);

    public class RuleUpdatedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public List<Rule> Payload { get; set; }

        #region Payload Parameters

        public Rule NewRule => Payload.FirstOrDefault();

        public Rule OldRule => Payload.LastOrDefault();

        #endregion
    }
}