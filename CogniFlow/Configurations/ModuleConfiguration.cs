using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CogniFlow.Models.Entities;

namespace CogniFlow.Configurations
{
    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasKey(m => m.ModuleId);

            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(m => m.OrderIndex)
                .IsRequired();

            builder.Property(m => m.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
