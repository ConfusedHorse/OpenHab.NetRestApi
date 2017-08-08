using Newtonsoft.Json;
using OpenHAB.NetRestApi.RestApi;

namespace OpenHAB.NetRestApi.Models
{
    public class Inbox
    {
        [JsonProperty("bridgeUID")]
        public string BridgeUid { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("properties")]
        public object Properties { get; set; }

        [JsonProperty("representationProperty")]
        public string RepresentationProperty { get; set; }

        [JsonProperty("thingUID")]
        public string ThingUid { get; set; }

        [JsonProperty("thingTypeUID")]
        public string ThingTypeUid { get; set; }

        protected bool Equals(Inbox other)
        {
            return string.Equals(BridgeUid, other.BridgeUid) && string.Equals(Flag, other.Flag) &&
                   string.Equals(Label, other.Label) && Equals(Properties, other.Properties) &&
                   string.Equals(RepresentationProperty, other.RepresentationProperty) &&
                   string.Equals(ThingUid, other.ThingUid) && string.Equals(ThingTypeUid, other.ThingTypeUid);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Inbox) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = BridgeUid != null ? BridgeUid.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Flag != null ? Flag.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Properties != null ? Properties.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^
                           (RepresentationProperty != null ? RepresentationProperty.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ThingUid != null ? ThingUid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ThingTypeUid != null ? ThingTypeUid.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return ThingUid;
        }

        #region Service Methods

        /// <summary>
        ///     Approves the discovery result by adding the thing to the registry.
        /// </summary>
        /// <returns></returns>
        public string Accept()
        {
            return OpenHab.RestClient.InboxService.AcceptInbox(ThingUid, Label);
        }

        /// <summary>
        ///     Removes the discovery result from the inbox.
        /// </summary>
        /// <returns></returns>
        public string Delete()
        {
            return OpenHab.RestClient.InboxService.DeleteInbox(ThingUid);
        }

        /// <summary>
        ///     Flags a discovery result as ignored for further processing.
        /// </summary>
        /// <returns></returns>
        public string Ignore()
        {
            return OpenHab.RestClient.InboxService.IgnoreInbox(ThingUid);
        }

        /// <summary>
        ///     Removes ignore flag from a discovery result.
        /// </summary>
        /// <returns></returns>
        public string Unignore()
        {
            return OpenHab.RestClient.InboxService.UnignoreInbox(ThingUid);
        }

        #endregion
    }
}