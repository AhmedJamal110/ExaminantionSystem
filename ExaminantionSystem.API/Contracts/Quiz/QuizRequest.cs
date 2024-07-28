using ExaminantionSystem.API.Contracts.Question;
using ExaminantionSystem.API.Entities;

namespace ExaminantionSystem.API.Contracts.Quiz
{
    public class QuizRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        //public string Course { get; set; } = string.Empty; 
        public ICollection<QuestionRequest> Questions { get; set; } = [];


        //public ICollection<Question> Questions { get; set; } = new List<Question>();

    }
}
