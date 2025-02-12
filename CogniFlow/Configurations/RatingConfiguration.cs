using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CogniFlow.Models.Entities;

namespace CogniFlow.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(r => r.RatingId);

            builder.Property(r => r.UserRating)
                .IsRequired();

            builder.Property(r => r.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(r => r.ReviewDescription)
                .HasMaxLength(1000);

        }
    }
}
