using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Property
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("oldType")]
        public string OldType { get; set; }

        [JsonProperty("oldValue")]
        public string OldValue { get; set; }

        protected bool Equals(Property other)
        {
            return string.Equals(Type, other.Type) && string.Equals(Value, other.Value) &&
                   string.Equals(OldType, other.OldType) && string.Equals(OldValue, other.OldValue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Property) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Type != null ? Type.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OldType != null ? OldType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OldValue != null ? OldValue.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"({Type}) {Value}";
        }
    }
}