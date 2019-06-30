using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Tehk.Events.Svc.Models;
using Tehk.Events.Svc.Services;

namespace Tehk.Events.Svc
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
            services.AddSingleton<IEventsService, EventsService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            ConnectDatabase(services);
        }

        public const string DbConnectionStringConfigId = "DB:ConnectionString";
        public const string DbDatabaseConfigId = "DB:Database";
        public const string EventsCollection = "events";

        private void ConnectDatabase(IServiceCollection services)
        {
            string connectionString = Configuration[DbConnectionStringConfigId];
            if (connectionString == null)
            {
                Logger.LogCritical(
                    $"Undefined database connection string; configuration ID '{DbConnectionStringConfigId}'.");
                throw new ApplicationException("Missing required configuration.");
            }

            string dbName = Configuration[DbDatabaseConfigId];
            if (dbName == null)
            {
                Logger.LogCritical($"Undefined database name; configuration ID '{DbDatabaseConfigId}'.");
                throw new ApplicationException("Missing required configuration.");
            }

            Logger.LogInformation("Connecting to database.");
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("Camel Case", conventionPack, t => true);
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);

            services.AddSingleton<IMongoCollection<EventModel>>(db.GetCollection<EventModel>(EventsCollection));
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
