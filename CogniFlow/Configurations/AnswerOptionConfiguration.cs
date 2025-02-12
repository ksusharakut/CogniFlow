using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CogniFlow.Models.Entities;

namespace CogniFlow.Configurations
{
    public class AnswerOptionConfiguration : IEntityTypeConfiguration<AnswerOption>
    {
        public void Configure(EntityTypeBuilder<AnswerOption> builder)
        {
            builder.HasKey(a => a.AnswerOptionId);

            builder.Property(a => a.Text)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(a => a.IsCorrect)
                .IsRequired();
        }
    }
}
