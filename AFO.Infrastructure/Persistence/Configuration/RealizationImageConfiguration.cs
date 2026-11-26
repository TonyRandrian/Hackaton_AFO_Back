using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration;

public class RealizationImageConfiguration : IEntityTypeConfiguration<RealizationImage>
{
    public void Configure(EntityTypeBuilder<RealizationImage> builder)
    {
        builder.ToTable("RealizationImages");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .ValueGeneratedNever();

        builder.Property(i => i.Url)
            .IsRequired()
            .HasMaxLength(500);
    }
}