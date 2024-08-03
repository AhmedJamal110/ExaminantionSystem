using ExaminantionSystem.API.Contracts.StudentQuize;
using ExaminantionSystem.API.Entities;
using ExaminantionSystem.API.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExaminantionSystem.API.Services
{
    public class StudentQuizService : IStudentQuizService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IGenericRepository<Quiz> _quizRepo;
        private readonly IGenericRepository<StudentQuiz> _studentQuizRepo;

        public StudentQuizService(UserManager<AppUser> userManager  , IGenericRepository<Quiz> quizRepo ,
            IGenericRepository<StudentQuiz> studentQuizRepo)
        {
            _userManager = userManager;
            _quizRepo = quizRepo;
            _studentQuizRepo = studentQuizRepo;
        }

        public async Task<bool> ParticipateQuizzesAsync(string userId ,  StudentQuizeRequest request)
        {
             var user = await  _userManager.FindByIdAsync(userId);
               if (user is null)
                    return false;


            var quiz = await _quizRepo.GetWithCriteriaAsync( x => x.Id == request.QuizId && x.CourseId ==request.CoursetId);

            var studentQuiz = new StudentQuiz
            {
                AppUserId = user.Id,
                QuizId = quiz.Id
            };
             await _studentQuizRepo.AddAsync(studentQuiz);
            return true;
        }


    }
}
