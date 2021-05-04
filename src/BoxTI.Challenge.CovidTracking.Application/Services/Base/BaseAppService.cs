using BoxTI.Challenge.CovidTracking.Application.Notifications;
using BoxTI.Challenge.CovidTracking.Application.Notifications.Interfaces;
using BoxTI.Challenge.CovidTracking.Core.Entities;
using FluentValidation;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.Application.Services.Base
{
    public abstract class BaseAppService
    {
        protected readonly INotifier _notifier;
        protected BaseAppService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                Notify(error.ErrorMessage);
        }

        protected void Notify(string message) => _notifier.Handle(new Notification(message));

        protected void Notify(string message, params object[] parameters) =>
            _notifier.Handle(new Notification(string.Format(message, parameters)));

        protected async Task<bool> ExecuteValidationAsync<TV, TE>(TV validation, TE entity)
            where TV : AbstractValidator<TE>
            where TE : Entity
        {
            var validator = await validation.ValidateAsync(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
