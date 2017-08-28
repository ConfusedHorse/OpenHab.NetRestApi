using System;
using System.Diagnostics;
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
        #region Fields

        private bool _abortionRequested;
        private DateTime? _firstReconnectAttempt = null;
        private int _attempts = 0;

        #endregion

        ~EventService()
        {
            TerminateAsync();
        }

        #region Properties

        public bool OngoingInitialisation { get; set; }

        public bool IsInitialized { get; set; }

        public bool AutoReconnect { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Initializes an asynchronous Rest prompt which is read and interpreted.
        ///     Results can be aquired by listening to the relevant event
        /// </summary>
        public async void InitializeAsync(bool autoreconnect = true)
        {
            _abortionRequested = false;
            AutoReconnect = autoreconnect;

            if (IsInitialized || OngoingInitialisation) return;
            OngoingInitialisation = true;

            Debug.WriteLine("Initialize Event Listener...");
            await Task.Run(() =>
            {
                // asynchronous stream reader
                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
                    var requestUri = $"{OpenHab.RestClient.Url}/events";
                    try
                    {
                        var stream = httpClient.GetStreamAsync(requestUri).Result;

                        using (var reader = new StreamReader(stream))
                        {
                            IsInitialized = true;
                            AttemptedReconnect?.Invoke(this, new AttemptedReconnectEvent(-1));
                            Debug.WriteLine("Event Listener initialized.");

                            var dataTemplate = new Regex(@"data:\s({.*})");
                            while (!_abortionRequested)
                            {
                                try
                                {
                                    if (reader.EndOfStream)
                                    {
                                        TerminateAsync();
                                        break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    UnexpectedTermination(e);
                                    break;
                                }

                                if (_abortionRequested) break;

                                var currentLine = reader.ReadLine();
                                if (currentLine == null) continue;

                                var data = dataTemplate.Match(currentLine).Groups[1];
                                if (!data.Success) continue;

                                RaiseEvent(data.Value);
                            }
                        }
                    }
                    catch (AggregateException e)
                    {
                        UnexpectedTermination(e);
                    }
                }
                Debug.WriteLine("Event Listener terminated.");
            });
        }

        internal void UnexpectedTermination(Exception exception)
        {
            TerminateAsync();
            OngoingInitialisation = false;

            if (AutoReconnect)
            {
                Debug.WriteLine($"{exception.GetType()} occured.");
                if (_firstReconnectAttempt == null) _firstReconnectAttempt = DateTime.Now;
                if (((DateTime)_firstReconnectAttempt).AddMinutes(1) < DateTime.Now)
                {
                    _abortionRequested = false;
                    _attempts = 0;
                    _firstReconnectAttempt = null;

                    Debug.WriteLine("Attempting to reconnect...");
                    AttemptedReconnect?.Invoke(this, new AttemptedReconnectEvent(_attempts));
                    InitializeAsync();
                }
                else //recently attempted to reconnect
                {
                    _attempts++;
                    Debug.WriteLine($"Attempting to reconnect... {_attempts}");
                    AttemptedReconnect?.Invoke(this, new AttemptedReconnectEvent(_attempts));

                    if (_attempts >= 3)
                    {
                        _abortionRequested = true;
                        _attempts = 0;
                        _firstReconnectAttempt = null;

                        Debug.WriteLine($"Too many reconnection attempts ({_attempts})");
                        Debug.WriteLine($"Event subscription will be terminated. ({_attempts})");
                        TerminatedUnexpectedly?.Invoke(this, new TerminatedUnexpectedlyEvent(exception));
                        Debug.WriteLine("New initialisation required.");
                    }
                    else
                    {
                        InitializeAsync();
                    }
                }
            }
            else
            {
                Debug.WriteLine($"Event subscription will be terminated. ({_attempts})");
                TerminatedUnexpectedly?.Invoke(this, new TerminatedUnexpectedlyEvent(exception));
                AutoReconnect = false;
                Debug.WriteLine("New initialisation required.");
            }
        }

        public void TerminateAsync()
        {
            IsInitialized = false;
            _abortionRequested = true;
        }

        #endregion

        #region EventHandlers

        public event TerminatedUnexpectedlyEventHandler TerminatedUnexpectedly;
        public event AttemptedReconnectEventHandler AttemptedReconnect;

        public event ItemStateEventHandler ItemStateEventOccured;
        public event ItemStateChangedEventHandler ItemStateChanged;
        public event ItemCommandEventHandler ItemCommandEventOccured;
        public event ItemAddedEventHandler ItemAdded;
        public event ItemRemovedEventHandler ItemRemoved;
        public event ItemUpdatedEventHandler ItemUpdated;

        public event ThingStatusInfoEventHandler ThingStatusInfoEventOccured;
        public event ThingStatusInfoChangedEventHandler ThingStatusInfoChanged;
        public event ThingAddedEventHandler ThingAdded;
        public event ThingUpdatedEventHandler ThingUpdated;
        public event ThingRemovedEventHandler ThingRemoved;
        public event ItemChannelLinkAddedEventHandler ItemChannelLinkAdded;
        public event ItemChannelLinkRemovedEventHandler ItemChannelLinkRemoved;

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

        #region Private Methods

        private void RaiseEvent(string data)
        {
            var typeTemplate = new Regex(@",""type"":""(.*?)""}");

            var json = Json.Fix(data);
            var type = typeTemplate.Match(data).Groups[1].Value;
            //Debug.WriteLine($"{type} occured.");

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
                case "ItemChannelLinkAddedEvent":
                    var itemChannelLinkAddedEvent = AssembleEvent<ItemChannelLinkAddedEvent>(json);
                    ItemChannelLinkAdded?.Invoke(OpenHab.RestClient, itemChannelLinkAddedEvent);
                    break;
                case "ItemChannelLinkRemovedEvent":
                    var itemChannelLinkRemovedEvent = AssembleEvent<ItemChannelLinkRemovedEvent>(json);
                    ItemChannelLinkRemoved?.Invoke(OpenHab.RestClient, itemChannelLinkRemovedEvent);
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
            var topicTemplate = new Regex(@"smarthome/(.*?)/(.*?)/(.*)"); // group/target/action

            dynamic eventObject = JsonConvert.DeserializeObject<T>(json.Replace(@"\\", @"\"));
            eventObject.Target = topicTemplate.Match(eventObject.Topic).Groups[2].Value;
            eventObject.Action = topicTemplate.Match(eventObject.Topic).Groups[3].Value;
            eventObject.Occured = timeOccured;
            return eventObject;
        }

        #endregion
    }
}