using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration;

public class RealizationProcessusConfiguration : IEntityTypeConfiguration<RealizationProcessus>
{
    public void Configure(EntityTypeBuilder<RealizationProcessus> builder)
    {
        builder.ToTable("RealizationProcessus");

        builder.HasKey(rp => new { rp.RealizationId, rp.ProcessusId });
        builder.HasOne(rp => rp.Processus)
            .WithMany(p => p.RealizationProcessus)
            .HasForeignKey(rp => rp.ProcessusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}