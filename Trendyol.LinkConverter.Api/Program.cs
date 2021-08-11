using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Serilog;
using System.Reflection;
using Serilog.Sinks.Elasticsearch;

namespace Trendyol.LinkConverter.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog((context, configuration) =>
            {
                configuration.Enrich.FromLogContext()
                           .Enrich.WithMachineName()
                           .WriteTo.Console()
                           .WriteTo.Elasticsearch(
                                    new ElasticsearchSinkOptions(new Uri(context.Configuration["ElasticConfiguration:Uri"]))
                                    {
                                        IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{context.HostingEnvironment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                                        AutoRegisterTemplate = true
                                    })
                           .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                           .ReadFrom.Configuration(context.Configuration);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
