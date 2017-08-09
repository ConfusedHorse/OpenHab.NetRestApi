using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenHAB.NetRestApi.Helpers;
using OpenHAB.NetRestApi.Models.Events;
using OpenHAB.NetRestApi.RestApi;

namespace OpenHAB.NetRestApi.Services
{
    public class EventService
    {
        private bool _abortionRequested;

        /// <summary>
        ///     Initializes an asynchronous Rest prompt which is read and interpreted.
        ///     Results can be aquired by listening to the relevant event
        /// </summary>
        public async void InitializeAsync()
        {
            _abortionRequested = false;
            await Task.Run(() =>
            {
                // asynchronous stream reader
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                    var requestUri = $"{OpenHab.RestClient.Url}/events";
                    var stream = httpClient.GetStreamAsync(requestUri).Result;

                    using (var reader = new StreamReader(stream))
                    {
                        var dataTemplate = new Regex(@"data:\s({.*})");
                        while (!reader.EndOfStream)
                        {
                            if (_abortionRequested) break;

                            var currentLine = reader.ReadLine();
                            if (currentLine == null) continue;

                            var data = dataTemplate.Match(currentLine).Groups[1];
                            if (!data.Success) continue;

                            RaiseEvent(data.Value);
                        }
                    }
                }
            });
        }

        public void TerminateAsync()
        {
            _abortionRequested = true;
        }

        private void RaiseEvent(string data)
        {
            var typeTemplate = new Regex(@",""type"":""(.*)""}");

            var json = Json.Fix(data);
            var type = typeTemplate.Match(data).Groups[1].Value;

            switch (type) //TODO this is not a complete list of events
            {
                #region Items

                case "ItemStateEvent":
                    var itemStateEvent = AssembleEvent<ItemStateEvent>(json);
                    ItemStateEventOccured?.Invoke(OpenHab.RestClient, itemStateEvent);
                    break;
                case "ItemStateChangedEvent":
                    var itemStateChangedEvent = AssembleEvent<ItemStateChangedEvent>(json);
                    ItemStateChanged?.Invoke(OpenHab.RestClient, itemStateChangedEvent);
                    break;
                case "ItemCommandEvent":
                    var itemCommandEvent = AssembleEvent<ItemCommandEvent>(json);
                    ItemCommandEventOccured?.Invoke(OpenHab.RestClient, itemCommandEvent);
                    break;
                case "ItemAddedEvent":
                    var itemAddedEvent = AssembleEvent<ItemAddedEvent>(json);
                    ItemAdded?.Invoke(OpenHab.RestClient, itemAddedEvent);
                    break;
                case "ItemRemovedEvent":
                    var itemRemovedEvent = AssembleEvent<ItemRemovedEvent>(json);
                    ItemRemoved?.Invoke(OpenHab.RestClient, itemRemovedEvent);
                    break;
                case "ItemUpdatedEvent":
                    var itemUpdatedEvent = AssembleEvent<ItemUpdatedEvent>(json);
                    ItemUpdated?.Invoke(OpenHab.RestClient, itemUpdatedEvent);
                    break;
                case "ItemChannelLinkAddedEvent":
                    var itemChannelLinkAddedEvent = AssembleEvent<ItemChannelLinkAddedEvent>(json);
                    ItemChannelLinkAdded?.Invoke(OpenHab.RestClient, itemChannelLinkAddedEvent);
                    break;
                case "ItemChannelLinkRemovedEvent":
                    var itemChannelLinkRemovedEvent = AssembleEvent<ItemChannelLinkRemovedEvent>(json);
                    ItemChannelLinkRemoved?.Invoke(OpenHab.RestClient, itemChannelLinkRemovedEvent);
                    break;

                #endregion

                #region Things

                case "ThingStatusInfoEvent":
                    var thingStatusInfoEvent = AssembleEvent<ThingStatusInfoEvent>(json);
                    ThingStatusInfoEventOccured?.Invoke(OpenHab.RestClient, thingStatusInfoEvent);
                    break;
                case "ThingStatusInfoChangedEvent":
                    var thingStatusInfoChangedEvent = AssembleEvent<ThingStatusInfoChangedEvent>(json);
                    ThingStatusInfoChanged?.Invoke(OpenHab.RestClient, thingStatusInfoChangedEvent);
                    break;
                case "ThingAddedEvent":
                    var thingAddedEvent = AssembleEvent<ThingAddedEvent>(json);
                    ThingAdded?.Invoke(OpenHab.RestClient, thingAddedEvent);
                    break;
                case "ThingUpdatedEvent":
                    var thingUpdatedEvent = AssembleEvent<ThingUpdatedEvent>(json);
                    ThingUpdated?.Invoke(OpenHab.RestClient, thingUpdatedEvent);
                    break;
                case "ThingRemovedEvent":
                    var thingRemovedEvent = AssembleEvent<ThingRemovedEvent>(json);
                    ThingRemoved?.Invoke(OpenHab.RestClient, thingRemovedEvent);
                    break;

                #endregion

                #region Inbox

                case "InboxAddedEvent":
                    var inboxAddedEvent = AssembleEvent<InboxAddedEvent>(json);
                    InboxAdded?.Invoke(OpenHab.RestClient, inboxAddedEvent);
                    break;
                case "InboxRemovedEvent":
                    var inboxRemovedEvent = AssembleEvent<InboxRemovedEvent>(json);
                    InboxRemoved?.Invoke(OpenHab.RestClient, inboxRemovedEvent);
                    break;

                #endregion

                #region Rules

                case "RuleStatusInfoEvent":
                    var ruleStatusInfo = AssembleEvent<RuleStatusInfoEvent>(json);
                    RuleStatusInfoEventOccured?.Invoke(OpenHab.RestClient, ruleStatusInfo);
                    break;
                case "RuleAddedEvent":
                    var ruleAddedEvent = AssembleEvent<RuleAddedEvent>(json);
                    RuleAdded?.Invoke(OpenHab.RestClient, ruleAddedEvent);
                    break;
                case "RuleUpdatedEvent":
                    var ruleUpdatedEvent = AssembleEvent<RuleUpdatedEvent>(json);
                    RuleUpdated?.Invoke(OpenHab.RestClient, ruleUpdatedEvent);
                    break;
                case "RuleRemovedEvent":
                    var ruleRemovedEvent = AssembleEvent<RuleRemovedEvent>(json);
                    RuleRemoved?.Invoke(OpenHab.RestClient, ruleRemovedEvent);
                    break;

                #endregion

                #region Miscellaneous

                case "ConfigStatusInfoEvent":
                    var configStatusInfoEvent = AssembleEvent<ConfigStatusInfoEvent>(json);
                    ConfigStatusInfoEventOccured?.Invoke(OpenHab.RestClient, configStatusInfoEvent);
                    break;
                case "PlayURLEvent":
                    var playUrlEvent = AssembleEvent<PlayUrlEvent>(json);
                    PlayUrlEventOccured?.Invoke(OpenHab.RestClient, playUrlEvent);
                    break;
                default:
                    var unknownEvent = AssembleEvent<UnknownEvent>(json);
                    UnknownEventOccured?.Invoke(OpenHab.RestClient, unknownEvent);
                    break;

                #endregion
            }
        }

        private static T AssembleEvent<T>(string json)
        {
            var timeOccured = DateTime.Now;
            var targetTemplate = new Regex(@"smarthome/(.*)/(.*)/(.*)"); // group/target/action

            dynamic eventObject = JsonConvert.DeserializeObject<T>(json);
            eventObject.Target = targetTemplate.Match(eventObject.Topic).Groups[2].Value;
            eventObject.Action = targetTemplate.Match(eventObject.Topic).Groups[3].Value;
            eventObject.Occured = timeOccured;
            return eventObject;
        }

        #region EventHandlers

        public event ItemStateEventHandler ItemStateEventOccured;
        public event ItemStateChangedEventHandler ItemStateChanged;
        public event ItemCommandEventHandler ItemCommandEventOccured;
        public event ItemAddedEventHandler ItemAdded;
        public event ItemRemovedEventHandler ItemRemoved;
        public event ItemUpdatedEventHandler ItemUpdated;
        public event ItemChannelLinkAddedEventHandler ItemChannelLinkAdded;
        public event ItemChannelLinkRemovedEventHandler ItemChannelLinkRemoved;

        public event ThingStatusInfoEventHandler ThingStatusInfoEventOccured;
        public event ThingStatusInfoChangedEventHandler ThingStatusInfoChanged;
        public event ThingAddedEventHandler ThingAdded;
        public event ThingUpdatedEventHandler ThingUpdated;
        public event ThingRemovedEventHandler ThingRemoved;

        public event InboxAddedEventHandler InboxAdded;
        public event InboxRemovedEventHandler InboxRemoved;

        public event RuleStatusInfoEventHandler RuleStatusInfoEventOccured;
        public event RuleAddedEventHandler RuleAdded;
        public event RuleUpdatedEventHandler RuleUpdated;
        public event RuleRemovedEventHandler RuleRemoved;

        public event ConfigStatusInfoEventHandler ConfigStatusInfoEventOccured;
        public event PlayUrlEventHandler PlayUrlEventOccured;
        public event UnknownEventHandler UnknownEventOccured;

        #endregion
    }
}