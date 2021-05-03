using System.Collections.Generic;
using System.Linq;
using BoxTI.Challenge.CovidTracking.Application.Notifications.Interfaces;

namespace BoxTI.Challenge.CovidTracking.Application.Notifications
{
    public class Notifier : INotifier
    {
        private readonly List<Notification> _notifications;
        public Notifier()
        {
            _notifications = new List<Notification>();
        }
        public List<Notification> GetNotifications() => _notifications;

        public void Handle(Notification notification) => _notifications.Add(notification);

        public bool HasNotification() => _notifications.Any();
    }
}