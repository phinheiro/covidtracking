using System.Linq;
using BoxTI.Challenge.CovidTracking.Application.Notifications;
using BoxTI.Challenge.CovidTracking.Application.Notifications.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BoxTI.Challenge.CovidTracking.API.Controllers.Base
{
    [ApiController]
    public class MainController : ControllerBase
    {
        protected readonly INotifier _notifier;
        protected MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool ValidOperation() => !_notifier.HasNotification();

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!ModelState.IsValid)
                NotifyInvalidModelErrors(modelState);

            return CustomResponse();
        }

        protected void NotifyInvalidModelErrors(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected void NotifyError(string message) => _notifier.Handle(new Notification(message));
    }
}