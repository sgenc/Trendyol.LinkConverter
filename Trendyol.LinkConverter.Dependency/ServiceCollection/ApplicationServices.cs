using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trendyol.LinkConverter.Caching;
using Trendyol.LinkConverter.Service;
using Trendyol.LinkConverter.Service.Interface;

namespace Trendyol.LinkConverter.Dependency
{
    public static class ApplicationServices
    {
        public static IServiceCollection RegisterterApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUrlConverterService, UrlConverterService>();
            services.AddTransient<IUrlConverterStrategyResolver, UrlConverterStrategyResolver>();

            services.AddSingleton<ICacheService, CacheService>();

            var typesFromAssemblies = Assembly.GetAssembly(typeof(IUrlConverterStrategy)).DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(IUrlConverterStrategy)));

            foreach (var type in typesFromAssemblies)
                services.Add(new ServiceDescriptor(typeof(IUrlConverterStrategy), type, ServiceLifetime.Transient));
         

            return services;
        }
    }
}
