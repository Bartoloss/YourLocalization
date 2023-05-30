using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.Services;

namespace YourLocalization.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}