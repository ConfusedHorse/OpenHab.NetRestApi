using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Client
{
    /// <summary>
    /// THIS IS A TEST ENVIRONMENT (can be ignored)
    /// </summary>
    class Program
    {
        private const string Url = "http://localhost:8080/rest";

        static void Main(string[] args)
        {
            var openHab = OpenHab.CreateRestClient(Url);
            
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

            var yahooweather = openHab.ThingService.GetThing("yahooweather:weather:a527b460c001");
            var channels = yahooweather.Channels;
            var firstChannel = channels.First();

            var deleteThing = openHab.ThingService.DeleteChannelLink(yahooweather, firstChannel);
            var createThing = openHab.ThingService.CreateChannelLink(yahooweather, firstChannel);

            Console.ReadLine();
        }
    }
}
