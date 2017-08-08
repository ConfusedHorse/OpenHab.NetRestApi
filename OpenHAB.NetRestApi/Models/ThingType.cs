using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ThingType
    {
        [JsonProperty("UID")]
        public string Uid { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("listed")]
        public bool Listed { get; set; }

        [JsonProperty("supportedBridgeTypeUIDs")]
        public List<string> SupportedBridgeTypeUiDs { get; set; }

        [JsonProperty("bridge")]
        public bool Bridge { get; set; }

        [JsonProperty("channels")]
        public List<Channel> Channels { get; set; }

        [JsonProperty("channelGroups")]
        public List<ChannelGroup> ChannelGroups { get; set; }

        [JsonProperty("configParameters")]
        public List<Parameter> ConfigParameters { get; set; }

        [JsonProperty("parameterGroups")]
        public List<ParameterGroup> ParameterGroups { get; set; }

        [JsonProperty("properties")]
        public object Properties { get; set; }

        protected bool Equals(ThingType other)
        {
            return string.Equals(Uid, other.Uid) && string.Equals(Label, other.Label) &&
                   string.Equals(Description, other.Description) && Listed == other.Listed &&
                   Equals(SupportedBridgeTypeUiDs, other.SupportedBridgeTypeUiDs) && Bridge == other.Bridge &&
                   Equals(Channels, other.Channels) && Equals(ChannelGroups, other.ChannelGroups) &&
                   Equals(ConfigParameters, other.ConfigParameters) && Equals(ParameterGroups, other.ParameterGroups) &&
                   Equals(Properties, other.Properties);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ThingType) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Uid != null ? Uid.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Listed.GetHashCode();
                hashCode = (hashCode * 397) ^ (SupportedBridgeTypeUiDs != null
                               ? SupportedBridgeTypeUiDs.GetHashCode()
                               : 0);
                hashCode = (hashCode * 397) ^ Bridge.GetHashCode();
                hashCode = (hashCode * 397) ^ (Channels != null ? Channels.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ChannelGroups != null ? ChannelGroups.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ConfigParameters != null ? ConfigParameters.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ParameterGroups != null ? ParameterGroups.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Properties != null ? Properties.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Uid;
        }
    }
}