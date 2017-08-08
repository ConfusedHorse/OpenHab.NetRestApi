using System;
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

            Console.ReadLine();
        }
    }
}
