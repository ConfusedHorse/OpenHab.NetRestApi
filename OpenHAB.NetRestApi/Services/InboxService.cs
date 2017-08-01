using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class InboxService
    {
        /// <summary>
        /// Get all discovered things.
        /// </summary>
        /// <returns></returns>
        public List<Inbox> GetInbox()
        {
            return GetInboxAsync().Result;
        }

        /// <summary>
        /// Get all discovered things.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<Inbox>> GetInboxAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/inbox";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Inbox>>(Method.GET, resource, token: token);
        }

        /// <summary>
        /// Removes the discovery result from the inbox.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <returns></returns>
        public string DeleteInbox(string thingUid)
        {
            return DeleteInboxAsync(thingUid).Result.Content;
        }

        /// <summary>
        /// Removes the discovery result from the inbox.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> DeleteInboxAsync(string thingUid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/inbox/{thingUid}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }

        /// <summary>
        /// Approves the discovery result by adding the thing to the registry.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public string AcceptInbox(string thingUid, string label)
        {
            return AcceptInboxAsync(thingUid, label).Result.Content;
        }

        /// <summary>
        /// Approves the discovery result by adding the thing to the registry.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <param name="label"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> AcceptInboxAsync(string thingUid, string label, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/inbox/{thingUid}/approve";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, label, RequestHeader.ContentPlainText, token);
        }

        /// <summary>
        /// Flags a discovery result as ignored for further processing.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <returns></returns>
        public string IgnoreInbox(string thingUid)
        {
            return IgnoreInboxAsync(thingUid).Result.Content;
        }

        /// <summary>
        /// Flags a discovery result as ignored for further processing.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> IgnoreInboxAsync(string thingUid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/inbox/{thingUid}/ignore";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }

        /// <summary>
        /// Removes ignore flag from a discovery result.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <returns></returns>
        public string UnignoreInbox(string thingUid)
        {
            return UnignoreInboxAsync(thingUid).Result.Content;
        }

        /// <summary>
        /// Removes ignore flag from a discovery result.
        /// </summary>
        /// <param name="thingUid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IRestResponse> UnignoreInboxAsync(string thingUid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/inbox/{thingUid}/unignore";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }
    }
}