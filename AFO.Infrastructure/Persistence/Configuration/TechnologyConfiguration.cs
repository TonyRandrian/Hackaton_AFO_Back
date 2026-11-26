using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
{
    public void Configure(EntityTypeBuilder<Technology> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
        builder.Property(t => t.LogoUrl).IsRequired().HasMaxLength(500);
    }
}

public class RealizationTechnologyConfiguration : IEntityTypeConfiguration<RealizationTechnology>
{
    public void Configure(EntityTypeBuilder<RealizationTechnology> builder)
    {
        builder.HasKey(x => new { x.RealizationId, x.TechnologyId });

        builder.HasOne(x => x.Realization)
            .WithMany(r => r.RealizationTechnologies)
            .HasForeignKey(x => x.RealizationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Technology)
            .WithMany(t => t.RealizationTechnologies)
            .HasForeignKey(x => x.TechnologyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}