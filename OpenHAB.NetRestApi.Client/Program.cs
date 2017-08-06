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
            var sitemapService = openHab.SitemapService;

            var sitemaps = sitemapService.GetSitemaps();
            var defaultSitemap = sitemapService.GetDefaultSitemap();

            var someWidget = defaultSitemap.Homepage.Widgets.FirstOrDefault()?.Widgets.FirstOrDefault();
            var pageId = someWidget?.LinkedPage?.PageId;
            var page = sitemapService.GetPage(defaultSitemap.Name, pageId);

            var subscriptionId = sitemapService.Subscribe().SubscriptionId;

            Console.ReadLine();
        }
    }
}
