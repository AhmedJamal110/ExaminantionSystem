using ExaminantionSystem.API.Contracts.Question;
using ExaminantionSystem.API.Entities;

namespace ExaminantionSystem.API.Contracts.Quiz
{
    public class QuizWithQuestionResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public ICollection<QuestionResponse> Question { get; set; } = [];
    }
}
