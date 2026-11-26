using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AdvantageConfiguration : IEntityTypeConfiguration<Advantage>
{
    public void Configure(EntityTypeBuilder<Advantage> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).IsRequired().HasMaxLength(200);
        builder.Property(a => a.Description).IsRequired().HasMaxLength(1000);
    }
}

public class RealizationAdvantageConfiguration : IEntityTypeConfiguration<RealizationAdvantage>
{
    public void Configure(EntityTypeBuilder<RealizationAdvantage> builder)
    {
        builder.HasKey(x => new { x.RealizationId, x.AdvantageId });

        builder.HasOne(x => x.Realization)
            .WithMany(r => r.RealizationAdvantages)
            .HasForeignKey(x => x.RealizationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Advantage)
            .WithMany(a => a.RealizationAdvantages)
            .HasForeignKey(x => x.AdvantageId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}   