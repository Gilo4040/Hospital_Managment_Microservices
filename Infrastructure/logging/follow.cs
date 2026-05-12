
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logging
{
    public  class follow
    {
        public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogger =  (host , logger) =>
        {
            var context = host.HostingEnvironment;
            logger.MinimumLevel.Information().
            Enrich.FromLogContext().Enrich.WithProperty("applicationName", context.ApplicationName)
            .Enrich.WithProperty("TypeofService", context.EnvironmentName)
             .Enrich.WithExceptionDetails().MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
               .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information).WriteTo.Console();
            if (context.IsDevelopment())
            {
                logger.MinimumLevel.Override("Patient", LogEventLevel.Debug);
                logger.MinimumLevel.Override("doctor", LogEventLevel.Debug);
                logger.MinimumLevel.Override("Appointment", LogEventLevel.Debug);

            }
             var connection=   host.Configuration.GetValue<string>("ElasticConfiguration:Uri");
            if (connection != null)
            {
                logger.WriteTo.Elasticsearch(
                new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new Uri(connection))
                {
                   AutoRegisterTemplate = true,
                   AutoRegisterTemplateVersion = Serilog.Sinks.Elasticsearch.AutoRegisterTemplateVersion.ESv8,
                   IndexFormat = "NeweHospital-logs-{0:yyyy.MM.dd}",
                   MinimumLogEventLevel = Serilog.Events.LogEventLevel.Debug
               });


            }







        };

    }
}
