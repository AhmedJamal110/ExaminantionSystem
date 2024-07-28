namespace ExaminantionSystem.API.Services
{
    public interface IUserService
    {
        Task<bool> EnrollCourse(string userId, int courseId);

    }
}
