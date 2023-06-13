using Microsoft.Extensions.DependencyInjection;
using YourLocalization.Domain.Interface;
using YourLocalization.Infrastructure.Repositoriees;
using YourLocalization.Infrastructure.Repositories;

namespace YourLocalization.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IPointRepository, PointRepository>();
            services.AddTransient<ITypeRepository, TypeRepository>();
            return services;
        }
    }
}