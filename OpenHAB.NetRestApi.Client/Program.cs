using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.Models.Events;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Client
{
    /// <summary>
    /// THIS IS A TEST ENVIRONMENT (can be ignored)
    /// </summary>
    class Program
    {
        //private const string Url = "http://localhost:8080/rest";
        private const string Url = "http://192.168.2.111:8080/rest";

        static void Main(string[] args)
        {
            var openHab = OpenHab.CreateRestClient(Url);

            var eventService = openHab.EventService;
            eventService.OpenHabBusEventOccured += EventServiceOnOpenHabBusEventOccured;
            eventService.InitializeAsync();

            //var thingToChange = new Thing
            //{
            //    Uid = "yahooweather:weather",
            //    ThingTypeUid = "yahooweather:weather",
            //    Label = "YahooWeather",
            //    Location = "Berlin",
            //    Configuration = new { refresh = 60, location = 638242 },
            //    StatusInfo = new StatusInfo { Status = "ONLINE", StatusDetail = "NONE" }
            //};

            //var resp = openHab.ThingService.CreateThing(thingToChange);

            //var things = openHab.ThingService.GetThings();
            //var yahooweather = things.FirstOrDefault(t => t.Label.Contains("hue"));
            //var channels = yahooweather?.Channels;
            //var firstChannel = channels?.FirstOrDefault();

            //var deleteThing = openHab.ThingService.DeleteChannelLink(yahooweather, firstChannel);
            //var createThing = openHab.ThingService.CreateChannelLink(yahooweather, firstChannel);

            Console.ReadLine();
        }

        private static void EventServiceOnOpenHabBusEventOccured(object sender, Event eventObject)
        {
            Debug.WriteLine($"{eventObject.Occured}\t{eventObject.Target}\t{eventObject.Type}");
        }
    }
}
