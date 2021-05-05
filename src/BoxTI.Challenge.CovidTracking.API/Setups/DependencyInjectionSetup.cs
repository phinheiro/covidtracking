using System;
using BoxTI.Challenge.CovidTracking.Application.Interfaces;
using BoxTI.Challenge.CovidTracking.Application.Notifications;
using BoxTI.Challenge.CovidTracking.Application.Notifications.Interfaces;
using BoxTI.Challenge.CovidTracking.Application.Services;
using BoxTI.Challenge.CovidTracking.Data;
using BoxTI.Challenge.CovidTracking.Data.Repositories;
using BoxTI.Challenge.CovidTracking.Domain.Interfaces;
using BoxTI.Challenge.CovidTracking.ExternalServices.Interfaces;
using BoxTI.Challenge.CovidTracking.ExternalServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BoxTI.Challenge.CovidTracking.API.Setups
{
    public static class DependencyInjectionSetup
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<CTContext>();

            // Repositories
            services.AddScoped<ICasesRepository, CasesRepository>();

            // Application services
            services.AddScoped<ICasesAppService, CasesAppService>();

            // External services
            services.AddScoped<ICovidTrackingService, CovidTrackingService>();
        }
    }
}