using ExaminantionSystem.API.Entities;

namespace ExaminantionSystem.API.Contracts.Course
{
    public class CourseRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Language { get; set; } = string.Empty;
        public string Instructor { get; set; } = string.Empty;

        //public int InstructorId { get; set; }

    }
}
