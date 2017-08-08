using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Channel
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("channelTypeUID")]
        public string ChannelTypeUid { get; set; }

        [JsonProperty("typeUID ")]
        public string TypeUid => ChannelTypeUid;

        [JsonProperty("itemType")]
        public string ItemType { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("defaultTags")]
        public List<string> DefaultTags { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags => DefaultTags;

        [JsonProperty("properties")]
        public object Properties { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("stateDescription")]
        public StateDescription StateDescription { get; set; }

        [JsonProperty("advanced")]
        public bool Advanced { get; set; }

        [JsonProperty("configuration")]
        public object ThingConfiguration { get; set; }

        protected bool Equals(Channel other)
        {
            return string.Equals(Uid, other.Uid) && string.Equals(Id, other.Id) &&
                   string.Equals(ChannelTypeUid, other.ChannelTypeUid) && string.Equals(ItemType, other.ItemType) &&
                   string.Equals(Kind, other.Kind) && string.Equals(Label, other.Label) &&
                   string.Equals(Description, other.Description) && Equals(DefaultTags, other.DefaultTags) &&
                   Equals(Properties, other.Properties) && string.Equals(Category, other.Category) &&
                   Equals(StateDescription, other.StateDescription) && Advanced == other.Advanced &&
                   Equals(ThingConfiguration, other.ThingConfiguration);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Channel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Uid != null ? Uid.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ChannelTypeUid != null ? ChannelTypeUid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ItemType != null ? ItemType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Kind != null ? Kind.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DefaultTags != null ? DefaultTags.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Properties != null ? Properties.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Category != null ? Category.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (StateDescription != null ? StateDescription.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Advanced.GetHashCode();
                hashCode = (hashCode * 397) ^ (ThingConfiguration != null ? ThingConfiguration.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Uid;
        }
    }
}