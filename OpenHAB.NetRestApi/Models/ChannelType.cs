using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ChannelType
    {
        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set; }

        [JsonProperty("parameterGroups")]
        public List<ParameterGroup> ParameterGroups { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("itemType")]
        public string ItemType { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("UID")]
        public string Uid { get; set; }

        [JsonProperty("advanced")]
        public bool Advanced { get; set; }

        [JsonProperty("stateDescription")]
        public StateDescription StateDescription { get; set; }

        protected bool Equals(ChannelType other)
        {
            return Equals(Parameters, other.Parameters) && Equals(ParameterGroups, other.ParameterGroups) &&
                   string.Equals(Description, other.Description) && string.Equals(Label, other.Label) &&
                   string.Equals(Category, other.Category) && string.Equals(ItemType, other.ItemType) &&
                   string.Equals(Kind, other.Kind) && Equals(Tags, other.Tags) && string.Equals(Uid, other.Uid) &&
                   Advanced == other.Advanced && Equals(StateDescription, other.StateDescription);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ChannelType) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Parameters != null ? Parameters.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (ParameterGroups != null ? ParameterGroups.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Category != null ? Category.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ItemType != null ? ItemType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Kind != null ? Kind.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Tags != null ? Tags.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Uid != null ? Uid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Advanced.GetHashCode();
                hashCode = (hashCode * 397) ^ (StateDescription != null ? StateDescription.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Uid;
        }
    }
}