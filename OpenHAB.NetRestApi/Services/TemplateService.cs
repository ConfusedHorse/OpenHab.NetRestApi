using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class TemplateService
    {
        /// <summary>
        /// Get all available templates.
        /// </summary>
        /// <returns></returns>
        public List<Template> GetTemplates()
        {
            return GetTemplatesAsync().Result;
        }

        /// <summary>
        /// Get all available templates.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<List<Template>> GetTemplatesAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/templates";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Template>>(Method.GET, resource, token: token);
        }

        /// <summary>
        /// Gets a template corresponding to the given UID.
        /// </summary>
        /// <param name="templateUid"></param>
        /// <returns></returns>
        public Template GetTemplate(string templateUid)
        {
            return GetTemplateAsync(templateUid).Result;
        }

        /// <summary>
        /// Gets a template corresponding to the given UID.
        /// </summary>
        /// <param name="templateUid"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Template> GetTemplateAsync(string templateUid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/templates/{templateUid}";
            return OpenHab.RestClient.ExecuteRequestAsync<Template>(Method.GET, resource, token: token);
        }
    }
}