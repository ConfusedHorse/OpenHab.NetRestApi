using System;
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
            var inboxService = openHab.InboxService;

            var inbox = inboxService.GetInbox();
            var acceptInbox = inboxService.AcceptInbox("validUid:0:0", "somelabel");

            Console.ReadLine();
        }
    }
}
