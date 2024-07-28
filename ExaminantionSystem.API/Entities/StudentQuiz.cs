namespace ExaminantionSystem.API.Entities
{
    public sealed class StudentQuiz :BaseEntity
    {
        public string AppUserId { get; set; } = string.Empty;
        public AppUser AppUser { get; set; } = default!;


        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = default!;

        public double Score { get; set; }

    }
}
