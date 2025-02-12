using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CogniFlow.Models.Entities;

namespace CogniFlow.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.LessonId);

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(l => l.ContentPath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(l => l.OrderIndex)
                .IsRequired();

            builder.Property(l => l.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
