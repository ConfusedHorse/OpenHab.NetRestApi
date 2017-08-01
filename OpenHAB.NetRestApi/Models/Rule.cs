using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Rule
    {
        [JsonProperty("triggers")]
        public List<Trigger> Triggers { get; set; }

        [JsonProperty("conditions")]
        public List<Condition> Conditions { get; set; }

        [JsonProperty("actions")]
        public List<Action> Actions { get; set; }

        [JsonProperty("configuration")]
        public object Configuration { get; set; }

        [JsonProperty("configDescriptions")]
        public List<ConfigDescription> ConfigDescriptions { get; set; }

        [JsonProperty("templateUID")]
        public string TemplateUid { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("status")]
        public StatusInfo Status { get; set; }
    }
}