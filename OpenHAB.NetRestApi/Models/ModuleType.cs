using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ModuleType
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("outputs")]
        public List<Output> Outputs { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("string")]
        public List<string> Tags { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("configDescriptions")]
        public List<ConfigDescription> ConfigDescriptions { get; set; }

        protected bool Equals(ModuleType other)
        {
            return string.Equals(Uid, other.Uid) && Equals(Outputs, other.Outputs) &&
                   string.Equals(Visibility, other.Visibility) && Equals(Tags, other.Tags) &&
                   string.Equals(Label, other.Label) && string.Equals(Description, other.Description) &&
                   Equals(ConfigDescriptions, other.ConfigDescriptions);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ModuleType) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Uid != null ? Uid.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Outputs != null ? Outputs.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Visibility != null ? Visibility.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Tags != null ? Tags.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ConfigDescriptions != null ? ConfigDescriptions.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Uid;
        }
    }
}