using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Widget
    {
        [JsonProperty("widgetId")]
        public string WidgetId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("mappings")]
        public List<object> Mappings { get; set; }

        [JsonProperty("item")]
        public Item Item { get; set; }

        [JsonProperty("linkedPage")]
        public LinkedPage LinkedPage { get; set; }

        [JsonProperty("widgets")]
        public List<Widget> Widgets { get; set; }

        [JsonProperty("switchSupport")]
        public bool? SwitchSupport { get; set; }

        [JsonProperty("sendFrequency")]
        public int? SendFrequency { get; set; }

        protected bool Equals(Widget other)
        {
            return string.Equals(WidgetId, other.WidgetId) && string.Equals(Type, other.Type) &&
                   string.Equals(Label, other.Label) && string.Equals(Icon, other.Icon) &&
                   Equals(Mappings, other.Mappings) && Equals(Item, other.Item) &&
                   Equals(LinkedPage, other.LinkedPage) && Equals(Widgets, other.Widgets) &&
                   SwitchSupport == other.SwitchSupport && SendFrequency == other.SendFrequency;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Widget) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = WidgetId != null ? WidgetId.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Type != null ? Type.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Label != null ? Label.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Icon != null ? Icon.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Mappings != null ? Mappings.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Item != null ? Item.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (LinkedPage != null ? LinkedPage.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Widgets != null ? Widgets.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ SwitchSupport.GetHashCode();
                hashCode = (hashCode * 397) ^ SendFrequency.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return WidgetId;
        }
    }
}