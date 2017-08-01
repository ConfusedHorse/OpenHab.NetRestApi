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
        #region EventHandlers
        
        public event UnknownEventHandler UnknownEventOccured;
        public event ItemStateEventHandler ItemStateEventOccured;
        public event ItemStateChangedEventHandler ItemStateChanged;
        public event ThingStatusInfoEventHandler ThingStatusInfoEventOccured;
        public event ItemCommandEventHandler ItemCommandEventOccured;

        #endregion

        /// <summary>
        /// Initializes an asynchronous Rest prompt which is read and interpreted.
        /// Results can be aquired by listening to the relevant event
        /// </summary>
        public async void InitializeAsync()
        {
            await Task.Run(() =>
            { // asynchronous stream reader
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

        private void RaiseEvent(string data)
        {
            var typeTemplate = new Regex(@",""type"":""(.*)""}");

            var json = Json.Fix(data);
            var type = typeTemplate.Match(data).Groups[1].Value;

            switch (type)
            {
                case "ItemStateEvent":
                    var itemStateOpenHabEvent = BuildEvent<ItemStateEvent>(json);
                    ItemStateEventOccured?.Invoke(OpenHab.RestClient, itemStateOpenHabEvent);
                    break;
                case "ItemStateChangedEvent":
                    var itemStateChangedEvent = BuildEvent<ItemStateChangedEvent>(json);
                    ItemStateChanged?.Invoke(OpenHab.RestClient, itemStateChangedEvent);
                    break;
                case "ThingStatusInfoEvent":
                    var thingStatusInfoOpenHabEvent = BuildEvent<ThingStatusInfoEvent>(json);
                    ThingStatusInfoEventOccured?.Invoke(OpenHab.RestClient, thingStatusInfoOpenHabEvent);
                    break;
                case "ItemCommandEvent":
                    var itemCommandOpenHabEvent = BuildEvent<ItemCommandEvent>(json);
                    ItemCommandEventOccured?.Invoke(OpenHab.RestClient, itemCommandOpenHabEvent);
                    break;
                default:
                    var unknownEvent = BuildEvent<UnknownEvent>(json);
                    UnknownEventOccured?.Invoke(OpenHab.RestClient, unknownEvent);
                    break;
            }
        }

        private static T BuildEvent<T>(string json)
        {
            var timeOccured = DateTime.Now;
            var targetTemplate = new Regex(@"smarthome/(.*)/(.*)/");

            dynamic eventObject = JsonConvert.DeserializeObject<T>(json);
            eventObject.Target = targetTemplate.Match(eventObject.Topic).Groups[2].Value;
            eventObject.Occured = timeOccured;
            return eventObject;
        }
    }
}