using System.Collections.Generic;

namespace BoxTI.Challenge.CovidTracking.Application.Notifications.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}