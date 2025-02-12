using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CogniFlow.Models.Entities;

namespace CogniFlow.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.QuestionId);

            builder.Property(q => q.Text)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(q => q.OrderIndex)
                .IsRequired();
        }
    }
}
