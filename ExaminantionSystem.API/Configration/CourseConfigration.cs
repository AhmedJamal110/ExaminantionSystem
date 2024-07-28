using ExaminantionSystem.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminantionSystem.API.Configration
{
    public class CourseConfigration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasIndex(x => x.Title).IsUnique();

            builder.Property(x => x.Rating).HasColumnType("decimal(18,2)");
        }
    }
}
