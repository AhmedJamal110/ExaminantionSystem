
using ExaminantionSystem.API.Data;
using ExaminantionSystem.API.Entities;
using ExaminantionSystem.API.Extensions;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExaminantionSystem.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerDocumentationServicesCofig();
            builder.Services.AddDependencyInjectionServicesConfig(builder.Configuration);
            builder.Services.AddIdentityServicesConfigration(builder.Configuration);



            var app = builder.Build();

            using var scoped = app.Services.CreateScope();
            var servicesProvader = scoped.ServiceProvider;
            var LoogerFactory = servicesProvader.GetRequiredService<ILoggerFactory>();



            // ask clr to mogration and update database
            try
            {
                var dbcontext = servicesProvader.GetRequiredService<ApplicationDbContext>();
                await dbcontext.Database.MigrateAsync();

                var userManger = servicesProvader.GetRequiredService<UserManager<AppUser>>();
                var roleManager = servicesProvader.GetRequiredService<RoleManager<IdentityRole>>();
                await ApplicationDbContextSeeding.SeedingDatabaseAsync(roleManager, userManger);

            }
            catch (Exception ex)
            {
                var loger = LoogerFactory.CreateLogger<Program>();
                loger.LogError(ex, "An Error Occure in migration or seeding data");

            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
