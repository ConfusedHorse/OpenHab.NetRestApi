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
            var serviceService = openHab.ServiceService;

            var services = serviceService.GetServices();
            var anyService = services.FirstOrDefault(s => s.Id == "org.eclipse.smarthome.audio");

            var configuration = serviceService.GetServiceConfiguration(anyService?.Id);
            var configDescription = openHab.ConfigDescriptionService.GetConfigDescription(anyService?.ConfigDescriptionUri);

            var deleted = serviceService.DeleteServiceConfiguration(anyService?.Id);
            var readded = serviceService.UpdateServiceConfiguration(anyService?.Id, configuration);
            var success = configuration == readded;

            Console.ReadLine();
        }
    }
}
