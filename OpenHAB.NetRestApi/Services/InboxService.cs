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
        public List<Inbox> GetInbox()
        {
            return GetInboxAsync().Result;
        }
        
        public Task<List<Inbox>> GetInboxAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/inbox";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Inbox>>(Method.GET, resource, token: token);
        }

        public string DeleteInbox(string thingUid)
        {
            return DeleteInboxAsync(thingUid).Result.Content;
        }
        
        public Task<IRestResponse> DeleteInboxAsync(string thingUid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/inbox/{thingUid}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.DELETE, resource, token: token);
        }

        public string AcceptInbox(string thingUid, string label)
        {
            return AcceptInboxAsync(thingUid, label).Result.Content;
        }
        
        public Task<IRestResponse> AcceptInboxAsync(string thingUid, string label, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/inbox/{thingUid}/approve";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, label, RequestHeader.ContentPlainText, token);
        }

        public string IgnoreInbox(string thingUid)
        {
            return IgnoreInboxAsync(thingUid).Result.Content;
        }
        
        public Task<IRestResponse> IgnoreInboxAsync(string thingUid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/inbox/{thingUid}/ignore";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }

        public string UnignoreInbox(string thingUid)
        {
            return UnignoreInboxAsync(thingUid).Result.Content;
        }
        
        public Task<IRestResponse> UnignoreInboxAsync(string thingUid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/inbox/{thingUid}/unignore";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, token: token);
        }
    }
}