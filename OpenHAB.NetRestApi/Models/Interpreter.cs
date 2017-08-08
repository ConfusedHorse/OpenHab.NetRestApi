using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Interpreter
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("locales")]
        public List<string> Locales { get; set; }

        protected bool Equals(Interpreter other)
        {
            return string.Equals(Id, other.Id) && string.Equals(Label, other.Label) && Equals(Locales, other.Locales);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Interpreter) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id != null ? Id.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Locales != null ? Locales.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Id;
        }
    }
}