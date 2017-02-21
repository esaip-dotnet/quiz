using api_core.net.Daos;
using api_core.net.Models;
using api_core.net.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace api_core.net
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            BaseDao.UrlMongo = Environment.GetEnvironmentVariable("MONGO_URL_PORT");
            BaseDao.DatabaseMongo = Environment.GetEnvironmentVariable("MONGO_DATABASE");
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Enable CORS 
            services.AddCors(options =>
            {
                // Add the right domains
                options.AddPolicy("Swagger",
                    builder => builder.WithOrigins("http://swagger.io")
                    .AllowAnyHeader());
                options.AddPolicy("SwaggerEditor",
                    builder => builder.WithOrigins("http://editor.swagger.io")
                    .AllowAnyHeader());
            });
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddTransient<QuizDao>();
            services.AddTransient<ParticipationDao>();
            // Add JsonConverter for ObjectId
            services.AddMvc().AddJsonOptions(opt => { opt.SerializerSettings.Converters.Add(new ObjectIdConverter()); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            // Add swagger domain to CORS   
            app.UseCors("Swagger");
            app.UseCors("SwaggerEditor");


            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
        }
    }
}
