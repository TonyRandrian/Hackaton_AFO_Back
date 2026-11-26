using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration;

public class AdvantageConfiguration : IEntityTypeConfiguration<Advantage>
{
    public void Configure(EntityTypeBuilder<Advantage> builder)
    {
        builder.ToTable("Advantages");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedNever();

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(a => a.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.HasMany(a => a.RealizationAdvantages)
            .WithOne(ra => ra.Advantage)
            .HasForeignKey(ra => ra.AdvantageId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}