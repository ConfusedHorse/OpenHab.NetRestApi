using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ServiceConfiguration
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set; }

        [JsonProperty("parameterGroups")]
        public List<ParameterGroup> ParameterGroups { get; set; }

        protected bool Equals(ServiceConfiguration other)
        {
            return string.Equals(Uri, other.Uri) && Equals(Parameters, other.Parameters) &&
                   Equals(ParameterGroups, other.ParameterGroups);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ServiceConfiguration) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Uri != null ? Uri.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Parameters != null ? Parameters.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ParameterGroups != null ? ParameterGroups.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Uri;
        }
    }
}