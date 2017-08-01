using System;
using System.Diagnostics;
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

            eventService.ItemStateChanged += EventServiceOnItemStateChanged;
            eventService.UnknownEventOccured += EventServiceOnUnknownEventOccured;
            eventService.ItemCommandEventOccured += EventServiceOnItemCommandEventOccured;

            Console.ReadLine();
        }

        private static void EventServiceOnItemCommandEventOccured(object sender, ItemCommandEvent eventObject)
        {
            Debug.WriteLine(
                $"{eventObject.Occured}\t\t{eventObject.Type}:\t\t{eventObject.CommandType} was called with Parameter {eventObject.CommandValue}");
        }

        private static void EventServiceOnUnknownEventOccured(object sender, UnknownEvent eventObject)
        {
            Debug.WriteLine(
                $"{eventObject.Occured}\t\t{eventObject.Type}:\t\t{eventObject.Target}");
        }

        private static void EventServiceOnItemStateChanged(object sender, ItemStateChangedEvent eventObject)
        {
            Debug.WriteLine(
                $"{eventObject.Occured}\t\t{eventObject.Type}:\t\t{eventObject.Target} changed from {eventObject.OldStateValue} to {eventObject.StateValue}");
        }
    }
}
