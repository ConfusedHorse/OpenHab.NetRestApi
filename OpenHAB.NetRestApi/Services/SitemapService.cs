using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Constants;
using OpenHAB.NetRestApi.Helpers;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class SitemapService
    {
        /// <summary>
        /// Get all available sitemaps.
        /// </summary>
        /// <returns></returns>
        public List<Sitemap> GetSitemaps()
        {
            return GetSitemapsAsync().Result;
        }

        /// <summary>
        /// Get all available sitemaps.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<Sitemap>> GetSitemapsAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/sitemaps";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Sitemap>>(Method.GET, resource, token: token);
        }

        /// <summary>
        /// Get sitemap by name.
        /// </summary>
        /// <param name="sitemapName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Sitemap GetSitemap(string sitemapName, string type = default(string))
        {
            return GetSitemapAsync(sitemapName, type).Result;
        }

        /// <summary>
        /// Get sitemap by name.
        /// </summary>
        /// <param name="sitemapName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Sitemap GetSitemap(string sitemapName, WidgetType type)
        {
            return GetSitemapAsync(sitemapName, type.ToString()).Result;
        }

        /// <summary>
        /// Get the default sitemap.
        /// </summary>
        /// <returns></returns>
        public Sitemap GetDefaultSitemap()
        {
            return GetSitemapAsync("_default").Result;
        }

        /// <summary>
        /// Get sitemap by name.
        /// </summary>
        /// <param name="sitemapName"></param>
        /// <param name="type"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Sitemap> GetSitemapAsync(string sitemapName, string type = default(string), CancellationToken token = default(CancellationToken))
        {
            var typeParameter = !string.IsNullOrWhiteSpace(type) ? new ResourceParameter("type", type) : null;
            var jsonParameter = new ResourceParameter("jsoncallback", "callback");

            var parameters = Resource.FormatParameters(typeParameter, jsonParameter);
            var resource = $"/sitemaps/{sitemapName}{parameters}";
            return OpenHab.RestClient.ExecuteRequestAsync<Sitemap>(Method.GET, resource, token: token);
        }

        /// <summary>
        /// Polls the data for a sitemap.
        /// </summary>
        /// <param name="sitemapName"></param>
        /// <param name="pageId"></param>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public Page GetPage(string sitemapName, string pageId, string subscriptionId = default(string))
        {
            return GetPageAsync(sitemapName, pageId, subscriptionId).Result;
        }

        /// <summary>
        /// Polls the data for a sitemap.
        /// </summary>
        /// <param name="sitemapName"></param>
        /// <param name="pageId"></param>
        /// <param name="subscriptionId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Page> GetPageAsync(string sitemapName, string pageId, string subscriptionId = default(string), CancellationToken token = default(CancellationToken))
        {
            var subsciptionParameter = !string.IsNullOrWhiteSpace(subscriptionId) ? new ResourceParameter("subscriptionid", subscriptionId) : null;

            var parameters = Resource.FormatParameters(subsciptionParameter);
            var resource = $"/sitemaps/{sitemapName}/{pageId}{parameters}";
            return OpenHab.RestClient.ExecuteRequestAsync<Page>(Method.GET, resource, token: token);
        }

        //TODO subscribing to events does not work yet.
        //GET /sitemaps/events/{subscriptionid}

        /// <summary>
        /// Creates a sitemap event subscription.
        /// </summary>
        /// <returns></returns>
        public Subscription Subscribe()
        {
            return SubscribeAsync().Result;
        }

        /// <summary>
        /// Creates a sitemap event subscription.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Subscription> SubscribeAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/sitemaps/events/subscribe";
            return OpenHab.RestClient.ExecuteRequestAsync<Subscription>(Method.POST, resource, token: token);
        }
    }
}