using Microsoft.Extensions.DependencyInjection;
using School.Domain.IGenericRepository_IUOW;
using School.Infrastructure.GenericRepository_UOW;
using School.Services.Abstracts;
using School.Services.Implementaions;

namespace School.Services.Extentions
{
    public static class ServicesExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IStudentService, StudentService>();

            return services;
        }
    }
}
