using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ExtensionType
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        protected bool Equals(ExtensionType other)
        {
            return string.Equals(Id, other.Id) && string.Equals(Label, other.Label);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ExtensionType) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Id != null ? Id.GetHashCode() : 0) * 397) ^ (Label != null ? Label.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return Id;
        }
    }
}