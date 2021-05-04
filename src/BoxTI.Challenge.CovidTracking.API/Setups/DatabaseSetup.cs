using System;
using BoxTI.Challenge.CovidTracking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BoxTI.Challenge.CovidTracking.API.Setups
{
    public static class DatabaseSetup
    {
        public static void AddDatabases(this IServiceCollection services, IConfiguration configuration){
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<CTContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));
        }
    }
}