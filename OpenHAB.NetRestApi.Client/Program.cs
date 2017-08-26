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
        //private const string Url = "localhost";
        private const string Url = "192.168.2.111";
        private const bool StartEventService = false;

        static void Main(string[] args)
        {
            var openHab = OpenHab.CreateRestClient(Url, StartEventService);
            var success = openHab.TestConnection();

            //tests go here
            var thingService = openHab.ThingService;
            foreach (var thing in thingService.GetThings())
            {
                thing.ItemChannelLinkAdded += EventServiceOnItemChannelLinkAdded;
                thing.ItemChannelLinkRemoved += EventServiceOnItemChannelLinkRemoved;

                thing.InitializeEvents();
            }

            Console.ReadLine();
        }

        private static void EventServiceOnItemChannelLinkAdded(object sender, ItemChannelLinkAddedEvent eventObject)
        {
            Debug.WriteLine(sender);
        }

        private static void EventServiceOnItemChannelLinkRemoved(object sender, ItemChannelLinkRemovedEvent eventObject)
        {
            Debug.WriteLine(sender);
        }
    }
}
