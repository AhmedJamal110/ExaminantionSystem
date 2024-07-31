namespace ExaminantionSystem.API.Services
{
    public interface IStudentCourseService
    {
        Task<bool> EnrollCourse(string userId, int courseId);

    }
}
