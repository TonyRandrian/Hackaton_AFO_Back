using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class RealizationImageTypeConfiguration : IEntityTypeConfiguration<RealizationImageType>
    {
        public void Configure(EntityTypeBuilder<RealizationImageType> builder)
        {
            builder.ToTable("RealizationImageTypes");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedNever();

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(t => t.Name)
                .IsUnique();

            builder.HasMany(t => t.RealizationImages)
                .WithOne(i => i.RealizationImageType)
                .HasForeignKey(i => i.RealizationImageTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
