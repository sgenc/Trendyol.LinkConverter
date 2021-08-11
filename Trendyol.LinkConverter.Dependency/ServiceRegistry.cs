using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Trendyol.LinkConverter.Dependency
{
    public class ServiceRegistry
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterterApplicationServices();
        }
    }
}
