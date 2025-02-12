using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CogniFlow.Models.Entities;

namespace CogniFlow.Configurations
{
    public class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> builder)
        {
            builder.HasKey(uc => new { uc.UserId, uc.CourseId });

            builder.Property(uc => uc.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(uc => uc.CompletionStatus)
                .IsRequired();

            builder.HasIndex(uc => new { uc.UserId, uc.CourseId })
                .IsUnique();
        }
    }
}
