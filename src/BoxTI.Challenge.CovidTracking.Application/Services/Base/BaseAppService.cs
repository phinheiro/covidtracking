using BoxTI.Challenge.CovidTracking.Application.Notifications;
using BoxTI.Challenge.CovidTracking.Application.Notifications.Interfaces;

namespace BoxTI.Challenge.CovidTracking.Application.Services.Base
{
    public abstract class BaseAppService
    {
        protected readonly INotifier _notifier;
        protected BaseAppService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(string message) => _notifier.Handle(new Notification(message));

        protected void Notify(string message, params object[] parameters) =>
            _notifier.Handle(new Notification(string.Format(message, parameters)));
    }
}
