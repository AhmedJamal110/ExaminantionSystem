using ExaminantionSystem.API.Constant;
using ExaminantionSystem.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ExaminantionSystem.API.Data
{
    public class ApplicationDbContextSeeding
    {
        public static async Task SeedingDatabaseAsync(RoleManager<IdentityRole> _roleManager, UserManager<AppUser> _userManager)
        {
            if ( ! _roleManager.Roles.AnyAsync().GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = SD.Admin });
                await _roleManager.CreateAsync(new IdentityRole { Name = SD.Instructor });
                await _roleManager.CreateAsync(new IdentityRole { Name = SD.Student });
            }



            if ( ! _userManager.Users.AnyAsync().GetAwaiter().GetResult())
            {
                var admin = new AppUser
                {
                    FirstName = "admin",
                    LastName = "Ahmed",
                    Email = "admin@gmail.com",
                    UserName = "admin",
                };

                await _userManager.CreateAsync(admin, "Pa$$w0rd");
                await _userManager.AddToRolesAsync(admin, new[] { SD.Admin, SD.Instructor, SD.Student });
                await _userManager.AddClaimsAsync(admin, new[]
                {
                    new Claim(ClaimTypes.Email , admin.Email),
                    new Claim(ClaimTypes.Surname , admin.LastName)
                });
            }


            var instructor = new AppUser
            {
                FirstName = "Instructor",
                LastName = "Ahmed",
                Email = "instructor@gmail.com",
                UserName = "instructor",
            };
            await _userManager.CreateAsync(instructor, "Pa$$w0rd");
            await _userManager.AddToRolesAsync(instructor, new[] { SD.Instructor, SD.Student });
            await _userManager.AddClaimsAsync(instructor, new[]
            {
                    new Claim(ClaimTypes.Email , instructor.Email),
                    new Claim(ClaimTypes.Surname , instructor.LastName)
                });

            var student = new AppUser
            {
                FirstName = "Student",
                LastName = "Ahmed",
                Email = "student@gmail.com",
                UserName = "student",
            };
            await _userManager.CreateAsync(student, "Pa$$w0rd");
            await _userManager.AddToRolesAsync(student, new[] { SD.Student });
            await _userManager.AddClaimsAsync(student, new[]
            {
                    new Claim(ClaimTypes.Email , instructor.Email),
                    new Claim(ClaimTypes.Surname , instructor.LastName)
            });




        }




    }
}

