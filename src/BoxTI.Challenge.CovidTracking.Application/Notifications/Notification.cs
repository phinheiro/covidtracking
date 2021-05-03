using System;

namespace BoxTI.Challenge.CovidTracking.Application.Notifications
{
    public class Notification
    {
        public Notification(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}