namespace ExaminantionSystem.API.Contracts.Quiz
{
    public class QuizResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
