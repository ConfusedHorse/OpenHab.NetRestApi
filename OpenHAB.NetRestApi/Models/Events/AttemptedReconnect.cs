using System;
using OpenHAB.NetRestApi.Services;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void AttemptedReconnectEventHandler(EventService sender, AttemptedReconnectEvent eventObject);

    public class AttemptedReconnectEvent : EventArgs
    {
        public AttemptedReconnectEvent(int count)
        {
            Count = count;
        }

        public int Count { get; }
    }
}