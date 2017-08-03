using System;
using System.Collections.Generic;
using System.Diagnostics;
using OpenHAB.NetRestApi.Models;
using OpenHAB.NetRestApi.RestApi;

namespace OpenHAB.NetRestApi.Client
{
    /// <summary>
    /// THIS IS A TEST ENVIRONMENT (can be ignored)
    /// </summary>
    class Program
    {
        //private const string Url = "http://localhost:8080/rest";
        private const string Url = "http://192.168.2.111:8080/rest";
        private const bool StartEventService = true;

        static void Main(string[] args)
        {
            var openHab = OpenHab.CreateRestClient(Url, StartEventService);
            var itemService = openHab.ItemService;

            var types = itemService.GetTypes();
            var type = types[4];
            var itemsOfType = itemService.GetItems(string.Empty, "testTag", true);

            Debug.WriteLine("\r\nCurrent tags:");
            PostItemTags(itemsOfType);

            Debug.WriteLine("\r\nAdding tags to items.");
            foreach (var item in itemsOfType)
            {
                itemService.AddItemTag(item, "testTag1");
                itemService.AddItemTag(item, "testTag2");
            }

            itemsOfType = itemService.GetItems(type);
            Debug.WriteLine("\r\n\nCurrent tags:");
            PostItemTags(itemsOfType);

            Debug.WriteLine("\r\nRemoving tags from items.");
            foreach (var item in itemsOfType)
            {
                itemService.RemoveItemTag(item, "testTag1");
                itemService.RemoveItemTag(item, "testTag2");
            }

            itemsOfType = itemService.GetItems(type);
            Debug.WriteLine("\r\n\nCurrent tags:");
            PostItemTags(itemsOfType);

            Console.ReadLine();
        }

        private static void PostItemTags(IEnumerable<Item> itemsOfType)
        {
            foreach (var item in itemsOfType)
            {
                Debug.WriteLine($"{item.Name}:\t\t\t{string.Join(", ", item.Tags)}");
            }
        }
    }
}
