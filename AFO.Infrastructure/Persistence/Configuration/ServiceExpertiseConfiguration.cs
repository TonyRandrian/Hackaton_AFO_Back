using AFO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AFO.Infrastructure.Persistence.Configuration
{
    public class ServiceExpertiseConfiguration
        : IEntityTypeConfiguration<ServiceExpertise>
    {
        public void Configure(EntityTypeBuilder<ServiceExpertise> builder)
        {
            builder.ToTable("ServiceExpertises");

            builder.HasKey(se => se.Id);

            builder.Property(se => se.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(se => se.Description)
                .IsRequired();

            builder.Property(se => se.Contents)
                .HasColumnType("text[]");

            builder.HasOne(se => se.Service)
                .WithMany(s => s.Expertises)
                .HasForeignKey(se => se.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
