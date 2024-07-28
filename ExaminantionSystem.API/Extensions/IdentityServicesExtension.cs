using ExaminantionSystem.API.Data;
using ExaminantionSystem.API.Entities;
using ExaminantionSystem.API.JwtService;
using ExaminantionSystem.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ExaminantionSystem.API.Extensions
{
    public static class IdentityServicesExtension
    {
        public static IServiceCollection AddIdentityServicesConfigration(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtProvider, JwtProvider>();

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:key"])),
                        ValidateIssuer = true,
                        ValidIssuer = configuration["Token:ValidIssuer"],
                        ValidateAudience = true,
                        ValidAudience = configuration["Token:ValidAudiance"],
                        ValidateLifetime = true,
                    };
                });


            return services;
        }
    }
}
