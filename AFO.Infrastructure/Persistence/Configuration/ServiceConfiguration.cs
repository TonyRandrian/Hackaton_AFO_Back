using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(s => s.ShortDescription)
                .HasMaxLength(500);

            builder.Property(s => s.Image)
                .HasMaxLength(200);

            builder.Property(s => s.Subtitle);

            builder.Property(s => s.ServiceDescription);

            builder.Property(s => s.ExpertiseDescription);

            builder.Property(s => s.RealizationDescription);

            builder.HasMany(s => s.Contents)
                .WithOne(c => c.Service)
                .HasForeignKey(c => c.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Expertises)
                .WithOne(e => e.Service)
                .HasForeignKey(e => e.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.FAQs)
                .WithOne(f => f.Service)
                .HasForeignKey(sp => sp.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.Realizations)
                .WithOne(r => r.Service)
                .HasForeignKey(r => r.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
