using Microsoft.Extensions.DependencyInjection;
using Test.Domain.Interfaces.Repositories;
using Test.Domain.Interfaces.Services;
using Test.Domain.Service;
using Test.Infra.Repository;

namespace Test.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IClassificationRepository, ClassificationRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        }
    }
}
