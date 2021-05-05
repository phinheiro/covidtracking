using BoxTI.Challenge.CovidTracking.API.Extensions;
using BoxTI.Challenge.CovidTracking.API.Setups;
using BoxTI.Challenge.CovidTracking.ExternalServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BoxTI.Challenge.CovidTracking.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ApiKeySettings.ApiKey = configuration["ApiKey"];
            CovidTrackingApiSettings.CTApiKey = configuration["CovidTrackingApi:ApiKey"];
            CovidTrackingApiSettings.CTApiHost = configuration["CovidTrackingApi:ApiHost"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDatabases(Configuration);

            services.AddAutoMapperSetup();

            services.AddVersioningSetup();

            services.AddSwaggerSetup();
            
            services.RegisterServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerSetup(provider);
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
