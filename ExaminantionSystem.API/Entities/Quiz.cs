namespace ExaminantionSystem.API.Entities
{
    public sealed class Quiz : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;


        public ICollection<Question> Questions { get; set; } = [];
        public ICollection<StudentQuiz> StudentQuizzes { get; set; } = [];



    }


}

