using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Configuration;

public class RealizationConfiguration : IEntityTypeConfiguration<Realization>
{
    public void Configure(EntityTypeBuilder<Realization> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedNever();

        builder.Property(r => r.Name).IsRequired().HasMaxLength(200);
        builder.Property(r => r.ShortDescription).IsRequired().HasMaxLength(1000);
        builder.Property(r => r.Title).IsRequired().HasMaxLength(500);
        builder.Property(r => r.SubTitle).IsRequired().HasMaxLength(500);
        builder.Property(r => r.ProjectUrl).IsRequired().HasMaxLength(700);
        builder.Property(r => r.AboutDescription).IsRequired();
        builder.Property(r => r.ProjectDescription).IsRequired();
        builder.Property(r => r.GoalDescription).IsRequired();
        builder.Property(r => r.Qualities).HasColumnType("text[]");

        builder.HasOne(r => r.Service)
            .WithMany(s => s.Realizations)
            .HasForeignKey(r => r.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.ServiceContent)
            .WithMany(c => c.Realizations)
            .HasForeignKey(r => r.ServiceContentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}