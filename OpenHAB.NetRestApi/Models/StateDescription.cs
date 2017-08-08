using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class StateDescription
    {
        [JsonProperty("minimum")]
        public int Minimum { get; set; }

        [JsonProperty("maximum")]
        public int Maximum { get; set; }

        [JsonProperty("readOnly")]
        public bool ReadOnly { get; set; }

        [JsonProperty("options")]
        public List<Option> Options { get; set; }

        [JsonProperty("step")]
        public int? Step { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }

        protected bool Equals(StateDescription other)
        {
            return Minimum == other.Minimum && Maximum == other.Maximum && ReadOnly == other.ReadOnly &&
                   Equals(Options, other.Options) && Step == other.Step && string.Equals(Pattern, other.Pattern);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((StateDescription) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Minimum;
                hashCode = (hashCode * 397) ^ Maximum;
                hashCode = (hashCode * 397) ^ ReadOnly.GetHashCode();
                hashCode = (hashCode * 397) ^ (Options != null ? Options.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Step.GetHashCode();
                hashCode = (hashCode * 397) ^ (Pattern != null ? Pattern.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Pattern;
        }
    }
}