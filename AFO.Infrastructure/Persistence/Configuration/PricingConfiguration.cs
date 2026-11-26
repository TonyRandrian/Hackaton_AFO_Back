using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class PricingConfiguration : IEntityTypeConfiguration<Pricing>
    {
        public void Configure(EntityTypeBuilder<Pricing> builder)
        {
            builder.ToTable("Pricings");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Price)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("text");

            builder.Property(p => p.Includes)
                .HasColumnType("text[]");

            builder.HasOne(p => p.ServiceContent)
                .WithMany(sc => sc.Pricings)
                .HasForeignKey(p => p.ServiceContentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
