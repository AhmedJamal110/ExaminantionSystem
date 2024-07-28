
using ExaminantionSystem.API.Entities;
using ExaminantionSystem.API.Repositories;
using Microsoft.AspNetCore.Identity;

namespace ExaminantionSystem.API.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<StudentCourse> _studentRepo;
        private readonly IGenericRepository<Course> _courseRepo;
        private readonly UserManager<AppUser> _userManager;

        public UserService(IGenericRepository<StudentCourse> studentRepo , IGenericRepository<Course> courseRepo , UserManager<AppUser> userManager )
        {
            _studentRepo = studentRepo;
            _courseRepo = courseRepo;
            _userManager = userManager;
        }

        public async Task<bool> EnrollCourse(string userId, int courseId)
        {
           
                var user = await _userManager.FindByIdAsync(userId);
                if (user is null)
                    return false;

                var course = await _courseRepo.GetAsync(courseId);
                if (course is null)
                    return false;

                var userCourses = new StudentCourse
                {
                    AppUserId = user.Id,
                    CourseId = course.Id,                  
                };

            await _studentRepo.AddAsync(userCourses);
                return true;
            }

        }
    }

