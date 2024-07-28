namespace ExaminantionSystem.API.Entities
{
    public class StudentCourse : BaseEntity
    {

        public string AppUserId { get; set; } = string.Empty;
        public AppUser AppUser { get; set; } = default!;

        public int CourseId { get; set; }
        public Course Course { get; set; } = default!;

    }
}
