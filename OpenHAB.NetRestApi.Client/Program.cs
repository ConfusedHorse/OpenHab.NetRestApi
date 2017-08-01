using System;
using System.Diagnostics;
using Newtonsoft.Json;
using OpenHAB.NetRestApi.Models.Events;
using OpenHAB.NetRestApi.RestApi;

namespace OpenHAB.NetRestApi.Client
{
    /// <summary>
    /// THIS IS A TEST ENVIRONMENT (can be ignored)
    /// </summary>
    class Program
    {
        //private const string Url = "http://localhost:8080/rest";
        private const string Url = "http://192.168.2.111:8080/rest";
        private const bool StartEventService = true;

        static void Main(string[] args)
        {
            var openHab = OpenHab.CreateRestClient(Url, StartEventService);
            var eventService = openHab.EventService;
            
            eventService.ItemStateEventOccured += DebugAnyEventOccured;
            eventService.ItemStateChanged += DebugAnyEventOccured;
            eventService.ItemCommandEventOccured += DebugAnyEventOccured;
            eventService.ItemAdded += DebugAnyEventOccured;
            eventService.ItemRemoved += DebugAnyEventOccured;
            eventService.ItemChannelLinkAdded += DebugAnyEventOccured;
            eventService.ItemChannelLinkRemoved += DebugAnyEventOccured;

            eventService.ThingStatusInfoEventOccured += DebugAnyEventOccured;
            eventService.ThingStatusInfoChanged += DebugAnyEventOccured;
            eventService.ThingUpdated += DebugAnyEventOccured;
            eventService.ThingRemoved += DebugAnyEventOccured;

            eventService.InboxAdded += DebugAnyEventOccured;
            eventService.InboxRemoved += DebugAnyEventOccured;

            eventService.RuleStatusInfoEventOccured += DebugAnyEventOccured;
            eventService.RuleAdded += DebugAnyEventOccured;
            eventService.RuleUpdated += DebugAnyEventOccured;
            eventService.RuleRemoved += DebugAnyEventOccured;

            eventService.ConfigStatusInfoEventOccured += DebugAnyEventOccured;
            eventService.PlayUrlEventOccured += DebugAnyEventOccured;
            eventService.UnknownEventOccured += DebugAnyEventOccured;

            Console.ReadLine();
        }

        private static void DebugAnyEventOccured(object sender, OpenHabEvent eventObject)
        {
            Debug.WriteLine(
                $"{eventObject.Occured}\t\t{eventObject.Type}:\t\t{eventObject.Target}({eventObject.Action})");
            object payload = ((dynamic) eventObject).Payload;
            Debug.WriteLine(JsonConvert.SerializeObject(payload));
            Debug.WriteLine(string.Empty);
        }
    }
}
