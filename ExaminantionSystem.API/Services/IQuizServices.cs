using ExaminantionSystem.API.Contracts.Quiz;

namespace ExaminantionSystem.API.Services
{
    public interface IQuizServices
    {
        Task<QuizResponse> CreateQuizAsync(int courseId ,  QuizRequest request);
        Task<IEnumerable<QuizResponse>> GetAllQuizAsync();

    }
}
