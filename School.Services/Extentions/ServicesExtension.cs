using Microsoft.Extensions.DependencyInjection;
using School.Domain.IGenericRepository_IUOW;
using School.Infrastructure.GenericRepository_UOW;

namespace School.Services.Extentions
{
    public static class ServicesExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
