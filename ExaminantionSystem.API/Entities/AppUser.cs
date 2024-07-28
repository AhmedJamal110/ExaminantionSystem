using Microsoft.AspNetCore.Identity;

namespace ExaminantionSystem.API.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;


        public ICollection<StudentCourse> Courses { get; set; } = [];
        public ICollection<StudentQuiz> Quizzes { get; set; } = [];

    }
}
