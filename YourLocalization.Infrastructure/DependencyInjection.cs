using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Domain.Interface;
using YourLocalization.Infrastructure.Repositoriees;
using YourLocalization.Infrastructure.Repositories;

namespace YourLocalization.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure( this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPointRepository, PointRepository>();
            return services;
        }
    }
}
