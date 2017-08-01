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
            var extensionService = openHab.ExtensionService;

            var extensions = extensionService.GetExtensions();
            var anExtension = extensionService.GetExtension(extensions.FirstOrDefault()?.Id);

            var installExtension = extensionService.InstallExtension(anExtension.Id);
            var uninstallExtension = extensionService.UninstallExtension(anExtension.Id);

            Console.ReadLine();
        }
    }
}
