using System;
using System.Linq;
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
            var thingTypeService = openHab.ThingTypeService;

            var things = openHab.ThingService.GetThings();

            var thingTypes = thingTypeService.GetThingTypes();
            var firstUid = thingTypes.FirstOrDefault(tt => tt.Uid.Contains("hue") && !tt.Uid.Contains("bridge"))?.Uid;
            var thingType = thingTypeService.GetThingType(firstUid);
            
            Console.ReadLine();
        }
    }
}
