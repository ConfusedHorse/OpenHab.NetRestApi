﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;
using RestSharp;

namespace OpenHAB.NetRestApi.Services
{
    public class TemplateService
    {
        public List<Template> GetTemplates()
        {
            return GetTemplatesAsync().Result;
        }
        
        public Task<List<Template>> GetTemplatesAsync(CancellationToken token = default(CancellationToken))
        {
            const string resource = "/templates";
            return OpenHab.RestClient.ExecuteRequestAsync<List<Template>>(Method.GET, resource, token: token);
        }
        
        public Template GetTemplate(string templateUid)
        {
            return GetTemplateAsync(templateUid).Result;
        }
        
        public Task<Template> GetTemplateAsync(string templateUid, CancellationToken token = default(CancellationToken))
        {
            var resource = $"/templates/{templateUid}";
            return OpenHab.RestClient.ExecuteRequestAsync<Template>(Method.GET, resource, token: token);
        }
    }
}