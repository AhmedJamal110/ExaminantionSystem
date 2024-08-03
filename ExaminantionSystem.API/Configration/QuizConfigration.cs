using ExaminantionSystem.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminantionSystem.API.Configration
{
    public class QuizConfigration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasIndex(x => new { x.Title, x.CourseId }).IsUnique();
        }
    }
}
