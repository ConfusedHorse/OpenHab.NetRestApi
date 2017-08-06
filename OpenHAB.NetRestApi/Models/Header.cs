using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace OpenHAB.NetRestApi.Models
{
    public class Header
    {
        [JsonProperty("Location")]
        public List<string> Locations { get; set; }
        
        public List<string> SubscriptionIds 
            => Locations.Select(l => 
            Regex.Match(l, @"http://(.*?)/rest/(.*?)/(.*?)/(.*)").Groups[4].Value)
            .ToList();
    }
}