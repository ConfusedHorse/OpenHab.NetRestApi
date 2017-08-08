using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ParameterGroup
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("advanced")]
        public bool Advanced { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        protected bool Equals(ParameterGroup other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Context, other.Context) &&
                   Advanced == other.Advanced && string.Equals(Label, other.Label) &&
                   string.Equals(Description, other.Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ParameterGroup) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name != null ? Name.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Context != null ? Context.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Advanced.GetHashCode();
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Name ?? GetType().ToString();
        }
    }
}