namespace ExaminantionSystem.API.Entities
{
    public sealed class Question : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty; 

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = default!;


    }
}

        //public ICollection<Choice> Choices { get; set; } = new List<Choice>();
        //public ICollection<Answer> Answers { get; set; } = new List<Answer>();
