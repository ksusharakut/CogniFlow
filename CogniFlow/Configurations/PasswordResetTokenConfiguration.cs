using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CogniFlow.Models.Entities;

namespace CogniFlow.Configurations
{
    public class PasswordResetTokenConfiguration : IEntityTypeConfiguration<PasswordResetToken>
    {
        public void Configure(EntityTypeBuilder<PasswordResetToken> builder)
        {
            builder.HasKey(p => p.PasswordResetTokenId);

            builder.Property(p => p.TokenHash)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(p => p.Status)
                .IsRequired();
        }
    }
}
