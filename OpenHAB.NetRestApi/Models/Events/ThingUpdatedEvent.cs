using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void ThingUpdatedEventHandler(object sender, ThingUpdatedEvent eventObject);

    public class ThingUpdatedEvent : OpenHabEvent
    {
        [JsonProperty("payload")]
        public List<Thing> Payload { get; set; }

        #region Payload Parameters

        public Thing NewThing => Payload.FirstOrDefault();

        public Thing OldThing => Payload.LastOrDefault();

        #endregion
    }
}