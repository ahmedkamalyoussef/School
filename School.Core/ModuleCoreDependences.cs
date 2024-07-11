using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace School.Core
{
    public static class ModuleCoreDependences
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
