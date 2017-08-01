using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class UuidService
    {
        /// <summary>
        /// A unified unique id.
        /// </summary>
        /// <returns></returns>
        public string GetUuid()
        {
            const string resource = "/uuid";
            var result = OpenHab.RestClient.ExecuteRequestAsync(Method.GET, resource, requestHeaders: RequestHeader.AcceptPlainText).Result;
            return result.Content;
        }
    }
}