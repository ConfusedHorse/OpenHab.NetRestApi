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

            var channelTypes = openHab.ChannelTypeService.GetChannelTypes();
            var channelType = openHab.ChannelTypeService.GetChannelType(channelTypes.FirstOrDefault()?.Uid);

            Console.ReadLine();
        }

        private static void EventServiceOnOpenHabBusEventOccured(object sender, Event eventObject)
        {
            Debug.WriteLine($"{eventObject.Occured}\t{eventObject.Target}\t{eventObject.Type}");
        }
    }
}
