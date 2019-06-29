using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Tehk.Sourcers.Eventbrite.Svc.Services;

namespace Tehk.Sourcers.Eventbrite.Svc
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            Logger = logger;
        }

        public IConfiguration Configuration { get; }
        public ILogger<Startup> Logger { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Retrieve on startup.
            string apiToken = GetApiToken();

            services.AddHttpClient<IEventbriteApiClient, EventbriteApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://www.eventbriteapi.com/v3/");
                client.Timeout = TimeSpan.FromSeconds(30);
                client.DefaultRequestHeaders.TryAddWithoutValidation(
                    HeaderNames.Authorization, $"Bearer {apiToken}");
            });
            services.AddSingleton<IEventbriteSourcer, EventbriteSourcer>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        private const string ApiTokenConfigId = "Eventbrite:Api:Token";

        private string GetApiToken()
        {
            string apiToken = Configuration[ApiTokenConfigId];
            if (string.IsNullOrEmpty(apiToken))
            {
                Logger.LogCritical(
                    $"Undefined API token; configuration ID '{ApiTokenConfigId}'.");
                throw new ApplicationException("Missing required configuration.");
            }
            return apiToken;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
