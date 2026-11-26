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
                .HasMaxLength(300);

            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(s => s.ShortDescription)
                .HasColumnType("text");

            builder.Property(s => s.Image)
                .HasMaxLength(500);

            builder.Property(s => s.Subtitle)
                .HasColumnType("text");

            builder.Property(s => s.ServiceDescription)
                .HasColumnType("text");

            builder.Property(s => s.ExpertiseDescription)
                .HasColumnType("text");

            builder.Property(s => s.RealizationDescription)
                .HasColumnType("text");

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
