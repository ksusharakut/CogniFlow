using CogniFlow.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CogniFlow.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Description)
                .IsRequired();

            builder.Property(c => c.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.IsPublished)
                .IsRequired();
        }

    }
}
