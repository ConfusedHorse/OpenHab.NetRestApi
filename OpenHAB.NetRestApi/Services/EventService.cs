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
        public delegate void EventHandler(object sender, Event eventObject);
        public event EventHandler OpenHabBusEventOccured;

        /// <summary>
        /// Initializes an asynchronous Rest prompt which is read and interpreted.
        /// Results can be aquired by listening to the <see cref="OpenHabBusEventOccured"/> event
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
                        var typeTemplate = new Regex(@",""type"":""(.*)""}");
                        while (!reader.EndOfStream)
                        {
                            var currentLine = reader.ReadLine();
                            if (currentLine == null) continue;

                            var data = dataTemplate.Match(currentLine).Groups[1];
                            if (!data.Success) continue;
                            var timeOccured = DateTime.Now;

                            //adjust json format
                            var formattedJson = JsonHelper.Format(data.Value);

                            var type = typeTemplate.Match(formattedJson).Groups[1].Value;

                            var eventObject = CreateEventObject(formattedJson, type, timeOccured);
                            OpenHabBusEventOccured?.Invoke(OpenHab.RestClient, eventObject);
                        }
                    }
                }
            });
        }

        private static Event CreateEventObject(string fixedData, string type, DateTime timeOccured)
        {
            //TODO this list is incomplete
            var targetTemplate = new Regex(@"smarthome/(.*)/(.*)/");
            Event result;
            switch (type)
            {
                case "ItemStateEvent":
                    result = JsonConvert.DeserializeObject<ItemStateEvent>(fixedData);
                    break;
                case "ItemStateChangedEvent":
                    result = JsonConvert.DeserializeObject<ItemStateChangedEvent>(fixedData);
                    break;
                case "ThingStatusInfoEvent":
                    result = JsonConvert.DeserializeObject<ThingStatusInfoEvent>(fixedData);
                    break;
                case "ItemCommandEvent":
                    result = JsonConvert.DeserializeObject<ItemCommandEvent>(fixedData);
                    break;
                default:
                    result = JsonConvert.DeserializeObject<UnknownEvent>(fixedData);
                    break;
            }

            result.Target = targetTemplate.Match(result.Topic).Groups[2].Value;
            result.Occured = timeOccured;
            return result;
        }
    }
}