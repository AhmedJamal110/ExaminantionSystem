using ExaminantionSystem.API.Contracts.Quiz;

namespace ExaminantionSystem.API.Services
{
    public interface IQuizServices
    {
        Task<QuizWithQuestionResponse> CreateQuizAsync(int courseId ,  QuizRequest request);
        Task<IEnumerable<QuizWithQuestionResponse>> GetQuizWithQuestionAsync(int courseId );
        Task<IEnumerable<QuizResponse>> GetAllQuizAsync(int courseId);

        Task<QuizWithQuestionResponse?> GetByIdAsync(int courseId, int id);

    }
}
