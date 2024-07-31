using ExaminantionSystem.API.Data;
using ExaminantionSystem.API.Mapping;
using ExaminantionSystem.API.Repositories;
using ExaminantionSystem.API.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExaminantionSystem.API.Extensions
{
    public static class DependencyInjectionServices
    {
       public static IServiceCollection AddDependencyInjectionServicesConfig(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });




                  services.AddAutoMapper(typeof(ProfileMapping));
     

            //FluentValidation
                 services.AddFluentValidationConfigration();

            return services;
        }


        private static IServiceCollection AddFluentValidationConfigration(this IServiceCollection services)
        {

            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }






    }
}
