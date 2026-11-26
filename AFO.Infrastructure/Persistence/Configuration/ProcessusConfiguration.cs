using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration
{

    public class ProcessusConfiguration : IEntityTypeConfiguration<Processus>
    {
        public void Configure(EntityTypeBuilder<Processus> builder)
        {
            builder.ToTable("Processus");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(p => p.Order)
                .IsRequired();

            builder.Property(p => p.LogoUrl)
                .HasMaxLength(500);

            builder.Property(p => p.Image)
                .HasMaxLength(500);

            builder.Property(p => p.Contents)
                .HasColumnType("text[]");
        }
    }
}
