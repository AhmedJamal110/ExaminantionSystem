namespace ExaminantionSystem.API.Entities
{
    public sealed class Course : BaseEntity
    {

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Language { get; set; } = string.Empty;
        public string Instructor { get; set; } = string.Empty;


        public ICollection<StudentCourse> StudentCourses { get; set; } = [];

    }
}
