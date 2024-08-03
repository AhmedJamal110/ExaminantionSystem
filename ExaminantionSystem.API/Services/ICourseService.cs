using ExaminantionSystem.API.Contracts.Course;
using ExaminantionSystem.API.Entities;

namespace ExaminantionSystem.API.Services
{
    public interface ICourseService
    {

        Task<IEnumerable<CourseResponse>> GetAllCoursesAsync();
        Task<CourseResponse> GetCourseAsync(int id);
        Task<CourseResponse> AddCourseAsync(CourseRequest request);
        Task<bool> UpdateCourse(int id, CourseRequest request);

        Task<CourseResponse> GetAvaiableCourses(string userId);
        Task DeleteCourse(int Id);

    }
}
