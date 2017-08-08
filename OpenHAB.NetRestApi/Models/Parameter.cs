using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Parameter
    {
        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }

        [JsonProperty("stepsize")]
        public int Stepsize { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }

        [JsonProperty("readOnly")]
        public bool ReadOnly { get; set; }

        [JsonProperty("multiple")]
        public bool Multiple { get; set; }

        [JsonProperty("multipleLimit")]
        public int MultipleLimit { get; set; }

        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("advanced")]
        public bool Advanced { get; set; }

        [JsonProperty("verify")]
        public bool Verify { get; set; }

        [JsonProperty("limitToOptions")]
        public bool LimitToOptions { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("unitLabel")]
        public string UnitLabel { get; set; }

        [JsonProperty("options")]
        public List<Option> Options { get; set; }

        [JsonProperty("filterCriteria")]
        public List<FilterCriteria> FilterCriteria { get; set; }

        protected bool Equals(Parameter other)
        {
            return string.Equals(Context, other.Context) && string.Equals(DefaultValue, other.DefaultValue) &&
                   string.Equals(Description, other.Description) && string.Equals(Label, other.Label) &&
                   string.Equals(Name, other.Name) && Required == other.Required && string.Equals(Type, other.Type) &&
                   Min == other.Min && Max == other.Max && Stepsize == other.Stepsize &&
                   string.Equals(Pattern, other.Pattern) && ReadOnly == other.ReadOnly && Multiple == other.Multiple &&
                   MultipleLimit == other.MultipleLimit && string.Equals(GroupName, other.GroupName) &&
                   Advanced == other.Advanced && Verify == other.Verify && LimitToOptions == other.LimitToOptions &&
                   string.Equals(Unit, other.Unit) && string.Equals(UnitLabel, other.UnitLabel) &&
                   Equals(Options, other.Options) && Equals(FilterCriteria, other.FilterCriteria);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Parameter) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Context != null ? Context.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (DefaultValue != null ? DefaultValue.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Required.GetHashCode();
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Min;
                hashCode = (hashCode * 397) ^ Max;
                hashCode = (hashCode * 397) ^ Stepsize;
                hashCode = (hashCode * 397) ^ (Pattern != null ? Pattern.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ReadOnly.GetHashCode();
                hashCode = (hashCode * 397) ^ Multiple.GetHashCode();
                hashCode = (hashCode * 397) ^ MultipleLimit;
                hashCode = (hashCode * 397) ^ (GroupName != null ? GroupName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Advanced.GetHashCode();
                hashCode = (hashCode * 397) ^ Verify.GetHashCode();
                hashCode = (hashCode * 397) ^ LimitToOptions.GetHashCode();
                hashCode = (hashCode * 397) ^ (Unit != null ? Unit.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (UnitLabel != null ? UnitLabel.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Options != null ? Options.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FilterCriteria != null ? FilterCriteria.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}