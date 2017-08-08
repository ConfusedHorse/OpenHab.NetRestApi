using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class ConfigDescription
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("readOnly")]
        public bool ReadOnly { get; set; }

        [JsonProperty("multiple")]
        public bool Multiple { get; set; }

        [JsonProperty("multipleLimit")]
        public int MultipleLimit { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("unitLabel")]
        public string UnitLabel { get; set; }

        [JsonProperty("context")]
        public string Context { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("options")]
        public List<Option> Options { get; set; }

        [JsonProperty("filterCriteria")]
        public List<FilterCriteria> FilterCriteria { get; set; }

        [JsonProperty("limitToOptions")]
        public bool LimitToOptions { get; set; }

        [JsonProperty("advanced")]
        public bool Advanced { get; set; }

        [JsonProperty("stepSize")]
        public int StepSize { get; set; }

        [JsonProperty("verifyable")]
        public bool Verifyable { get; set; }

        [JsonProperty("default")]
        public string Default { get; set; }

        [JsonProperty("minimum")]
        public int Minimum { get; set; }

        [JsonProperty("maximum")]
        public int Maximum { get; set; }

        protected bool Equals(ConfigDescription other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Type, other.Type) &&
                   string.Equals(GroupName, other.GroupName) && string.Equals(Pattern, other.Pattern) &&
                   Required == other.Required && ReadOnly == other.ReadOnly && Multiple == other.Multiple &&
                   MultipleLimit == other.MultipleLimit && string.Equals(Unit, other.Unit) &&
                   string.Equals(UnitLabel, other.UnitLabel) && string.Equals(Context, other.Context) &&
                   string.Equals(Label, other.Label) && string.Equals(Description, other.Description) &&
                   Equals(Options, other.Options) && Equals(FilterCriteria, other.FilterCriteria) &&
                   LimitToOptions == other.LimitToOptions && Advanced == other.Advanced && StepSize == other.StepSize &&
                   Verifyable == other.Verifyable && string.Equals(Default, other.Default) &&
                   Minimum == other.Minimum && Maximum == other.Maximum;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ConfigDescription) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name != null ? Name.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (GroupName != null ? GroupName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Pattern != null ? Pattern.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Required.GetHashCode();
                hashCode = (hashCode * 397) ^ ReadOnly.GetHashCode();
                hashCode = (hashCode * 397) ^ Multiple.GetHashCode();
                hashCode = (hashCode * 397) ^ MultipleLimit;
                hashCode = (hashCode * 397) ^ (Unit != null ? Unit.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (UnitLabel != null ? UnitLabel.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Context != null ? Context.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Options != null ? Options.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FilterCriteria != null ? FilterCriteria.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ LimitToOptions.GetHashCode();
                hashCode = (hashCode * 397) ^ Advanced.GetHashCode();
                hashCode = (hashCode * 397) ^ StepSize;
                hashCode = (hashCode * 397) ^ Verifyable.GetHashCode();
                hashCode = (hashCode * 397) ^ (Default != null ? Default.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Minimum;
                hashCode = (hashCode * 397) ^ Maximum;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return Name ?? GetType().ToString();
        }
    }
}