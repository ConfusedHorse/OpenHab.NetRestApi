using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenHAB.NetRestApi.Helpers;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.Services;
using RestSharp;

namespace OpenHAB.NetRestApi.RestApi
{
    public sealed class OpenHabRestClient
    {
        #region Fields

        private string _url;
        private RestClient _restClient;
        
        private BindingService _bindingService;
        private ChannelTypeService _channelTypeService;
        private ConfigDescriptionService _configDescriptionService;
        private DefaultService _defaultService;
        private DiscoveryService _discoveryService;
        private EventService _eventService;
        private ExtensionService _extensionService;
        private InboxService _inboxService;
        private ItemService _itemService;
        private LinkService _linkService;
        private ModuleTypeService _moduleTypeService;
        private PersistenceService _persistenceService;
        private RuleService _ruleService;
        private ServiceService _serviceService;
        private SitemapService _sitemapService;
        private TemplateService _templateService;
        private ThingService _thingService;
        private ThingTypeService _thingTypeService;
        private UuidService _uuidService;
        private VoiceService _voiceService;

        #endregion

        internal OpenHabRestClient(string url)
        {
            Url = url;
            RestClient = new RestClient(url);
        }

        #region Properties

        public string Url
        {
            get => _url;
            set
            {
                _url = value;
                RestClient = new RestClient(value);
            }
        }

        internal RestClient RestClient
        {
            get => _restClient ?? (_restClient = new RestClient(_url));
            set => _restClient = value;
        }

        public BindingService BindingService => _bindingService ?? (_bindingService = new BindingService());
        public ChannelTypeService ChannelTypeService => _channelTypeService ?? (_channelTypeService = new ChannelTypeService());
        public ConfigDescriptionService ConfigDescriptionService => _configDescriptionService ?? (_configDescriptionService = new ConfigDescriptionService());
        public DefaultService DefaultService => _defaultService ?? (_defaultService = new DefaultService());
        public DiscoveryService DiscoveryService => _discoveryService ?? (_discoveryService = new DiscoveryService());
        public EventService EventService => _eventService ?? (_eventService = new EventService());
        public ExtensionService ExtensionService => _extensionService ?? (_extensionService = new ExtensionService());
        public InboxService InboxService => _inboxService ?? (_inboxService = new InboxService());
        public ItemService ItemService => _itemService ?? (_itemService = new ItemService());
        public LinkService LinkService => _linkService ?? (_linkService = new LinkService());
        public ModuleTypeService ModuleTypeService => _moduleTypeService ?? (_moduleTypeService = new ModuleTypeService());
        public PersistenceService PersistenceService => _persistenceService ?? (_persistenceService = new PersistenceService());
        public RuleService RuleService => _ruleService ?? (_ruleService = new RuleService());
        public ServiceService ServiceService => _serviceService ?? (_serviceService = new ServiceService());
        public SitemapService SitemapService => _sitemapService ?? (_sitemapService = new SitemapService());
        public TemplateService TemplateService => _templateService ?? (_templateService = new TemplateService());
        public ThingService ThingService => _thingService ?? (_thingService = new ThingService());
        public ThingTypeService ThingTypeService => _thingTypeService ?? (_thingTypeService = new ThingTypeService());
        public UuidService UuidService => _uuidService ?? (_uuidService = new UuidService());
        public VoiceService VoiceService => _voiceService ?? (_voiceService = new VoiceService());

        #endregion

        public Task<IRestResponse> ExecuteRequestAsync(Method method, string resource, object requestBody = null, 
            RequestHeaderCollection requestHeaders = null, CancellationToken token = default(CancellationToken))
        {
            return Task.Run(() =>
            {
                RestRequest request = GetRequest(method, resource, requestHeaders);
                requestHeaders?.Each<RequestHeader>(rh => request.AddHeader(rh.Name, rh.Value));
                if (requestBody != null) { request.AddBody(requestBody); }
                
                return RestClient.Execute(request);
            }, token);
        }

        private static RestRequest GetRequest(Method method, string resource, RequestHeaderCollection requestHeaders)
        {
            if (requestHeaders != null && requestHeaders.Contains(RequestHeader.ContentPlainText))
            return new RestRequest(resource, method)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new NewtonsoftJsonSerializer(RequestHeader.ContentPlainText.Value)
            };
            return new RestRequest(resource, method)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new NewtonsoftJsonSerializer()
            };
        }

        public Task<T> ExecuteRequestAsync<T>(Method method, string resource, object requestBody = null, 
            RequestHeaderCollection requestHeaders = null, CancellationToken token = default(CancellationToken))
        {
            return Task.Run(() =>
            {
                var task = ExecuteRequestAsync(method, resource, requestBody, requestHeaders, token);
                return JsonConvert.DeserializeObject<T>(task.Result.Content);
            }, token);
        }

        public void ClearCache()
        {
            _bindingService = null;
            _channelTypeService = null;
            _configDescriptionService = null;
            _defaultService = null;
            _discoveryService = null;
            _eventService = null;
            _extensionService = null;
            _inboxService = null;
            _itemService = null;
            _linkService = null;
            _moduleTypeService = null;
            _persistenceService = null;
            _ruleService = null;
            _serviceService = null;
            _sitemapService = null;
            _templateService = null;
            _thingService = null;
            _thingTypeService = null;
            _uuidService = null;
            _voiceService = null;
        }
    }
}