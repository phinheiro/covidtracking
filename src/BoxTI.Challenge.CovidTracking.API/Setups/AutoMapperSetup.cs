using BoxTI.Challenge.CovidTracking.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BoxTI.Challenge.CovidTracking.API.Setups
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMapping), typeof(ViewModelToDomainMapping));

        }
    }
}