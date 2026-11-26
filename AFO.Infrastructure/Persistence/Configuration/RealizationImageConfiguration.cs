using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RealizationImageConfiguration : IEntityTypeConfiguration<RealizationImage>
{
    public void Configure(EntityTypeBuilder<RealizationImage> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedNever();
        builder.Property(i => i.Url).IsRequired().HasMaxLength(500);

        
        builder.HasOne(i => i.Realization)
            .WithMany(r => r.Images)
            .HasForeignKey(i => i.RealizationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(i => i.RealizationImageType)
            .WithMany(t => t.RealizationImages)
            .HasForeignKey(i => i.RealizationImageTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class RealizationImageTypeConfiguration : IEntityTypeConfiguration<RealizationImageType>
{
    public void Configure(EntityTypeBuilder<RealizationImageType> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedNever();
        builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(t => t.Name).IsUnique();
    }
}