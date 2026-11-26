using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class ServiceContentConfiguration : IEntityTypeConfiguration<ServiceContent>
    {
        public void Configure(EntityTypeBuilder<ServiceContent> builder)
        {
            builder.ToTable("ServiceContents");

            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Name)
            .IsRequired()
            .HasMaxLength(150);

            builder.HasOne(sc => sc.Service)
                .WithMany(s => s.Contents)
                .HasForeignKey(sc => sc.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sc => sc.Pricings)
                .WithOne(p => p.ServiceContent)
                .HasForeignKey(p => p.ServiceContentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(sc => sc.Realizations)
                .WithOne(r => r.ServiceContent)
                .HasForeignKey(r => r.ServiceContentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
