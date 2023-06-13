using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.Services;
using YourLocalization.Application.ViewModels.Point;
using YourLocalization.Application.ViewModels.Type;
using YourLocalization.Application.ViewModels.User;

namespace YourLocalization.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IPointService, PointService>();
            services.AddTransient<ITypeService, TypeService>();

            services.AddTransient<IValidator<NewUserVm>, NewUserValidation>();
            services.AddTransient<IValidator<NewPointVm>, NewPointValidation>();
            services.AddTransient <IValidator<NewTypeVm>, NewTypeValidation>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}