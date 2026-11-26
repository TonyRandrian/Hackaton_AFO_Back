using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration;

public class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
{
    public void Configure(EntityTypeBuilder<Technology> builder)
    {
        builder.ToTable("Technologies");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedNever();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.LogoUrl)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasMany(t => t.RealizationTechnologies)
            .WithOne(rt => rt.Technology)
            .HasForeignKey(rt => rt.TechnologyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}