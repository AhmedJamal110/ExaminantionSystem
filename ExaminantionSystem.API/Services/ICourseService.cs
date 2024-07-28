using ExaminantionSystem.API.Contracts.Course;

namespace ExaminantionSystem.API.Services
{
    public interface ICourseService
    {

        Task<IEnumerable<CourseResponse>> GetAllCoursesAsync();
        Task<CourseResponse> GetCourseAsync(int id);
        Task<CourseResponse> AddCourseAsync(CourseRequest request);
        Task<bool> UpdateCourse(int id, CourseRequest request);
        //Task<bool> IsCourseExist()

        Task DeleteCourse(int Id);

    }
}
