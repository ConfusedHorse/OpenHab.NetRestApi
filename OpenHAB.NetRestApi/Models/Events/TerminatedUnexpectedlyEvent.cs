using System;

namespace OpenHAB.NetRestApi.Models.Events
{
    public delegate void TerminatedUnexpectedlyEventHandler(object sender, TerminatedUnexpectedlyEvent eventObject);

    public class TerminatedUnexpectedlyEvent : EventArgs
    {
        public TerminatedUnexpectedlyEvent(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; }
    }
}