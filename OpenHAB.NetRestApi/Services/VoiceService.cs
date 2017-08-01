using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class VoiceService
    {
        public List<Interpreter> GetInterpreters()
        {
            return GetInterpretersAsync().Result;
        }

        public Task<List<Interpreter>> GetInterpretersAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/voice/interpreters";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Interpreter>>(Method.GET, resource, token: token);
        }

        public Interpreter GetInterpreter(string id)
        {
            return GetInterpreterAsync(id).Result;
        }

        public Task<Interpreter> GetInterpreterAsync(string id, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/voice/interpreters/{id}";
            return OpenHab.RestClient.ExecuteRequestAsync<Interpreter>(Method.GET, resource, token: token);
        }

        public string SendMessage(string message)
        {
            return SendMessageAsync(message).Result.Content;
        }

        public Task<IRestResponse> SendMessageAsync(string message, CancellationToken token = default(CancellationToken))
        {
            const string resource = "/voice/interpreters";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, message, RequestHeader.ContentPlainText & RequestHeader.AcceptPlainText, token);
        }

        public string SendMessage(string id, string message, string locale = null)
        {
            return locale == null
                ? SendMessageAsync(id, message).Result.Content
                : SendMessageAsync(id, message, locale).Result.Content;
        }

        public Task<IRestResponse> SendMessageAsync(string id, string message, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/voice/interpreters/{id}";
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, message, RequestHeader.ContentPlainText & RequestHeader.AcceptPlainText, token);
        }

        public Task<IRestResponse> SendMessageAsync(string id, string message, string locale, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/voice/interpreters/{id}";
            var localeHeader = new RequestHeader("Accept-Language", locale);
            return OpenHab.RestClient.ExecuteRequestAsync(Method.POST, resource, message,
                RequestHeader.ContentPlainText & RequestHeader.AcceptJson & localeHeader, token);
        }
    }
}