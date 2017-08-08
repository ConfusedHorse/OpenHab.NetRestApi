using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Action
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("configuration")]
        public object Configuration { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("inputs")]
        public object Inputs { get; set; }

        protected bool Equals(Action other)
        {
            return string.Equals(Id, other.Id) && string.Equals(Label, other.Label) &&
                   string.Equals(Description, other.Description) && Equals(Configuration, other.Configuration) &&
                   string.Equals(Type, other.Type) && Equals(Inputs, other.Inputs);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Action) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id != null ? Id.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Configuration != null ? Configuration.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Inputs != null ? Inputs.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Id;
        }
    }
}